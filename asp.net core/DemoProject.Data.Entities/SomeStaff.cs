using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;

namespace DemoProject.Data.Entities
{
    public class SomeStaff : SimpleKeyEntity
    {
        public int Age { get; set; }

        public string Name { get; set; }         
    }
}
