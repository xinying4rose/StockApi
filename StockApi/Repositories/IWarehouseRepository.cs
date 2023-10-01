using StockApi.Models;

namespace StockApi.Repositories
{
    public interface IWarehouseRepository
    {
        IEnumerable<Box> GetAllBoxes();
        void AddBox(Box box);

        Box? GetById(int id);   

        void DeleteById (int id);
    }
}
