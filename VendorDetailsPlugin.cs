using System.Collections.Generic;
using Nop.Core;
using Nop.Core.Plugins;
using Nop.Services.Cms;
using Nop.Services.Configuration;
using Nop.Services.Localization;
using Nop.Services.Catalog;
using Nop.Services.Vendors;
using Nop.Services.Customers;
using Nop.Services.Stores;

namespace Nop.Plugin.Widgets.VendorDetails
{
    /// <summary>
    /// PLugin
    /// </summary>
    public class VendorDetailsPlugin : BasePlugin, IWidgetPlugin
    {
   
        private readonly ISettingService _settingService;
        private readonly IWebHelper _webHelper;


        private readonly IWorkContext _workContext;
        private readonly IVendorService _vendorService;
        //private readonly IProductService _productService;
        private readonly ICustomerService _customerService;
        private readonly IStoreService _storeService;
        private readonly VendorDetailsSettings _vendorDetailsSettings;


        public VendorDetailsPlugin(
            IVendorService vendorService,
            IWorkContext workContext,
            ISettingService settingService,
            IStoreService storeService,
            VendorDetailsSettings vendorDetailsSettings,
            ICustomerService customerService,
            IWebHelper webHelper
            )
        {

            this._vendorService = vendorService;
            this._workContext = workContext;
            this._settingService = settingService;
            this._storeService = storeService;
            this._customerService = customerService;
            this._vendorDetailsSettings = vendorDetailsSettings;
            this._webHelper = webHelper;

        }


       
        /// <summary>
        /// Gets widget zones where this widget should be rendered
        /// </summary>
        /// <returns>Widget zones</returns>
    
        public IList<string> GetWidgetZones()
        {
            return new List<string> { "productdetails_overview_top" };
        }

        /// <summary>
        /// Gets a configuration page URL
        /// </summary>
        public override string GetConfigurationPageUrl()
        {
            return _webHelper.GetStoreLocation() + "Admin/WidgetsVendorDetails/Configure";
        }

        /// <summary>
        /// Gets a view component for displaying plugin in public store
        /// </summary>
        /// <param name="widgetZone">Name of the widget zone</param>
        /// <param name="viewComponentName">View component name</param>
        public void GetPublicViewComponent(string widgetZone, out string viewComponentName)
        {
            viewComponentName = "WidgetsVendorDetails";
        }

        /// <summary>
        /// Install plugin
        /// </summary>
        public override void Install()
        {
            base.Install();

            this.AddOrUpdatePluginLocaleResource("Plugins.Widgets.VendorDetails.ShowVendorPhoneNumer", "Show Vendors Phone Number");
            this.AddOrUpdatePluginLocaleResource("Plugins.Widgets.VendorDetails.ShowVendorRating", "Show Vendors Ratting");
            this.AddOrUpdatePluginLocaleResource("Plugins.Widgets.VendorDetails.ShowProductSoldCount", "Show Products Sold Count");
            this.AddOrUpdatePluginLocaleResource("Plugins.Widgets.VendorDetails.ShowProductRating", "Show Product Ratting");
            this.AddOrUpdatePluginLocaleResource("Plugins.Widgets.VendorDetails.ShowVendorEmail", "Show Vendors Email");
            this.AddOrUpdatePluginLocaleResource("Plugins.Widgets.VendorDetails.VendorName", "Sold By");
            this.AddOrUpdatePluginLocaleResource("Plugins.Widgets.VendorDetails.Phone", "Vendor Phone Number");
            this.AddOrUpdatePluginLocaleResource("Plugins.Widgets.VendorDetails.Ratting", "Product Ratting");
            this.AddOrUpdatePluginLocaleResource("Plugins.Widgets.VendorDetails.Sold", "SOLD");
            this.AddOrUpdatePluginLocaleResource("Plugins.Widgets.VendorDetails.VendorEmail", "Vendor Email");
            this.AddOrUpdatePluginLocaleResource("Plugins.Widgets.VendorDetails.Heading", "Product Details");
            this.AddOrUpdatePluginLocaleResource("Plugins.Widgets.VendorDetails.PluginInformation", "Configure Vendor Details Plugin");



        }

        public override void Uninstall()
        {
            _settingService.DeleteSetting<VendorDetailsSettings>();

            //locales
            this.DeletePluginLocaleResource("Plugins.Widgets.VendorDetails.ShowVendorPhoneNumer");
            this.DeletePluginLocaleResource("Plugins.Widgets.VendorDetails.ShowVendorRating");
            this.DeletePluginLocaleResource("Plugins.Widgets.VendorDetails.ShowProductSoldCount");
            this.DeletePluginLocaleResource("Plugins.Widgets.VendorDetails.ShowProductRating");
            this.DeletePluginLocaleResource("Plugins.Widgets.VendorDetails.ShowVendorEmail");
            this.DeletePluginLocaleResource("Plugins.Widgets.VendorDetails.VendorName");
            this.DeletePluginLocaleResource("Plugins.Widgets.VendorDetails.Phone");
            this.DeletePluginLocaleResource("Plugins.Widgets.VendorDetails.Ratting");
            this.DeletePluginLocaleResource("Plugins.Widgets.VendorDetails.Sold");
            this.DeletePluginLocaleResource("Plugins.Widgets.VendorDetails.Heading");
            this.DeletePluginLocaleResource("Plugins.Widgets.VendorDetails.PluginInformation");

            base.Uninstall();
        }

        /// <summary>
        /// Uninstall plugin
        /// </summary>

    }
}