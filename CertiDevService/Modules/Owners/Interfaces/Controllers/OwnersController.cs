using CertiDevService.Modules.Owners.Domain.Entities;
using CertiDevService.Modules.Owners.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace CertiDevService.Modules.Owners.Interfaces.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OwnersController : ControllerBase
    {
        private readonly OwnerService _service;

        public OwnersController(OwnerService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _service.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var owner = await _service.GetByIdAsync(id);
            if (owner == null) return NotFound();
            return Ok(owner);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Owner owner)
        {
            var created = await _service.CreateAsync(owner);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }
    }
}