using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
