namespace Programowanie_zaawansowane_zaliczenie.Models
{
    public class ContactVievModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Adresses Adress { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string FbLink { get; set; }
        public ContactCategories ContactCategory { get; set; }
    }
}
