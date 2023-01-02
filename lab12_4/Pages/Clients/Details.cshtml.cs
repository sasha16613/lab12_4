using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using lab12_4.Data;
using lab12_4.Models;

namespace lab12_4.Pages.Clients
{
    public class DetailsModel : PageModel
    {
        private readonly lab12_4.Data.ClientContext _context;

        public DetailsModel(lab12_4.Data.ClientContext context)
        {
            _context = context;
        }

      public Client Client { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Clients == null)
            {
                return NotFound();
            }

            //var client = await _context.Clients.FirstOrDefaultAsync(m => m.ClientID == id);

            var client = await _context.Clients
        .Include(s => s.Tours)
        .ThenInclude(e => e.Visas)
        .AsNoTracking()
        .FirstOrDefaultAsync(m => m.ClientID == id);

            if (client == null)
            {
                return NotFound();
            }
            else 
            {
                Client = client;
            }
            return Page();
        }
    }
}
