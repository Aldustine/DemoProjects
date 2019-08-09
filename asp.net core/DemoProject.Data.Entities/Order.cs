using System;
using System.Collections.Generic;
using System.Text;

namespace DemoProject.Data.Entities
{
    public class Order : SimpleKeyEntity
    {
        public long ClientId { get; set; } // Client entity will be add latter

        public string Comment { get; set; }

        public DateTimeOffset Date { get; set; }

        public bool Complete { get; set; }
    }
}
