using System;

namespace CKD.DataAccess.Models
{
    public class ProductPart
    {
        public string Product_ProductCode { get; set; } = null!;
        public string Part_TechNo { get; set; } = null!;
        public float Quantity { get; set; }

        public Product Product { get; set; } = null!;
        public Part Part { get; set; } = null!;
    }
}
