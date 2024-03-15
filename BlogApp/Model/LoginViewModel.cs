using System.ComponentModel.DataAnnotations;

namespace BlogApp.Model
{
    public class LoginViewModel{
        
        [Required]
        [EmailAddress]
        [Display(Name = "Eposta")]
        public string? Email {get;set;}

        [Required]
        [StringLength(10, ErrorMessage ="{0} alanı en az {2} karakter olmalıdır.",MinimumLength =6)]
        [DataType(DataType.Password)]
        [Display(Name = "Parola")]
        public string? Password {get;set;}
    }
}