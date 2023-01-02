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
    public class IndexModel : PageModel
    {
        private readonly lab12_4.Data.ClientContext _context;

        public IndexModel(lab12_4.Data.ClientContext context)
        {
            _context = context;
        }

        public IList<Client> Client { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Clients != null)
            {
                Client = await _context.Clients.ToListAsync();
            }
        }
    }
}
