using Microsoft.EntityFrameworkCore;

namespace DAL;

/* Это позволяет нам создавать новый независимый экземпляр AppDbContext,
 позволяет учитывать разные конфигурации или особенности взаимодействия с БД*/
public class AppDbContextFactory : IAppDbContextFactory
{
    private readonly DbContextOptions<AppDbContext> _options;

    public AppDbContextFactory(DbContextOptions<AppDbContext> options)
    {
        _options = options;
    }

    public AppDbContext CreateDbContext()
    {
        return new AppDbContext(_options);
    }
    
}