using Nop.Core;
using Nop.Core.Data;
using Nop.Core.Domain.Catalog;
using Nop.Core.Domain.Customers;
using Nop.Core.Domain.Orders;
using Nop.Plugin.Widgets.VendorDetails.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nop.Plugin.Widgets.VendorDetails.Service
{
   public class CustomersInfo : ICustomersInfo
    {
        private readonly IRepository<Customer> _customerRepository;

        private readonly IRepository<OrderItem> _orderItemRepository; 
        private readonly IRepository<Order> _orderRepository;
        private readonly IRepository<Product> _productRepository;


        public CustomersInfo(IRepository<Customer> customerRepository,
            IRepository<OrderItem> orderItemRepository,
            IRepository<Order> orderRepository,
            IRepository<Product> productRepository)
        {

            this._customerRepository = customerRepository;
            this._orderItemRepository = orderItemRepository;
            this._orderRepository = orderRepository;
            this._productRepository = productRepository;
        }

        public Customer GetCustomerId(int id)
        {

            var query = from tr in _customerRepository.Table where 
                         tr.VendorId == id
                         select tr;
            return query.FirstOrDefault();

        }

        public IList<SellingReport> GetCount(int productId)
        {

            var query1  = from oi in _orderItemRepository.Table
                          join p in _productRepository.Table on oi.ProductId equals p.Id

                          where
                          productId == p.Id
                          select oi;
            var query2 =
               //group by products
               from orderItem in query1
               group orderItem by orderItem.ProductId into g
               select new SellingReport
               {
                   ProductId = g.Key,
                   TotalQuantity = g.Sum(x => x.Quantity),
               }
               ;

           var result = new List<SellingReport>(query2);
             return result;
        }
    }
}
