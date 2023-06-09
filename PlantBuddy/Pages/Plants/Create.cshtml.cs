﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using PlantBuddy.Data;
using PlantBuddy.Models;

namespace PlantBuddy.Pages.Plants
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
            ViewData["StoreId"] = new SelectList(_context.Stores, "StoreId", "StoreName");
            return Page();
        }

        [BindProperty]
        public Plant Plant { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Plants == null || Plant == null)
            {
                return Page();
            }

            _context.Plants.Add(Plant);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
