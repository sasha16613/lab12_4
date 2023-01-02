using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using lab12_4.Models;

namespace lab12_4.Data
{
    public class ClientContext : DbContext
    {
        public ClientContext (DbContextOptions<ClientContext> options)
            : base(options)
        {
        }

        public DbSet<Tour> Tours { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Visa> Visas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Visa>().ToTable("Visa");
            modelBuilder.Entity<Client>().ToTable("Client");
            modelBuilder.Entity<Tour>().ToTable("Tour");
        }

        //public DbSet<lab12_4.Models.Client> Client { get; set; } = default!;
    }
}
