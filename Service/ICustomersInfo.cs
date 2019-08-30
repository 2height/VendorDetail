using Nop.Core;
using Nop.Core.Domain.Customers;
using System.Collections.Generic;

namespace Nop.Plugin.Widgets.VendorDetails.Service
{
    public interface ICustomersInfo
    {
         Customer GetCustomerId(int id);

        IList<SellingReport> GetCount(int productId);
    }
}