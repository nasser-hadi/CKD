using System;

namespace CKD.DataAccess.Models
{
    public class ProductPart
    {
        public string Product_ProductCode { get; set; }
        public string Part_TechNo { get; set; }
        public float Qty { get; set; }

        public Product Product { get; set; } = null!;
        public Part Part { get; set; } = null!;

    }
}
