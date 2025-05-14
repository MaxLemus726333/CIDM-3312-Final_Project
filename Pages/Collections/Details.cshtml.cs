using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CIDM_3312_Final_Project.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;

namespace CIDM_3312_Final_Project.Pages_Collections
{
    public class DetailsModel : PageModel
    {
        private readonly CIDM_3312_Final_Project.Models.AppDbContext _context;
        private readonly ILogger<DetailsModel> _logger;

        public DetailsModel(ILogger<DetailsModel> logger,CIDM_3312_Final_Project.Models.AppDbContext context)
        {
            _context = context;
            _logger = logger;
        }

        public Collection Collection { get; set; } = default!;

        [BindProperty]
        [Display(Name = "Add Card")]
        [Required(ErrorMessage = "Invalid Card")]
        public int CardIDToAdd { get; set;}
        public SelectList CardsDropDown {get; set;} = default!;

        [BindProperty]
        public int CardIDToDelete {get; set;}

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var collection = await _context.Collections.Include(s => s.CollectionCards!).ThenInclude(sc => sc.Card).FirstOrDefaultAsync(m => m.CollectionID == id);

            if (collection == null)
            {
             return NotFound();
            }
            else
            {
                Collection = collection;
            }

            CardsDropDown = new SelectList(_context.Cards.ToList(), "CardID", "Description");
            return Page();
        }

        public IActionResult OnPostAddCard(int? id)
        {
            _logger.LogWarning($"Add Card: CardID {id}, ADD card {CardIDToAdd}");

            if (id == null)
            {
                return NotFound();
            }

            var collection = _context.Collections.Include(s => s.CollectionCards!).ThenInclude(sc => sc.Card).FirstOrDefault(m => m.CollectionID == id);

            if (id == null)
            {
                return NotFound();
            }
            else
            {
                Collection = collection;
            }
            CardsDropDown = new SelectList(_context.Cards.ToList(), "CardID", "Description");

            if (!ModelState.IsValid)
            {
                _logger.LogWarning($"Model State is INVALID");
                return Page();
            }

            if (!_context.CollectionCards.Any(sc => sc.CardID == CardIDToAdd && sc.CollectionID == id))
            {
                CollectionCard cardToAdd = new CollectionCard {CollectionID = id.Value, CardID = CardIDToAdd};
                _context.Add(cardToAdd);
                _context.SaveChanges();
            } else {
                _logger.LogWarning("Owner already has this card");
            }

            return Page();
        }

        public IActionResult OnPostCardDelete(int? id)
        {
            _logger.LogWarning($"Delete card: CollectionId {id}, Delete card {CardIDToDelete}");

            if (id == null)
            {
                return NotFound();
            }

            var collection = _context.Collections.Include(s => s.CollectionCards!).ThenInclude(sc => sc.Card).FirstOrDefault(m => m.CollectionID == id);

            if (collection == null)
            {
                return NotFound();
            }
            else
            {
                Collection = collection;
            }
            CardsDropDown = new SelectList(_context.Cards.ToList(), "CardID", "Description");

            var cardToDrop = _context.CollectionCards.Find(CardIDToDelete, id);

            if (cardToDrop != null)
            {
                _context.Remove(cardToDrop);
                _context.SaveChanges();
            }
            else 
            {
                _logger.LogWarning("Owner does not have that card.");
            }
            return RedirectToPage(new {id = id});
        }
    }
}
