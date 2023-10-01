using Microsoft.AspNetCore.Mvc;
using StockApi.Models;
using StockApi.Repositories;

namespace StockApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WarehouseController : ControllerBase
    {
        private readonly ILogger<WarehouseController> _logger;
        private readonly IWarehouseRepository _warehouseRepository;

        public WarehouseController(ILogger<WarehouseController> logger, IWarehouseRepository warehouseRepository)
        {
            _logger = logger;
            _warehouseRepository = warehouseRepository;
        }

        [HttpGet]
        [Route("boxes")]
        public IEnumerable<Box> GetAll()
        {
            return _warehouseRepository.GetAllBoxes();
        }

        [HttpPost]
        [Route("box")]

        public void Post([FromBody] Box inputBox)
        {
            _warehouseRepository.AddBox(inputBox);
        }

        [HttpGet]
        [Route("box/{id}")]

        public Box? GetById([FromRoute] int id)
        {
            return _warehouseRepository.GetById(id);
        }


        [HttpDelete]
        [Route ( "box/{id}" )]
        public void DeleteById ([FromRoute] int id)
        {
            _warehouseRepository.DeleteById(id);
        }

    }
}