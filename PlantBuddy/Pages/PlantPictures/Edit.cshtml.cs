using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PlantBuddy.Data;
using PlantBuddy.Models;

namespace PlantBuddy.Pages.PlantPictures
{
    public class EditModel : PageModel
    {
        private readonly PlantBuddy.Data.PlantBuddyContext _context;

        public EditModel(PlantBuddy.Data.PlantBuddyContext context)
        {
            _context = context;
        }

        [BindProperty]
        public PlantPicture PlantPicture { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.PlantPictures == null)
            {
                return NotFound();
            }

            var plantpicture =  await _context.PlantPictures.FirstOrDefaultAsync(m => m.PlantPictureId == id);
            if (plantpicture == null)
            {
                return NotFound();
            }
            PlantPicture = plantpicture;
           ViewData["PlantId"] = new SelectList(_context.Plants, "PlantId", "PlantName");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(PlantPicture).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlantPictureExists(PlantPicture.PlantPictureId))
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

        private bool PlantPictureExists(int id)
        {
          return (_context.PlantPictures?.Any(e => e.PlantPictureId == id)).GetValueOrDefault();
        }
    }
}
