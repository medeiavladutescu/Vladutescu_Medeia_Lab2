using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Vladutescu_Medeia_Lab2.Data;
using Vladutescu_Medeia_Lab2.Models;

namespace Vladutescu_Medeia_Lab2.Pages.Books
{
    public class IndexModel : PageModel
    {
        private readonly Vladutescu_Medeia_Lab2Context _context;

        public IndexModel(Vladutescu_Medeia_Lab2Context context)
        {
            _context = context;
        }

        public IList<Book> Book { get; set; } = default!;

        public async Task OnGetAsync()
        {
            // Popularea listei de cărți
            Book = await _context.Book
                .Include(b => b.Publisher)
                .Include(b => b.Author) // Include autorul pentru fiecare carte
                .ToListAsync();

            // Popularea listei de autori folosind ViewData
            ViewData["Authors"] = await _context.Authors.ToListAsync();
        }
    }
}
