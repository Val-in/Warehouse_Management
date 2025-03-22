using DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories;

public class WarehouseRepository : IWarehouseRepository
{
    private readonly AppDbContext _context;

    public WarehouseRepository(AppDbContext context)
    {   
        _context = context;
    }

    public void AddWarehouse(Warehouse warehouse)
    {
        _context.Warehouses.Add(warehouse);
        _context.SaveChanges();
    }
    
    public void UpdateWarehouse(Warehouse warehouse)
    {
        if (warehouse != null)
        {
            _context.Warehouses.Update(warehouse);
            _context.SaveChanges();
        }
    }
    
    public void DeleteWarehouse(int id)
    {
        var warehouse = _context.Warehouses.Find(id);
        if (warehouse != null)
        {
           _context.Warehouses.Remove(warehouse);
           _context.SaveChanges();
        }
    }
    
    public Warehouse GetWarehouseById(int id)
    {
        return _context.Warehouses.Include(i => i.Products).FirstOrDefault(w => w.Id == id);
    }
    
    public IEnumerable<Warehouse> GetAllWarehouses()
    {
        return _context.Warehouses.Include(i => i.Products).ToList();
    }
}