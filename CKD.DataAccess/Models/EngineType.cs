using System;

namespace CKD.DataAccess.Models
{
    public class EngineType
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
