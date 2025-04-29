using System;

namespace CKD.DataAccess.Models
{
    public class Product
    {
        public string ProductCode { get; set; } = null!;

        public int ProductVersion { get; set; }

        public string ProductName { get; set; } = null!;

        public string Notes2 { get; set; } = null!;

        public string EngineTypeDesc { get; set; } = null!;

        public DateTime CreateDate { get; set; }

        public int CreateByUserEID { get; set; }

        public virtual ICollection<ProductPart> ProductParts { get; set; } = new List<ProductPart>();

    }
}
