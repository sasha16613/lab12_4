using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lab12_4.Models
{
    public class Visa
    {
        //[Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int VisaID { get; set; }
        public string VisaName { get; set; }
        public int VisaPrice { get; set; }

        public ICollection<Tour> Tours { get; set; }
    }
}
