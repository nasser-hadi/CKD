using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
