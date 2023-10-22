using Microsoft.AspNetCore.Mvc;
using BootCamp.FirstWebApi.Data;
using BootCamp.FirstWebApi.Models;
using BootCamp.FirstWebApi.Services;

namespace FirstWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShippersController : ControllerBase
    {
        private readonly IShipperService _shipperService;
        public ShippersController(IShipperService shipperService)
        {
            _shipperService = shipperService;
        }

        // GET: api/Shippers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Shipper>>> GetShippers()
        {
            return await _shipperService.GetAllAsync();
        }

        // GET: api/Shippers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Shipper>> GetShipper(int id)
        {

            var shipper = await _shipperService.GetByIdAsync(id);

            if (shipper == null)
            {
                return NotFound();
            }

            return shipper;
        }

        // PUT: api/Shippers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutShipper(int id, Shipper shipper)
        {
            if (id != shipper.ShipperId)
            {
                return BadRequest();
            }

            var result = await _shipperService.UpdateAsync(shipper);
            return Ok(result);
        }

        // POST: api/Shippers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Shipper>> PostShipper(Shipper shipper)
        {
            await _shipperService.AddAsync(shipper);
            return CreatedAtAction("GetShipper", new { id = shipper.ShipperId }, shipper);
        }

        // DELETE: api/Shippers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteShipper(int id)
        {

            // var shipper = await _shipperService.GetByIdAsync(id);
            // if (shipper == null)
            // {
            //     return NotFound();
            // }

            await _shipperService.DeleteAsync(id);

            return NoContent();
        }
    }
}
