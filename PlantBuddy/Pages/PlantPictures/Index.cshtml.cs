using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PlantBuddy.Data;
using PlantBuddy.Models;

namespace PlantBuddy.Pages.PlantPictures
{
    public class IndexModel : PageModel
    {
        private readonly PlantBuddy.Data.PlantBuddyContext _context;

        public IndexModel(PlantBuddy.Data.PlantBuddyContext context)
        {
            _context = context;
        }

        public IList<PlantPicture> PlantPicture { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.PlantPictures != null)
            {
                PlantPicture = await _context.PlantPictures
                .Include(p => p.Plant).ToListAsync();
            }
        }
    }
}
