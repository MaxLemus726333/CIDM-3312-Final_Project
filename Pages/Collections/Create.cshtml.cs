using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CIDM_3312_Final_Project.Models;

namespace CIDM_3312_Final_Project.Pages_Collections
{
    public class CreateModel : PageModel
    {
        private readonly CIDM_3312_Final_Project.Models.AppDbContext _context;

        public CreateModel(CIDM_3312_Final_Project.Models.AppDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Collection Collection { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Collections.Add(Collection);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
