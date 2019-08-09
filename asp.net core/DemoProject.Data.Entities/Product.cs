using System;
using System.Collections.Generic;
using System.Text;

namespace DemoProject.Data.Entities
{
    public class Product : SimpleKeyEntity
    {
        public string Name { get; set; }

        public double Price { get; set; }

        public long OrderToProductId { get; set; }
    }
}
