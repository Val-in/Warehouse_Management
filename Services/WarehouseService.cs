using System.Data.Common;
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
        var entity = new DAL.Entities.Warehouse
        {
            Name = warehouse.Name,
            Location = warehouse.Location
        };
        _context.Warehouses.Add(entity);
        _context.SaveChanges();
        warehouse.Id = entity.Id;
    }

    public void UpdateWarehouse(Warehouse warehouse)
    {
        var warehouseDb = _context.Warehouses.Find(warehouse.Id) ?? throw new InvalidOperationException($"Product with id {warehouse.Id} is not found");
        
        warehouseDb.Name = warehouse.Name;
        warehouseDb.Location = warehouse.Location;
        _context.SaveChanges();
    }

    public void DeleteWarehouse(Warehouse warehouse)
    {
        var delWarehouse = _context.Warehouses.Find(warehouse.Id) ?? throw new InvalidOperationException($"Warehouse with id {warehouse.Id} is not found");
        _context.Warehouses.Remove(delWarehouse);
        _context.SaveChanges();
    }

    public List<Warehouse> GetAllWarehouses()
    {
        return _context.Warehouses
            .Select(w => new Warehouse
            {
                Id       = w.Id,
                Name     = w.Name,
                Location = w.Location,
            })
            .ToList();

    }
}