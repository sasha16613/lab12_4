using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lab12_4.Models
{
    public class Client
    {
        //[Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ClientID { get; set; }
        public string Surename { get; set; }
        public string Name { get; set; }

        public ICollection<Tour> Tours { get; set; }
    }
}
