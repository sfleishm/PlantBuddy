﻿using System;
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

      public Plant Plant { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Plant == null)
            {
                return NotFound();
            }

            var plant = await _context.Plant.FirstOrDefaultAsync(m => m.PlantId == id);
            if (plant == null)
            {
                return NotFound();
            }
            else 
            {
                Plant = plant;
            }
            return Page();
        }
    }
}
