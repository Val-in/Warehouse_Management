namespace DAL;

public interface IAppDbContextFactory
{
    AppDbContext CreateDbContext();
}