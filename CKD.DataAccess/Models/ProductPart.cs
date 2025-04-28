using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CKD.DataAccess.Models
{
    // Step 1-1:
    // Create ProductPart class with two properties as foreign key.
    public class ProductPart
    {
        // Step 1-2:
        public string Product_ProductCode { get; set; } = null!;
        public string Part_TechNo { get; set; } = null!;
        public float Quantity { get; set; }
    }
}
