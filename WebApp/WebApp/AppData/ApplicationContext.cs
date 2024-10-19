using Microsoft.EntityFrameworkCore;
using WebApp.Models;

namespace WebApp.AppData;

public class ApplicationContext : DbContext
{
    public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
    {
    }

    public DbSet<AulaModel> Aula { get; set; }
}
