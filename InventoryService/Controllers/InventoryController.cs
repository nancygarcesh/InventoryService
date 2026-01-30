using InventoryService.Models;
using InventoryService.Services;
using Microsoft.AspNetCore.Mvc;

namespace InventoryService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InventoryController : ControllerBase
    {
        private readonly InventoryServiceLogic _service;

        public InventoryController(InventoryServiceLogic service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var items = await _service.GetAllItemsAsync();
            return Ok(items);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var item = await _service.GetItemByIdAsync(id);
            if (item == null)
                return NotFound(new { Message = $"Item con Id {id} no encontrado" });
            return Ok(item);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] InventoryItem item)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var created = await _service.AddItemAsync(item);
            return CreatedAtAction(nameof(Get), new { id = created.Id }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] InventoryItem item)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (id != item.Id)
                return BadRequest(new { Message = "El ID en la URL no coincide con el ID del objeto" });

            var updated = await _service.UpdateItemAsync(id, item);
            if (!updated)
                return NotFound(new { Message = $"No se pudo actualizar: Item con ID {id} no encontrado o modificado por otro usuario" });

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _service.DeleteItemAsync(id);
            if (!deleted)
                return NotFound(new { Message = $"Item con ID {id} no encontrado" });
            return NoContent();
        }
    }
}