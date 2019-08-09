using System.ComponentModel.DataAnnotations;

namespace DemoProject.Data.Entities
{
    public class SimpleKeyEntity
    {
        [Key]
        public long  Id { get; set; }
    }
}