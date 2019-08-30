using Microsoft.AspNetCore.Mvc;
using Nop.Core;
using Nop.Services.Configuration;
using Nop.Services.Localization;
using Nop.Services.Security;
using Nop.Services.Stores;
using Nop.Web.Framework;
using Nop.Web.Framework.Controllers;
using Nop.Core.Domain.Catalog;
using Nop.Services.Catalog;
using Nop.Services.Vendors;
using Nop.Plugin.Widgets.VendorDetails.Models;

namespace Nop.Plugin.Widgets.VendorDetails.Controllers
{
    [Area(AreaNames.Admin)]
    public class WidgetsVendorDetailsController : BasePluginController
    {
       
        private readonly IPermissionService _permissionService;
        private readonly IVendorService _vendorService;
        private readonly IWorkContext _workContext;
        private readonly IProductService _productService;
        private readonly CatalogSettings _catalogSettings;
        private readonly ISettingService _settingService;
        private readonly IStoreService _storeService;
        private readonly ILocalizationService _localizationService;
        private readonly VendorDetailsSettings _vendorDetailsSettings;

        public WidgetsVendorDetailsController(IWorkContext workContext,            
            IPermissionService permissionService,
            IVendorService vendorService,
            IProductService productService,
            CatalogSettings catalogSettings,
            ISettingService settingService,
            IStoreService storeService,
            ILocalizationService localizationService,
            VendorDetailsSettings vendorDetailsSettings
           )
        {
            
            this._permissionService = permissionService;
            this._vendorService = vendorService;
            this._workContext = workContext;
            this._productService = productService;
            this._catalogSettings = catalogSettings;
            this._settingService = settingService;
            this._storeService = storeService;
            this._vendorDetailsSettings = vendorDetailsSettings;
            this._localizationService = localizationService;

        }

        public IActionResult Configure()
        {
            if (!_permissionService.Authorize(StandardPermissionProvider.ManageWidgets))
                return AccessDeniedView();

            //load settings for a chosen store scope
            var storeScope = this.GetActiveStoreScopeConfiguration(_storeService, _workContext);
            var vendorDetailsSettings = _settingService.LoadSetting<VendorDetailsSettings>(storeScope);
            var model = new ConfigurationModel();
            model.ShowVendorPhoneNumer = vendorDetailsSettings.ShowVendorPhoneNumer;
            model.ShowVendorRating = vendorDetailsSettings.ShowVendorRating;
            model.ShowVendorEmail = vendorDetailsSettings.ShowVendorEmail;
            model.ShowProductSoldCount = vendorDetailsSettings.ShowProductSoldCount;
            model.ShowProductRating = vendorDetailsSettings.ShowProductRating;
            model.ActiveStoreScopeConfiguration = storeScope;

            if (storeScope > 0)
            {
                model.ShowVendorPhoneNumer_OverrideForStore = _settingService.SettingExists(vendorDetailsSettings, x => x.ShowVendorPhoneNumer, storeScope);
                model.ShowVendorRating_OverrideForStore = _settingService.SettingExists(vendorDetailsSettings, x => x.ShowVendorRating, storeScope);
                model.ShowVendorEmail_OverrideForStore = _settingService.SettingExists(vendorDetailsSettings, x => x.ShowVendorEmail, storeScope);
                model.ShowProductSoldCount_OverrideForStore = _settingService.SettingExists(vendorDetailsSettings, x => x.ShowProductSoldCount, storeScope);
                model.ShowProductRating_OverrideForStore = _settingService.SettingExists(vendorDetailsSettings, x => x.ShowProductRating, storeScope);

            }

            return View("~/Plugins/Widgets.VendorDetails/Views/Configure.cshtml", model);
        }

        [HttpPost]
        public IActionResult Configure(ConfigurationModel model)
        {
            if (!_permissionService.Authorize(StandardPermissionProvider.ManageWidgets))
                return AccessDeniedView();

            //load settings for a chosen store scope
            var storeScope = this.GetActiveStoreScopeConfiguration(_storeService, _workContext);
            var settings = _settingService.LoadSetting<VendorDetailsSettings>(storeScope);

            //get previous picture identifiers
            settings.ShowVendorPhoneNumer = model.ShowVendorPhoneNumer;
            settings.ShowVendorRating = model.ShowVendorRating;
            settings.ShowVendorEmail = model.ShowVendorEmail;
            settings.ShowProductRating = model.ShowProductRating;
            settings.ShowProductSoldCount = model.ShowProductSoldCount;


            if (model.ShowVendorPhoneNumer_OverrideForStore || (storeScope == 0))
            {
                _settingService.SaveSetting(settings, x => x.ShowVendorPhoneNumer, storeScope, false);
            }
            else if (storeScope > 0)
            {
                _settingService.DeleteSetting(settings, x => x.ShowVendorPhoneNumer, storeScope);
            }

            if (model.ShowVendorRating_OverrideForStore || (storeScope == 0))
            {
                _settingService.SaveSetting(settings, x => x.ShowVendorRating, storeScope, false);
            }
            else if (storeScope > 0)
            {
                _settingService.DeleteSetting(settings, x => x.ShowVendorRating, storeScope);
            }
            if (model.ShowVendorEmail_OverrideForStore || (storeScope == 0))
            {
                _settingService.SaveSetting(settings, x => x.ShowVendorEmail, storeScope, false);
            }
            else if (storeScope > 0)
            {
                _settingService.DeleteSetting(settings, x => x.ShowVendorEmail, storeScope);
            }


            if (model.ShowProductRating_OverrideForStore || (storeScope == 0))
            {
                _settingService.SaveSetting(settings, x => x.ShowProductRating, storeScope, false);
            }
            else if (storeScope > 0)
            {
                _settingService.DeleteSetting(settings, x => x.ShowProductRating, storeScope);
            }

            if (model.ShowProductSoldCount_OverrideForStore || (storeScope == 0))
            {
                _settingService.SaveSetting(settings, x => x.ShowProductSoldCount, storeScope, false);
            }
            else if (storeScope > 0)
            {
                _settingService.DeleteSetting(settings, x => x.ShowProductSoldCount, storeScope);
            }
            
            _settingService.ClearCache();
            
            SuccessNotification(_localizationService.GetResource("Admin.Plugins.Saved"));
            return Configure();
        }

        //[NonAction]
        //public int GetCurrentId()
        //{
        //    var httpAccessor = EngineContext.Current.Resolve<IHttpContextAccessor>();

        //    var ms = httpAccessor.HttpContext.Request.QueryString;

        //    var ParsedQueryString = Microsoft.AspNetCore.WebUtilities.QueryHelpers.ParseQuery(ms.Value);

        //    var id = Convert.ToInt32(ParsedQueryString["id"]);

        //    return id;
        //}
    }
}