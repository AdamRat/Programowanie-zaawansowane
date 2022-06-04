using System.ComponentModel;

namespace Programowanie_zaawansowane_zaliczenie.Models
{
    public class Adresses
    {
        public int Id { get; set; }
        [DisplayName("Ulica i numer")]
        public string Street { get; set; }
        [DisplayName("Kod pocztowy")]
        public string PostCode { get; set; }
        [DisplayName("Miasto")]
        public string City { get; set; }
        [DisplayName("Państwo")]
        public string Country { get; set; }
    }
}
