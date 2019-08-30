using System.ComponentModel.DataAnnotations;
using Nop.Web.Framework.Mvc.ModelBinding;
using Nop.Web.Framework.Mvc.Models;

namespace Nop.Plugin.Widgets.VendorDetails.Models
{
    public class ConfigurationModel : BaseNopModel
    {
        public int ActiveStoreScopeConfiguration { get; set; }

        [NopResourceDisplayName("Plugins.Widgets.VendorDetails.ShowVendorPhoneNumer")]
        public bool ShowVendorPhoneNumer { get; set; }
        public bool ShowVendorPhoneNumer_OverrideForStore { get; set; }


        [NopResourceDisplayName("Plugins.Widgets.VendorDetails.ShowVendorRating")]
        public bool ShowVendorRating { get; set; }
        public bool ShowVendorRating_OverrideForStore { get; set; }


        [NopResourceDisplayName("Plugins.Widgets.VendorDetails.ShowProductSoldCount")]
        public bool ShowProductSoldCount { get; set; }
        public bool ShowProductSoldCount_OverrideForStore { get; set; }



        [NopResourceDisplayName("Plugins.Widgets.VendorDetails.ShowProductRating")]
        public bool ShowProductRating { get; set; }
        public bool ShowProductRating_OverrideForStore { get; set; }


        [NopResourceDisplayName("Plugins.Widgets.VendorDetails.ShowVendorEmail")]
        public bool ShowVendorEmail { get; set; }
        public bool ShowVendorEmail_OverrideForStore { get; set; }
    }
}