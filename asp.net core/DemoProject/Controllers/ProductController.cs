using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DemoProject.Common.Models;
using DemoProject.Data.Managers;
using Microsoft.AspNetCore.Mvc;

namespace DemoProject.Controllers
{
    public class ProductController : Controller
    {
        public readonly ProductManager _productManager;

        public ProductController(ProductManager productManager)
        {
            _productManager = productManager;
        }

        [Route("product")]
        [HttpGet]
        public async Task<IEnumerable<ProductModel>> GetAll()
        {
            return await _productManager.GetAllAsync();
        }

        [Route("product/{id}")]
        [HttpGet]
        public async Task<ProductModel> GetById(int id)
        {
            return await _productManager.GetByIdAsync(id);
        }
 
        [Route("product/add")]
        [HttpPost]
        public async Task<ProductModel> Post([FromBody]ProductModel productModel)
        {
            return await _productManager.AddAsync(productModel);
        }

        [Route("product/remove/{id}")]
        [HttpDelete]
        public async Task Delete(int id)
        {
            await _productManager.RemoveAsync(id);
        }
    }
}
