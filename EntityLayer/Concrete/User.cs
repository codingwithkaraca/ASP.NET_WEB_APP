using System.ComponentModel.DataAnnotations;

namespace EntityLayer.Concrete;

public class User
{
    [Key]
    public int UserID { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string UserName { get; set; }
    public string Mail { get; set; }
    public string Password { get; set; }
    public string ImageURL { get; set; }
    public bool Status { get; set; }
    
    public List<UserMessage> UserMessages { get; set; }
    
    
    
}