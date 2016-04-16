using Model;
using Model.Models;
using System;
using System.Linq;
using System.Web.Mvc;

namespace Sklep.Controllers
{
    [Authorize]
    public class CheckoutController : Controller
    {
        WebContext storeDB = new WebContext();
        
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Submit()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Submit(FormCollection values)
        {
            var order = new Order();
            TryUpdateModel(order);

            try
            {
                    var cart = ShoppingCart.GetCart(this.HttpContext);
                    order.Username = User.Identity.Name;
                    order.OrderDate = DateTime.Now;
                    order.Total = cart.GetTotal();
                    storeDB.Orders.Add(order);
                    storeDB.SaveChanges();
                    cart.EmptyCart();

                   return RedirectToAction("Complete", new { id = order.OrderId });
         
            }
            catch
            {
                return View(order);
            }
        }

        public ActionResult Complete(int? id)
        {
            var orders = storeDB.Orders.Where(o => o.Username == User.Identity.Name);
            
            if (orders!=null)
            {
                return View(orders);
            }
            else
            {
                return View("Error");
            }
        }    
    }
    }
