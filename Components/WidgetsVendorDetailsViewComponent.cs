using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Nop.Core;
using Nop.Core.Caching;
using Nop.Plugin.Widgets.VendorDetails.Models;
using Nop.Services.Configuration;
using Nop.Services.Media;
using Nop.Web.Framework.Components;
using System;
using Nop.Services.Catalog;
using Nop.Services.Vendors;
using Nop.Core.Domain.Vendors;
using Nop.Core.Domain.Catalog;
using Nop.Services.Seo;
using Nop.Services.Common;
using Nop.Core.Domain.Customers;
using Nop.Services.Customers;
using Nop.Plugin.Widgets.VendorDetails.Service;
using Nop.Services.Orders;
using Nop.Core.Infrastructure;

namespace Nop.Plugin.Widgets.VendorDetails.Components
{
    [ViewComponent(Name = "WidgetsVendorDetails")]
    public class WidgetsVendorDetailsViewComponent : NopViewComponent
    {
        private readonly IStoreContext _storeContext;
        private readonly IStaticCacheManager _cacheManager;
        private readonly ISettingService _settingService;
        private readonly IPictureService _pictureService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IProductService _productService;
        private readonly IVendorService _vendorService;
        private readonly ICustomerService _customerService;
        private readonly ICustomersInfo _customersInfo;


        public WidgetsVendorDetailsViewComponent(IStoreContext storeContext,
             IHttpContextAccessor httpContextAccessor,
             IStaticCacheManager cacheManager,
             ISettingService settingService,
             IProductService productService,
             IVendorService vendorService,
             ICustomersInfo customersInfo,
             ICustomerService customerService,
             IPictureService pictureService)
        {
            this._storeContext = storeContext;
            this._cacheManager = cacheManager;
            this._settingService = settingService;
            this._pictureService = pictureService;
            this._productService = productService;
            this._vendorService = vendorService;
            this._customerService = customerService;
            this._customersInfo = customersInfo;
            this._httpContextAccessor = httpContextAccessor;
        }

        public IViewComponentResult Invoke(string widgetZone, object additionalData)
        {
            IViewComponentResult viewComponent;
            EmptyResult emptyResult = new EmptyResult();

            VendorDetailsSettings VendorDetailsSetting = _settingService.LoadSetting<VendorDetailsSettings>(_storeContext.CurrentStore.Id);

            if (VendorDetailsSetting != null)
            {
                int productId = Convert.ToInt32(additionalData);

                if (productId != 0)
                {

                    var P = _customersInfo.GetCount(productId);
                    Product productById = _productService.GetProductById(productId);
                    
                    if (productById == null ? false : productById.VendorId == 0)
                    {
                        PublicInfoModel yom = new PublicInfoModel();
                        yom.Name = productById.Name;
                        yom.SoldCount = P.Count;
                        PublicInfoModel email1 = yom;
                        viewComponent = base.View("~/Plugins/Widgets.VendorDetails/Views/raw.cshtml", email1);
                    }
                    else if (productById == null ? false : productById.VendorId != 0)
                    {
                        var VendorIds = this._vendorService.GetVendorById(productById.VendorId).Id;
                        var CustomerIds = _customersInfo.GetCustomerId(VendorIds);
                        Vendor vendorById = this._vendorService.GetVendorById(productById.VendorId);
                        PublicInfoModel Model = new PublicInfoModel();
                        //Model.Id(vendorById.get_Id());
                        Model.Name = vendorById.Name;
                        Model.Description = vendorById.Description;
                        //Model.Rating = productById.ApprovedRatingSum;
                        //Model.SoldCount = P.Count;
                        //Model.Phone = CustomerIds.GetAttribute<String>(SystemCustomerAttributeNames.Phone);
                        Model.SeName = SeoExtensions.GetSeName(vendorById);
                        PublicInfoModel email = Model;

                        if (VendorDetailsSetting.ShowVendorEmail)
                        {
                            email.Email = vendorById.Email;
                        }
                        if (VendorDetailsSetting.ShowProductRating)
                        {
                            email.Rating = productById.ApprovedRatingSum;
                        }
                        if (VendorDetailsSetting.ShowProductSoldCount)
                        {
                            email.SoldCount = P.Count;
                        }

                        if (VendorDetailsSetting.ShowVendorPhoneNumer)
                        {
                            email.Phone = CustomerIds.GetAttribute<String>(SystemCustomerAttributeNames.Phone);
                        }


                        viewComponent = base.View("~/Plugins/Widgets.VendorDetails/Views/PublicInfo.cshtml", email);

                    }

                    else
                    {
                        viewComponent = null;
                    }
                }
                else
                {
                    viewComponent = null;
                }
            }
            else
            {
                viewComponent = null;
            }

            return viewComponent;


        }


    }

}

