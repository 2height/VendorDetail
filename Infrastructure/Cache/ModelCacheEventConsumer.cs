using Nop.Core.Caching;
using Nop.Core.Domain.Configuration;
using Nop.Core.Events;
using Nop.Services.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nop.Plugin.Widgets.VendorDetails.Infrastructure.Cache
{
    public partial class ModelCacheEventConsumer 
        //IConsumer<EntityInserted<Setting>>,
        //IConsumer<EntityUpdated<Setting>>,
        //IConsumer<EntityDeleted<Setting>>
    {
        /// <summary>
        /// Key for caching
        /// </summary>
        /// <remarks>
        /// {0} : picture id
        /// </remarks>
        public const string VENDOR_DETAILD_IDS_KEY = "Nop.plugins.widgets.VendorDetails.PublicInfo-{0}";
        public const string VENDOR_DETAILS_PATTERN_KEY = "Nop.plugins.widgets.VendorDetails.PublicInfo";

        

        private readonly IStaticCacheManager _cacheManager;

        public ModelCacheEventConsumer(IStaticCacheManager cacheManager)
        {
            this._cacheManager = cacheManager;
        }

        //public void HandleEvent(EntityInserted<Setting> eventMessage)
        //{
        //    _cacheManager.RemoveByPattern(PICTURE_URL_PATTERN_KEY);
        //}
        //public void HandleEvent(EntityUpdated<Setting> eventMessage)
        //{
        //    _cacheManager.RemoveByPattern(PICTURE_URL_PATTERN_KEY);
        //}
        //public void HandleEvent(EntityDeleted<Setting> eventMessage)
        //{
        //    _cacheManager.RemoveByPattern(PICTURE_URL_PATTERN_KEY);
        //}
    }
}
