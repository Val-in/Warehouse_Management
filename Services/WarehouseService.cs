using Core.Interfaces;
using Core.Models;
using DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Services;

public class WarehouseService : IWarehouseService
{
    public readonly AppDbContext _context;

    public WarehouseService(AppDbContext context)
    {
        _context = context;
    }

    public void AddWarehouse(Warehouse warehouse)
    {
        var newWarehouse = _context.Warehouses.Find(Id) ?? throw new InvalidOperationException($"Warehouse with id {Id} is not found");
        warehouse.Id = Id;
        _context.SaveChanges();
    }

    public void UpdateWarehouse(Warehouse warehouse)
    {
        var warehouseDb = _context.Warehouses.Find(warehouse.Id) ?? throw new InvalidOperationException($"Product with id {warehouse.Id} is not found");
        
        warehouseDb.Name = warehouse.Name;
        warehouseDb.Location = warehouse.Location;
        warehouseDb.ProductId = warehouse.ProductId;
        warehouseDb.Employees = warehouse.Employees; 
        warehouseDb.Id = warehouse.Id;
        warehouseDb.OrderId = warehouse.OrderId;
        _context.SaveChanges();
    }

    public void DeleteWarehouse(Warehouse warehouse)
    {
        var delWarehouse = _context.Warehouses.Find(Id) ?? throw new InvalidOperationException($"Warehouse with id {Id} is not found");
        _context.Warehouses.Remove(delWarehouse);
        _context.SaveChanges();
    }

    public List<Warehouse> GetAllWarehouses()
    {
        return _context.Warehouses.Include(x => x.Warehouse).ToList();
    }
}