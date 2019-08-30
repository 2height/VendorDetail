using Nop.Core.Configuration;

namespace Nop.Plugin.Widgets.VendorDetails
{
    public class VendorDetailsSettings : ISettings
    {
        public bool ShowVendorEmail
        {
            get;
            set;
        }

        public bool ShowVendorPhoneNumer
        {
            get;
            set;
        }
        public bool ShowVendorRating
        {
            get;
            set;
        }

        public bool ShowProductRating
        {
            get;
            set;
        }

        public bool ShowProductSoldCount
        {
            get;
            set;
        }

        public string WidgetZone { get; set; }

        public VendorDetailsSettings()
        {
            this.ShowVendorEmail = false;
            this.ShowVendorPhoneNumer = false;
            this.ShowVendorRating = false;
            this.ShowProductRating = false;
            this.ShowProductSoldCount = false;
        }
    }
}