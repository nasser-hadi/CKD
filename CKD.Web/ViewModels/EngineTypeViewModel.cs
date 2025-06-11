using System.ComponentModel;

namespace CKD.Web.ViewModels
{
    public class EngineTypeViewModel
    {
        [DisplayName("Engine Type")]
        public string Name { get; set; } = null!;
    }
}
