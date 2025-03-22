using Core.Models;

namespace Core.Interfaces;

public interface IWarehouseService
{
    void AddWarehouse(Warehouse warehouse);
    void UpdateWarehouse(Warehouse warehouse);
    void DeleteWarehouse(Warehouse warehouse);
    List<Warehouse> GetAllWarehouses();

}