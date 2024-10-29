using System.ComponentModel.DataAnnotations;

namespace Core_Proje.Areas.Writer.Models;

public class UserLoginVM
{
    [Display(Name = "Kullanıcı Adı")]
    [Required(ErrorMessage = "Kullanıcı Adını Giriniz")]
    public string UserName { get; set; }
    
    [Display(Name = "Şifre")]
    [Required(ErrorMessage = "Şifre Giriniz")]
    public string Password { get; set; }
    
    
}