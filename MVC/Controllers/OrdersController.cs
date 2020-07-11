using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC.Models;
using System.Net.Http;

namespace MVC.Controllers
{
    [Authorize]
    public class OrdersController : Controller
    {
        // GET: Orders
        public ActionResult Index()
        {
            IEnumerable<OrderInfo> orderList;
            HttpResponseMessage response = GlobalVariable.WebApiClient.GetAsync("Orders").Result;
            orderList = response.Content.ReadAsAsync<IEnumerable<OrderInfo>>().Result;
            return View(orderList);
        }
        [Authorize(Roles ="Admin")]
        public ActionResult Create(int id=0)
        {
            var status = new List<string> { "Placed", "Approved", "Cancelled", "Delivery", "Completed" };
            ViewBag.Status = status;

            var productName = new List<string> { "Pen", "Pencil", "Ball", "Eraser", "Shoes" };
            ViewBag.ProductName = productName;

            return View(new OrderInfo());
            
        }
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult Create(OrderInfo Objorder)
        {
            HttpResponseMessage response = GlobalVariable.WebApiClient.PostAsJsonAsync("Orders", Objorder).Result;
            
            TempData["Message"] = "Saved Successfully";
            return RedirectToAction("Index");
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int id)
        {
            var status = new List<string> { "Placed", "Approved", "Cancelled", "Delivery", "Completed" };
            ViewBag.Status = status;

            var productName = new List<string> { "Pen", "Pencil", "Ball", "Eraser", "Shoes" };
            ViewBag.ProductName = productName;

            HttpResponseMessage response = GlobalVariable.WebApiClient.GetAsync("Orders/" + id.ToString()).Result;
            return View(response.Content.ReadAsAsync<OrderInfo>().Result);
        }
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(OrderInfo Objorder)
        {
            HttpResponseMessage response = GlobalVariable.WebApiClient.PutAsJsonAsync("Orders/" + Objorder.ID, Objorder).Result;
            TempData["Message"] = "Updated Successfully";
            return RedirectToAction("Index");
        }
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int id)
        {
            HttpResponseMessage response = GlobalVariable.WebApiClient.DeleteAsync("Orders/" + id.ToString()).Result;
            TempData["Message"] = "Deleted Successfully";
            return RedirectToAction("Index");
        }
    }
}