using System.Net;
using SachkovTech_Hakaton.WareHouse.Domain.DTOs.Requests.WareHouse;

namespace SachkovTech_Hakaton.WareHouse.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]/[action]")]
    public class WareHouseController : Controller
    {
        private readonly IWareHouseService _wareHouseService;

        public WareHouseController(IWareHouseService wareHouseService)
        {
            _wareHouseService = wareHouseService;
        }

        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(IActionResult), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetAll()
        {
            var warehouses = await _wareHouseService.GetAllAsync();

            if (warehouses is null)
                return BadRequest(Constants.NoValidDataMessage);

            return Ok(warehouses);
        }

        [HttpGet("{id}")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(IActionResult), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetById(int id)
        {
            var warehouse = await _wareHouseService.GetByIdAsync(id);

            return Ok(warehouse);
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(IActionResult), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Create([FromBody] CreateWareHouseDTORequest createWareHouseDTORequest)
        {
            var createdWarehouse = await _wareHouseService.CreateAsync(createWareHouseDTORequest);

            return Ok(createdWarehouse);
        }
        [HttpPut]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(IActionResult), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Update([FromBody] UpdateWareHouseDTORequest updateWareHouseDTORequest)
        {
            await _wareHouseService.UpdateAsync(updateWareHouseDTORequest);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(IActionResult), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Delete(int id)
        {
            await _wareHouseService.DeleteAsync(id);

            return Ok();
        }
        [HttpGet("{id}")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(IActionResult), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetCountOccupancy(int id)
        {
            var countOccurancy = await _wareHouseService.CountOccupancyAsync(id);

            return Ok(countOccurancy);
        }
    }
}
