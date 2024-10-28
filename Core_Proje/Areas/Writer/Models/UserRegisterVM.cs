using System.ComponentModel.DataAnnotations;

namespace Core_Proje.Areas.Writer.Models;

public class UserRegisterVM
{
    [Required(ErrorMessage = "Lütfen Kullanıcı Adı Girin")] 
    public string UserName { get; set; }
    
    [Required(ErrorMessage = "Lütfen Şifre Girin")] 
    public string Password { get; set; }
    
    [Required(ErrorMessage = "Lütfen Şifrenizi Tekrar Girin")]
    [Compare("Password",ErrorMessage = "Şifreler uyumlu değil ")]
    public string ConfirmPassword { get; set; }
    
    [Required(ErrorMessage = "Lütfen Mail Girin")] 
    public string Mail { get; set; }
    
}