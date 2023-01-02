using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using lab12_4.Data;
using lab12_4.Models;

namespace lab12_4.Pages.Clients
{
    public class CreateModel : PageModel
    {
        private readonly lab12_4.Data.ClientContext _context;

        public CreateModel(lab12_4.Data.ClientContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Client CreatedClient { get; set; }
        [BindProperty]
        public Tour CreatedTour { get; set; }
        [BindProperty]
        public Visa CreatedVisa { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            //if (!ModelState.IsValid)
            //{
            //    return Page();
            //}

            //_context.Clients.Add(Client);
            //await _context.SaveChangesAsync();

            
            var emptyClient = new Client();
            var emptyTour = new Tour();
            var emptyVisa = new Visa();

            emptyClient.Surename = CreatedClient.Surename;
            emptyClient.Name = CreatedClient.Name;

            _context.Clients.Add(emptyClient);
            //_context.SaveChanges();

            //emptyVisa.VisaName = "John";
            emptyVisa.VisaName = CreatedVisa.VisaName;
            emptyVisa.VisaPrice = CreatedVisa.VisaPrice;

            _context.Visas.Add(emptyVisa);
            _context.SaveChanges();

            emptyTour.Visa_t = emptyVisa.VisaID;
            emptyTour.Client = emptyClient.ClientID;
            emptyTour.Price = CreatedTour.Price;
            emptyTour.Country = CreatedTour.Country;
            emptyTour.Visas = emptyVisa;
            emptyTour.Clients = emptyClient;

            _context.Tours.Add(emptyTour);
            _context.SaveChanges();
            return RedirectToPage("./Index");


            //if (await TryUpdateModelAsync<Client>(
            //    emptyClient,
            //    "Client",   // Prefix for form value.
            //    s => s.Surename, s => s.Name))
            //{
            //    _context.Clients.Add(emptyClient);
            //    await _context.SaveChangesAsync();
            //    return RedirectToPage("./Index");
            //}

            //return Page();
            //return RedirectToPage("./Index");
        }
    }
}
