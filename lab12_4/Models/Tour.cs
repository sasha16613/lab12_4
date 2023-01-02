using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lab12_4.Models
{
    public class Tour
    {
        //[Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TourID { get; set; }
        public int Client { get; set; }
        public int Price { get; set; }
        public string Country { get; set; } = null!;
        public int Visa_t { get; set; }

        public Visa Visas { get; set; }
        public Client Clients { get; set; }
    }
}
