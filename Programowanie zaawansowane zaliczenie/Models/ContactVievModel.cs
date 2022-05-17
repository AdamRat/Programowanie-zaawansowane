using System.ComponentModel;

namespace Programowanie_zaawansowane_zaliczenie.Models
{
    public class ContactVievModel
    {
        public int Id { get; set; }
        [DisplayName("Imię")]
        public string FirstName { get; set; }
        [DisplayName("Nazwisko")]
        public string LastName { get; set; }
        [DisplayName("Adres")]
        public Adresses Adress { get; set; }
        [DisplayName("Nr telefonu")]
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string FbLink { get; set; }
        public ContactCategories ContactCategory { get; set; }
    }
}
