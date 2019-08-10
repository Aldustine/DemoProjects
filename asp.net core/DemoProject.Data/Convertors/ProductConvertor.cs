using DemoProject.Common.Models;
using DemoProject.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoProject.Data.Convertors
{
    public static class ProductConvertor
    {
        public static Product Convert(this ProductModel model, Product entity)
        {
            if (entity == null)
                entity = new Product { Id = default(long) };
            entity.Name = model.Name;
            entity.Price = model.Price;

            return entity;
        }

        public static ProductModel Convert(this Product entity)
        {
            return new ProductModel
            {
                Id = entity.Id,
                Name = entity.Name,
                Price = entity.Price
            };
        }
        
    }
}
