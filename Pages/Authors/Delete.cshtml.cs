﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Vladutescu_Medeia_Lab2.Data;
using Vladutescu_Medeia_Lab2.Models;

namespace Vladutescu_Medeia_Lab2.Pages.Authors
{
    public class DeleteModel : PageModel
    {
        private readonly Vladutescu_Medeia_Lab2.Data.Vladutescu_Medeia_Lab2Context _context;

        public DeleteModel(Vladutescu_Medeia_Lab2.Data.Vladutescu_Medeia_Lab2Context context)
        {
            _context = context;
        }

        [BindProperty]
        public Author Author { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var author = await _context.Authors.FirstOrDefaultAsync(m => m.ID == id);

            if (author == null)
            {
                return NotFound();
            }
            else
            {
                Author = author;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var author = await _context.Authors.FindAsync(id);
            if (author != null)
            {
                Author = author;
                _context.Authors.Remove(Author);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
