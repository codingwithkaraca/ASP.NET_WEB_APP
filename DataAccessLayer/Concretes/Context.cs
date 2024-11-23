using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Concretes;

public class Context: IdentityDbContext<WriterUser, WriterRole, int>
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // Remote
        //var connectionString = "server=; port=3306; user=alperka5_alper0karaca; password=; database=;";
        
        // local
        var connectionString = "server=localhost;port=3306;user=root;password=;database=CoreProjeDB;";
        
        var serverVersion = new MySqlServerVersion(new Version(8, 0, 21));
        
        optionsBuilder.UseMySql(connectionString, serverVersion);
    }
    
    
    public DbSet<About> Abouts { get; set; }
    public DbSet<Contact> Contacts { get; set; }
    public DbSet<Experience> Experiences { get; set; }
    public DbSet<Feature> Features { get; set; }
    public DbSet<Message> Messages { get; set; }
    public DbSet<Portfolio> Portfolios { get; set; }
    public DbSet<Service> Services { get; set; }
    public DbSet<Skill> Skills { get; set; }
    public DbSet<SocialMedia> SocialMedias { get; set; }
    public DbSet<Testimonial> Testimonials { get; set; }
    public DbSet<TodoList> TodoLists { get; set; }
    public DbSet<Announcement> Announcements { get; set; }
    public DbSet<WriterMessage> WriterMessages { get; set; }


}