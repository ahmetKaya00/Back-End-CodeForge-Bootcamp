using System.ComponentModel.DataAnnotations;

namespace FormApp.Models
{
    public class Product
    {
        [Display(Name = "Urun Id")]
        public int ProductId { get; set; }

        [Display(Name = "Kitap Adi")]
        [Required(ErrorMessage = "Kitap Adı Girilmek Zorunda!")]
        [StringLength(100, ErrorMessage ="Kitap Adı Max. 100 karakterden oluşmalıdır.")]
        public string BookName { get; set; } = null!;

        [Required]
        [Display(Name = "Sayfa")]
        [Range(0,1500)]
        public int? PageCount { get; set; }

        [Display(Name = "Gorsel")]
        public string? Image { get; set; } = string.Empty;

        [Display(Name = "Aktiflik")]
        public bool IsActive {get;set;}

        [Display(Name = "Kategori Id")]
        [Required]
        public int? CategoryId { get; set; }
    }
}