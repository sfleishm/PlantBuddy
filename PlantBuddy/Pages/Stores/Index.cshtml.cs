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
    public class IndexModel : PageModel
    {
        private readonly PlantBuddy.Data.PlantBuddyContext _context;

        public IndexModel(PlantBuddy.Data.PlantBuddyContext context)
        {
            _context = context;
        }

        public IList<Store> Store { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Stores != null)
            {
                Store = await _context.Stores.ToListAsync();
            }
        }
    }
}
