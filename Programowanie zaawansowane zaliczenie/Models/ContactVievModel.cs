using System.ComponentModel;

namespace Programowanie_zaawansowane_zaliczenie.Models
{
    public class ContactVievModel
    {
        string _firstName;
        string _lastName;
        public uint Id { get; set; }
        [DisplayName("Imię")]
        public string FirstName
        {
            get { return _firstName; }
            set { _firstName=(char.ToUpper(value[0]) + value.Substring(1)) ; } 
        }
        [DisplayName("Nazwisko")]
        public string LastName 
        {
            get { return _lastName; }
            set { _lastName = (char.ToUpper(value[0]) + value.Substring(1)); }
        }
        [DisplayName("Adres")]
        public Adresses Adress { get; set; }
        [DisplayName("Nr telefonu")]
        public string PhoneNumber { get; set; }
        [DisplayName("E-mail")]
        public string Email { get; set; }
        [DisplayName("Facebook link")]
        public string FbLink { get; set; }
        [DisplayName("Kategoria")]
        public uint ContactCategoryID { get; set; }
        [DisplayName("Kategoria")]
        public virtual ContactCategories ContactCategory { get; set; }

    }
}
