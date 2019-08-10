using DemoProject.Common.Models;
using DemoProject.Data.Convertors;
using DemoProject.Data.Db;
using DemoProject.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoProject.Data.Managers
{
    public class ProductManager : BaseDataManager
    {
        public ProductManager(ApplicationContext context) : base(context) { }

        public async Task<ICollection<ProductModel>> GetAllAsync()
        {
            return await _context.Products
                .Select(t => t.Convert())
                .ToListAsync();
        }

        public async Task<ProductModel> GetByIdAsync(long Id)
        {
            return await _context.Products.Where(p => p.Id == Id)
                .Select(t => t.Convert()).FirstOrDefaultAsync();
        }

        public async Task<ProductModel> AddAsync(ProductModel productModel)
        {
            var entity = await _context.Products.Where(p => p.Id == productModel.Id).FirstOrDefaultAsync();

            Product product = productModel.Convert(entity);

            if (entity == null)
                await _context.Products.AddAsync(product);
            else
                _context.Products.Update(product);

            await _context.SaveChangesAsync();
            return await GetByIdAsync(product.Id);
        }

        public async Task RemoveAsync(long Id)
        {
            var entity = await _context.Products.Where(p => p.Id == Id).FirstOrDefaultAsync();

            _context.Products.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}
