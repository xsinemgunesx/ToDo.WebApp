using Microsoft.EntityFrameworkCore;
using ToDo.WebApp.Models;

namespace ToDo.WebApp.Repository.Implementation;

public class BaseDbContext : DbContext
{
   
    public BaseDbContext(DbContextOptions opt) : base(opt) { }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB; Database=ToDo_Db; Trusted_Connection=true");//true=> güvenli bağlantı
        
    }
    
    public DbSet<Duty> Dutys { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Show> Shows { get; set; }



}
