using System;

namespace Nop.Plugin.Widgets.VendorDetails
{
    [Serializable]
    public partial class SellingReport
    {
        /// <summary>
        /// Gets or sets the product identifier
        /// </summary>
        public int ProductId { get; set; }

            /// <summary>
        /// Gets or sets the total quantity
        /// </summary>
        public int TotalQuantity { get; set; }

    }
}
