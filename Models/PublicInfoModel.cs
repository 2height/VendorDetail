using Nop.Web.Framework.Mvc.Models;

namespace Nop.Plugin.Widgets.VendorDetails.Models
{
    public class PublicInfoModel : BaseNopModel
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string MetaKeywords { get; set; }
        public string SeName { get; set; }

        public string Phone { get; set; }
        public int Rating { get; set; }

        public int SoldCount { get; set; }
        public string Email { get; set; }
    }
}