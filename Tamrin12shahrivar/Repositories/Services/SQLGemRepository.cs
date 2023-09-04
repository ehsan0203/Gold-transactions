using Microsoft.AspNetCore.Components.Forms;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using Tamrin12shahrivar.Data;
using Tamrin12shahrivar.Model;
using Tamrin12shahrivar.Model.Dto;
using Tamrin12shahrivar.Repositories.Interface;

namespace Tamrin12shahrivar.Repositories.Services
{
    public class SQLGemRepository : IGemRepository
    {
        private readonly GemDbContext _context;

        public SQLGemRepository(GemDbContext context)
        {
            _context = context;
        }

        public async Task<Gem> CreateAsync(Gem gem)
        {
            await _context.Gems.AddAsync(gem);
            await _context.SaveChangesAsync();
            return gem;
        }

        public async Task<Gem> DeleteByAsync(Guid id)
        {
            var result = await _context.Gems.FirstOrDefaultAsync(x=>x.GemId == id);
                _context.Remove(result);
                await _context.SaveChangesAsync();
                return result;

        }

        public   Task<List<Gem>> GetAllAsync()
        {
            return  _context.Gems.ToListAsync();
            
        }

        public async Task<Gem> GetByIdAsync(Guid id)
        {
            return await _context.Gems.FirstOrDefaultAsync(x => x.GemId == id);
        }

        public async Task<GemProfitDto> ReportAsync()
        {
          var AllGem = await _context.Gems.ToListAsync();
      
            double totalSell = AllGem.Where(x => string.Equals(x.Status, "Sell", StringComparison.OrdinalIgnoreCase)).Average(x => x.Price);//جمع مبلغ فروش
            double totalBuy = AllGem.Where(x => string.Equals(x.Status, "Buy", StringComparison.OrdinalIgnoreCase)).Average(x => x.Price);//جمع مبلغ خرید
            decimal Countsell = AllGem.Where(x => string.Equals(x.Status, "Sell", StringComparison.OrdinalIgnoreCase)).Sum(x => x.Weight);
            decimal Countbuy = AllGem.Where(x => string.Equals(x.Status, "Buy", StringComparison.OrdinalIgnoreCase)).Sum(x => x.Weight);
            decimal inventoryNow = Countbuy - Countsell;

            decimal Inventory =  AllGem.Sum(x => string.Equals(x.Status, "Buy", StringComparison.OrdinalIgnoreCase) ? x.Weight : -x.Weight);//امار انبار

            var result = new GemProfitDto
            {
                PriceSumBuy = ((int)totalBuy) * inventoryNow,
                PriceSumSell = ((int)totalSell) * Countsell,
                WeightSumBuy = Countbuy,
                WeightSumSell = Countsell,
            };
            return result;

        }

        public async Task<Gem> UpdateAsync(Guid Id, Gem gem)
        {
            var result = _context.Gems.FirstOrDefault(x=> x.GemId == Id);
            result.Data = gem.Data;
            result.Weight= gem.Weight;
            result.cutie = gem.cutie;
            result.Price = gem.Price;
            result.Status = gem.Status;
            await _context.SaveChangesAsync();
            return result;
        }
    }
}
