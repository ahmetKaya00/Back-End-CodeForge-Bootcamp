using System.ComponentModel.DataAnnotations;

namespace FormApp.Models
{
    public class Product
    {
        [Display(Name = "Urun Id")]
        public int ProductId { get; set; }
        [Display(Name = "Kitap Adi")]
        public string BookName { get; set; } = string.Empty;
        [Display(Name = "Sayfa")]
        public int PageCount { get; set; }
        [Display(Name = "Gorsel")]
        public string Image { get; set; } = string.Empty;
        [Display(Name = "Aktiflik")]
        public bool IsActive {get;set;}
        [Display(Name = "Kategori Id")]
        public int CategoryId { get; set; }
    }
}