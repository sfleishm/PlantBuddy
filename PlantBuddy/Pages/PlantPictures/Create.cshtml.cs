using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using PlantBuddy.Data;
using PlantBuddy.Models;

namespace PlantBuddy.Pages.PlantPictures
{
    public class CreateModel : PageModel
    {
        private readonly PlantBuddy.Data.PlantBuddyContext _context;

        public CreateModel(PlantBuddy.Data.PlantBuddyContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["PlantId"] = new SelectList(_context.Plants, "PlantId", "PlantName");
            return Page();
        }

        [BindProperty]
        public PlantPicture PlantPicture { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.PlantPictures == null || PlantPicture == null)
            {
                return Page();
            }

            _context.PlantPictures.Add(PlantPicture);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
