using System.ComponentModel.DataAnnotations;

namespace EntityLayer.Concrete;

public class About
{
    [Key]
    public int AboutID { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string Age { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string Address { get; set; }
    public string ImageUrl { get; set; }
}