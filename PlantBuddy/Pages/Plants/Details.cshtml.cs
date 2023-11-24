using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PlantBuddy.Data;
using PlantBuddy.Models;

namespace PlantBuddy.Pages.Plants
{
    public class DetailsModel : PageModel
    {
        private readonly PlantBuddy.Data.PlantBuddyContext _context;

        public DetailsModel(PlantBuddy.Data.PlantBuddyContext context)
        {
            _context = context;
        }

        [BindProperty] public Plant Plant { get; set; } = default!;
        [BindProperty] public DateTime DateWatered { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Plants == null)
            {
                return NotFound();
            }

            var plant = await _context.Plants.FirstOrDefaultAsync(m => m.PlantId == id);
            if (plant == null)
            {
                return NotFound();
            }
            else 
            {
                Plant = plant;
            }

            DateWatered = DateTime.Now;

            return Page();
        }

        public async Task<IActionResult> OnPostAddWaterHistory(int id)
        {
            var waterHistory = new WaterHistory()
            {
                CreatedDate = DateTime.Now,
                LastModifiedDate = DateTime.Now,
                PlantId = id,
                WateredOn = DateWatered
            };

            _context.WaterHistories.Add(waterHistory);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Details", new { id = id });
        }
    }
}
