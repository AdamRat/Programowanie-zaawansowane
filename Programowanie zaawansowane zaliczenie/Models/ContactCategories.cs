using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Programowanie_zaawansowane_zaliczenie.Models
{
    public class ContactCategories
    {
        string _categoryName;
        [Key]
        public uint Id { get; set; }
        [DataType(DataType.Text)]
        [DisplayName("Nazwa kategorii")]
        public string CategoryName 
        {
            get { return _categoryName; }
            set { _categoryName = (char.ToUpper(value[0]) + value.Substring(1)); }
        }
    }
}
