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
    public class DetailsModel : PageModel
    {
        private readonly PlantBuddy.Data.PlantBuddyContext _context;

        public DetailsModel(PlantBuddy.Data.PlantBuddyContext context)
        {
            _context = context;
        }

      public PlantPicture PlantPicture { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.PlantPictures == null)
            {
                return NotFound();
            }

            var plantpicture = await _context.PlantPictures.FirstOrDefaultAsync(m => m.PlantPictureId == id);
            if (plantpicture == null)
            {
                return NotFound();
            }
            else 
            {
                PlantPicture = plantpicture;
            }
            return Page();
        }
    }
}
