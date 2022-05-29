using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Programowanie_zaawansowane_zaliczenie.Models
{
    public class ContactCategories
    {
        public static List<string> CategoriesGet { get; internal set; }
        public uint Id { get; set; }
        [DataType(DataType.Text)]
        [DisplayName("Nazwa kategorii")]
        public string CategoryName { get; set; }
    }
}
