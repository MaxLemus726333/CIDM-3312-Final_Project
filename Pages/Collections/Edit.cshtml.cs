using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CIDM_3312_Final_Project.Models;

namespace CIDM_3312_Final_Project.Pages_Collections
{
    public class EditModel : PageModel
    {
        private readonly CIDM_3312_Final_Project.Models.AppDbContext _context;

        public EditModel(CIDM_3312_Final_Project.Models.AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Collection Collection { get; set; } = default!;

        public List<Card> Cards {get; set;} = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var collection =  await _context.Collections.Include(s => s.CollectionCards!).ThenInclude(sc => sc.Card). FirstOrDefaultAsync(m => m.CollectionID == id);
            Cards = _context.Cards.ToList();
            if (collection == null)
            {
                return NotFound();
            }
            Collection = collection;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int[] selectedCards)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

              var collectionToUpdate = await _context.Collections.Include(s => s.CollectionCards!).ThenInclude(sc => sc.Card).FirstOrDefaultAsync(m => m.CollectionID == Collection.CollectionID);
            if (collectionToUpdate != null)
            {
                collectionToUpdate.FirstName = Collection.FirstName;
                collectionToUpdate.LastName = Collection.LastName;
                UpdateCollectionCards(selectedCards, collectionToUpdate);
            }

            // _context.Attach(Collection).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CollectionExists(Collection.CollectionID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool CollectionExists(int id)
        {
            return _context.Collections.Any(e => e.CollectionID == id);
        }

         private void UpdateCollectionCards(int[] selectedCards, Collection collectionToUpdate)
        {
            if (selectedCards == null)
            {
                collectionToUpdate.CollectionCards = new List<CollectionCard>();
                return;
            }

            List<int> ownedCards = collectionToUpdate.CollectionCards!.Select(c => c.CardID).ToList();
            List<int> selectedCardList = selectedCards.ToList();

            foreach (var card in _context.Cards)
            {
                if (selectedCardList.Contains(card.CardID))
                {
                    if (!ownedCards.Contains(card.CardID))
                    {
                        // Add card here
                        collectionToUpdate.CollectionCards!.Add(
                            new CollectionCard { CollectionID = collectionToUpdate.CollectionID, CardID = card.CardID }
                        );
                    }
                }
                else
                {
                    if (ownedCards.Contains(card.CardID))
                    {
                        // Remove card here
                        CollectionCard cardToRemove = collectionToUpdate.CollectionCards!.SingleOrDefault(s => s.CardID == card.CardID)!;
                        _context.Remove(cardToRemove);
                    }
                }
            }
        }
    }
}