

using StockApi.Models;

namespace StockApi.Repositories
{
    public class NewWarehouseRepository : IWarehouseRepository
    {
        private readonly List<Box> _boxes;

        public NewWarehouseRepository ()
        {
            _boxes = new List<Box>
            {
                new Box
                {
                    Id = 4,
                    WeightKg = 5.5,
                    LengthCm = 100,
                    HeightCm = 100,
                    WidthCm = 100,
                    Content = BoxContentType.Pokercards,
                    ItemCount = 10
                },

                new Box
                {
                    Id = 5,
                    WeightKg = 4.2,
                    LengthCm = 70,
                    HeightCm = 80,
                    WidthCm = 100,
                    Content = BoxContentType.Dicecubes,
                    ItemCount = 20
                },

                new Box
                {
                    Id = 6,
                    WeightKg = 4.7,
                    LengthCm = 30,
                    HeightCm = 40,
                    WidthCm = 45,
                    Content = BoxContentType.ToyBuildingBlocks,
                    ItemCount = 15
                }
            };
        }
        

        public IEnumerable<Box> GetAllBoxes()
        {
            return _boxes;
        }

        public void AddBox(Box box)
        {
            _boxes.Add(box); 
        }

        public Box? GetById(int id)
        {
            return _boxes.FirstOrDefault(box => box.Id == id);
        }

        public void DeleteById (int id)
        {
            var itemToRemove = _boxes.FirstOrDefault(box => box.Id == id);
            _boxes.Remove(itemToRemove);
        }
    }
}
