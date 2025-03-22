using Microsoft.EntityFrameworkCore;

namespace DAL;

/*предоставляют механизм для гибкого создания экземпляров DbContext,
 особенно когда нужно учитывать разные конфигурации или особенности взаимодействия с базой данных.*/
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