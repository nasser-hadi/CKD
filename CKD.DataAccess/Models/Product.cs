using System;

namespace CKD.DataAccess.Models
{
    public class Product
    {
        public string ProductCode { get; set; } = null!;
        public int ProductVersion { get; set; }
        public string ProductName { get; set; } = null!;
        public string Notes { get; set; } = null!;
        //public string EngineTypeDesc { get; set; } = null!;
        public string? Usage { get; set; }
        public string? Image { get; set; }
        public DateTime CreateDate { get; set; }
        public int CreateByUserEID { get; set; }

        public virtual ICollection<ProductPart> ProductParts { get; set; } = new List<ProductPart>();

        public int EngineType_Id { get; set; }
        public EngineType EngineType { get; set; } = null!;

    }
}
