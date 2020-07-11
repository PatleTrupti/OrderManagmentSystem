using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC.Models
{
    public class OrderInfo
    {
        public int ID { get; set; }
        public string CustomerName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public Nullable<int> ProductID { get; set; }
        public string ProductName { get; set; }
        public string Status { get; set; }
        public string ShippingAddress { get; set; }
        public Nullable<int> Quantity { get; set; }
        public string Price { get; set; }
    }
}