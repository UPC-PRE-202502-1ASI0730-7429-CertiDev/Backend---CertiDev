using Microsoft.AspNetCore.Mvc;
using CertiDevService.Modules.Buyers.Application.Services;
using CertiDevService.Modules.Buyers.Domain.Entities;

namespace CertiDevService.Modules.Buyers.Interfaces.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BuyersController : ControllerBase
    {
        private readonly BuyerService _service;

        public BuyersController(BuyerService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var buyers = await _service.GetAllAsync();
            return Ok(buyers);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var buyer = await _service.GetByIdAsync(id);
            if (buyer == null) return NotFound();
            return Ok(buyer);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Buyer buyer)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var created = await _service.CreateAsync(buyer);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }
    }
}