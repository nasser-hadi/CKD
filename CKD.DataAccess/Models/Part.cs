using System;

namespace CKD.DataAccess.Models
{
    public class Part
    {
        public string TechNo { get; set; } = null!;

        public int Version { get; set; }

        public string FarsiName { get; set; } = null!;

        public string EnglishName { get; set; } = null!;

        public bool IsSet { get; set; }

        public virtual ICollection<ProductPart> ProductParts { get; set; } = new List<ProductPart>();

    }
}
