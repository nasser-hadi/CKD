using System.ComponentModel;

namespace CKD.Web.ViewModels
{
    public class PartViewModel
    {
        [DisplayName("TechNo")]
        public string Id { get; set; } = null!;
        public int Version { get; set; }
        [DisplayName("Farsi Name")]
        public string FarsiName { get; set; } = null!;
        [DisplayName("English Name")]
        public string EnglishName { get; set; } = null!;
        [DisplayName("IsSet")]
        public bool IsSet { get; set; }

        public string FullName
        {
            get
            {
                return $"{Id} - {FarsiName}";
            }
        }
    }
}
