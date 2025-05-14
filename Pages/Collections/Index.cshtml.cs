using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CIDM_3312_Final_Project.Models;
using System.ComponentModel.DataAnnotations;

namespace CIDM_3312_Final_Project.Pages_Collections
{
    public class IndexModel : PageModel
    {
        private readonly CIDM_3312_Final_Project.Models.AppDbContext _context;

        public IndexModel(CIDM_3312_Final_Project.Models.AppDbContext context)
        {
            _context = context;
        }

        public IList<Collection> Collection { get;set; } = default!;

        [BindProperty(SupportsGet = true)]
        public int PageNum {get; set;} = 1;
        public int PageSize {get; set;} = 15;
        public int TotalPages {get; set;}

         [BindProperty(SupportsGet = true)]
        public string CurrentSort {get; set;} = string.Empty;

        [BindProperty(SupportsGet =  true)]
        public string CurrentSearch {get; set;} = string.Empty;

        public async Task OnGetAsync()
        {
            var query = _context.Collections.Include(s => s.CollectionCards!).ThenInclude(sc => sc.Card).Select(s => s);

             if (!string.IsNullOrEmpty(CurrentSearch))
            {
                query = query.Where(s => s.FirstName.ToUpper().Contains(CurrentSearch.ToUpper()) || s.LastName.ToUpper().Contains(CurrentSearch.ToUpper()));
            }

             switch (CurrentSort)
            {
                case "first_asc":
                    query = query.OrderBy(s => s.FirstName);
                    break;
                case "first_desc":
                    query = query.OrderByDescending(s => s.FirstName);
                    break;
            }

            TotalPages = (int)Math.Ceiling(_context.Collections.Count() / (double)PageSize);
    
            Collection = await query.Skip((PageNum-1)*PageSize).Take(PageSize).ToListAsync(); 
        }
    }
}
