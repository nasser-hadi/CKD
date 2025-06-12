using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel;

namespace CKD.Web.ViewModels
{
    public class ProductViewModel
    {
        [DisplayName("Product Code")]
        public string Id { get; set; }
        public int Version { get; set; }
        [DisplayName("Product Name")]
        //[Display(Name="Product Name")]
        public string Name { get; set; }
        [DisplayName("Desciption")]
        public string Notes { get; set; }
        [DisplayName("Engine Type")]
        //public string EngineType { get; set; }
        public int EngineType_Id { get; set; } //= 1;
        [DisplayName("Engine Type")]
        public string? EngineType_Name { get; set; }


        [DisplayName("Engine Type")]
        public IEnumerable<SelectListItem>? EngineTypeSelectList { get; set; }
        public string? Usage { get; set; }
        public string? OldImage { get; set; }
        public string? NewImage { get; set; }
    }
}
