using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CKD.DataAccess.Models
{
    public class Part
    {
        public string TechNo { get; set; } = null!;

        public int Version { get; set; }

        public string FarsiName { get; set; } = null!;

        public string EnglishName { get; set; } = null!;

        public bool IsSet { get; set; }

    }
}
