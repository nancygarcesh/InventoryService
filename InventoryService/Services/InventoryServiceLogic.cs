using InventoryService.Data;
using InventoryService.Models;
using Microsoft.EntityFrameworkCore;

namespace InventoryService.Services
{
    public class InventoryServiceLogic
    {
        private readonly InventoryDbContext _context;

        public InventoryServiceLogic(InventoryDbContext context)
        {
            _context = context;
        }

        public async Task<List<InventoryItem>> GetAllItemsAsync()
        {
            return await _context.InventoryItems.ToListAsync();
        }

        public async Task<InventoryItem?> GetItemByIdAsync(int id)
        {
            return await _context.InventoryItems.FindAsync(id);
        }

        public async Task<InventoryItem> AddItemAsync(InventoryItem item)
        {
            item.Id = 0;//ignorar el id enviado
            _context.InventoryItems.Add(item);
            await _context.SaveChangesAsync();
            return item;
        }

        public async Task<bool> UpdateItemAsync(int id, InventoryItem updatedItem)
        {
            var existingItem = await _context.InventoryItems.FindAsync(id);
            if (existingItem == null) return false;

            //actualizamos campos
            existingItem.Name = updatedItem.Name;
            existingItem.Quantity = updatedItem.Quantity;
            existingItem.Price = updatedItem.Price;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                return false;
            }
            return true;
        }

        public async Task<bool> DeleteItemAsync(int id)
        {
            var existingItem = await _context.InventoryItems.FindAsync(id);
            if (existingItem == null) return false;

            _context.InventoryItems.Remove(existingItem);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}