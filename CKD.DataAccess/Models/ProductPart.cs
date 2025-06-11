using System;

namespace CKD.DataAccess.Models
{
    /// <summary>
    /// The ProductParts table refers to the Part List of an Engine.
    /// </summary>
    public class ProductPart
    {
        public string Product_ProductCode { get; set; }
        public string Part_TechNo { get; set; }
        public float Quantity { get; set; }

        public Product Product { get; set; } = null!;
        public Part Part { get; set; } = null!;

    }
}
