using Core_Proje_Api.DAL.Entity;
using Microsoft.EntityFrameworkCore;

namespace Core_Proje_Api.DAL.ApiContext;

public class Context : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var connectionString = "Server=localhost; Port = 3306; User = root; Database=Core_Proje_ApiDB;";
        var serverVersion = new MySqlServerVersion(new Version(8,0,21));
        
        optionsBuilder.UseMySql(connectionString, serverVersion);
    }
    
    public DbSet<Category> Categories { get; set; }
    
    
}