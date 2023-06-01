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
        private readonly PlantBuddyContext _context;
        private IWebHostEnvironment _environment;

        public CreateModel(PlantBuddyContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        public IActionResult OnGet()
        {
            ViewData["PlantId"] = new SelectList(_context.Plants, "PlantId", "PlantName");
            return Page();
        }

        [BindProperty]
        public IFormFile PictureUpload { get; set; }

        [BindProperty]
        public PlantPicture PlantPicture { get; set; } = default!;


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (_context.PlantPictures == null || PlantPicture == null) //!ModelState.IsValid
            {
                return Page();
            }

            var x = PlantPicture.Picture;

            // REF: https://www.youtube.com/watch?v=Du8brcxA-KM
            using (BinaryReader br = new BinaryReader(PictureUpload.OpenReadStream()))
            {
                PlantPicture.Picture = br.ReadBytes((int)PictureUpload.Length);
            }

            _context.PlantPictures.Add(PlantPicture);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
