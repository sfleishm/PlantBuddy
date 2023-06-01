using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PlantBuddy.Data;
using PlantBuddy.Models;

namespace PlantBuddy.Pages.Stores
{
    public class DeleteModel : PageModel
    {
        private readonly PlantBuddy.Data.PlantBuddyContext _context;

        public DeleteModel(PlantBuddy.Data.PlantBuddyContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Store Store { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Stores == null)
            {
                return NotFound();
            }

            var store = await _context.Stores.FirstOrDefaultAsync(m => m.StoreId == id);

            if (store == null)
            {
                return NotFound();
            }
            else 
            {
                Store = store;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Stores == null)
            {
                return NotFound();
            }
            var store = await _context.Stores.FindAsync(id);

            if (store != null)
            {
                Store = store;
                _context.Stores.Remove(Store);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
