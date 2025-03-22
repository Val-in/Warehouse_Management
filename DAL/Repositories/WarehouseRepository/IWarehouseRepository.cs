using DAL.Entities;

namespace DAL.Repositories;

public interface IWarehouseRepository
{
    void AddWarehouse(Warehouse warehouse);
    void UpdateWarehouse(Warehouse warehouse);
    void DeleteWarehouse(int warehouseId);
    Warehouse GetWarehouseById(int warehouseId); 
    IEnumerable<Warehouse> GetAllWarehouses();
}