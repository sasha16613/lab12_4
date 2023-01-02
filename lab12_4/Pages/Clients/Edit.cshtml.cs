using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using lab12_4.Data;
using lab12_4.Models;

namespace lab12_4.Pages.Clients
{
    public class EditModel : PageModel
    {
        private readonly lab12_4.Data.ClientContext _context;

        public EditModel(lab12_4.Data.ClientContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Client CreatedClient { get; set; } = default!;
        [BindProperty]
        public Visa CreatedVisa { get; set; } = default!;
        [BindProperty]
        public Tour CreatedTour { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Clients == null)
            {
                return NotFound();
            }

            var tour = _context.Tours.Include(c => c.Clients).Include(d => d.Visas).AsNoTracking().FirstOrDefault(s => s.Client == id);
            //var client = _context.Clients.Include(c => c.Tours).FirstOrDefault(m => m.ClientID == id);
            //var client =  _context.Clients.FirstOrDefault(m => m.ClientID == id);
            //var tour = _context.Tours.FirstOrDefault(s => s.Client == client.ClientID); //Clients.FirstOrDefault(m => m.ClientID == id);
            //var visa = _context.Visas.FirstOrDefault(s => s.VisaID == tour.Visa_t);
            if (tour.Clients == null)
            {
                return NotFound();
            }
            CreatedClient = tour.Clients;
            CreatedVisa = tour.Visas;
            CreatedTour = tour;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                return Page();
            }

            _context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;

            var tour = _context.Tours.Include(c => c.Visas).AsNoTracking().FirstOrDefault(s => s.Client == CreatedClient.ClientID);

            //var client = _context.Clients.Include(c => c.Tours).ThenInclude(d => d.Visas).AsNoTracking().FirstOrDefault(s => s.ClientID == CreatedClient.ClientID);
            //CreatedVisa.VisaID = tour.Visas.VisaID;

            //TryUpdateModelAsync<Client>(CreatedClient, "", c => c.Surename, c => c.Name);
            //CreatedTour.TourID = tour.TourID;
            CreatedTour.Visa_t = tour.Visas.VisaID; //Entry Attach
            CreatedTour.Client = CreatedClient.ClientID;

            _context.Attach(CreatedClient).State = EntityState.Modified;
            _context.SaveChanges();
            _context.Attach(CreatedClient).State = EntityState.Detached;

            _context.Attach(CreatedVisa).State = EntityState.Modified;
            _context.SaveChanges();
            _context.Attach(CreatedVisa).State = EntityState.Detached;

            _context.Attach(CreatedTour).State = EntityState.Modified;


            try
            {
                _context.SaveChanges();
                _context.Attach(CreatedTour).State = EntityState.Detached;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClientExists(CreatedClient.ClientID))
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

        private bool ClientExists(int id)
        {
          return _context.Clients.Any(e => e.ClientID == id);
        }
    }
}
