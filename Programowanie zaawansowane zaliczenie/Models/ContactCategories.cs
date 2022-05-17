using System.ComponentModel;

namespace Programowanie_zaawansowane_zaliczenie.Models
{
    public class ContactCategories
    {
        public int Id { get; set; }
        [DisplayName("Kategoria kontaktów")]
        public string CategoryName { get; set; }
    }
}
