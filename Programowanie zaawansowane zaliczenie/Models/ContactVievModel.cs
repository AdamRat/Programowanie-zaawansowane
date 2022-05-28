using System.ComponentModel;

namespace Programowanie_zaawansowane_zaliczenie.Models
{
    public class ContactVievModel
    {
        public uint Id { get; set; }
        [DisplayName("Imię")]
        public string FirstName { get; set; }
        [DisplayName("Nazwisko")]
        public string LastName { get; set; }
        [DisplayName("Adres")]
        public Adresses Adress { get; set; }
        [DisplayName("Nr telefonu")]
        public string PhoneNumber { get; set; }
        [DisplayName("E-mail")]
        public string Email { get; set; }
        [DisplayName("Facebook link")]
        public string FbLink { get; set; }
        [DisplayName("Kategoria")]
        public ContactCategories ContactCategory { get; set; }
    }
}
