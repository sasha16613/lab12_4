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
    public class DeleteModel : PageModel
    {
        private readonly lab12_4.Data.ClientContext _context;

        public DeleteModel(lab12_4.Data.ClientContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Client Client { get; set; }
        [BindProperty]
        public Tour Tour { get; set; }
        [BindProperty]
        public Visa Visa { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Clients == null)
            {
                return NotFound();
            }

            var client = await _context.Clients.Include(c => c.Tours).ThenInclude(d => d.Visas).FirstOrDefaultAsync(m => m.ClientID == id);

            if (client == null)
            {
                return NotFound();
            }
            else 
            {
                Client = client;
                Tour = client.Tours.FirstOrDefault(c => c.Client == client.ClientID);
                Visa = Tour.Visas;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Clients == null)
            {
                return NotFound();
            }
            var client = _context.Clients.Find(id);

            if (client != null)
            {
                Client = client;
                Tour = _context.Tours.FirstOrDefault(c => c.Client == client.ClientID);
                Visa = _context.Visas.FirstOrDefault(c => c.VisaID == Tour.Visa_t);
                _context.Clients.Remove(Client);
                _context.Visas.Remove(Visa);
                _context.Tours.Remove(Tour);
                _context.SaveChanges();
            }

            return RedirectToPage("./Index");
        }
    }
}
