using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace WebAPI.Models
{
    public class OrderServices
    {

        public List<Order> GetOrder()
        {
            using (OrderManagmentDBEntities2 _db = new OrderManagmentDBEntities2())
            {
                var rec = (from or in _db.Orders
                           join pr in _db.Products on or.ProductID equals pr.ID
                           select new Order()
                           {
                               ID = or.ID,
                               CustomerName = or.CustomerName,
                               Email = or.Email,
                               Phone = or.Phone,
                               //ProductID=or.ProductID,
                               ProductName = pr.ProductName,
                               Status = or.Status,
                               ShippingAddress = or.ShippingAddress,
                               Quantity = or.Quantity,
                               Price=or.Price

                           }).ToList();
                return rec ;

            }
        }
    }
}