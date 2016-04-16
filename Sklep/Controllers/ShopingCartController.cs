using Model;
using Model.Models;
using Model.ViewModels;
using System.Linq;
using System.Web.Mvc;

namespace Sklep.Controllers
{
    public class ShopingCartController : Controller
    {
        WebContext storeDB = new WebContext();

        public ActionResult Index()
        {
            var cart = ShoppingCart.GetCart(this.HttpContext);

            var viewModel = new ShoppingCartViewModel
            {
                CartItems = cart.GetCartItems(),
                CartTotal = cart.GetTotal()
            };
           
            return View(viewModel);
        }

        public ActionResult AddToCart(int id )
        {
            var addedProduct = storeDB.Products.Single(p=> p.ProductId==id);

            var cart = ShoppingCart.GetCart(this.HttpContext);

            cart.AddToCart(addedProduct);

            return RedirectToAction("index");
        }
      
        public ActionResult RemoveFromCart(int id)
        {
            var removedProduct = storeDB.Products.Single(p => p.ProductId == id);

            var cart = ShoppingCart.GetCart(this.HttpContext);

            cart.RemoveFromCart(removedProduct);

            var viewModel = new ShoppingCartViewModel
            {
                CartItems = cart.GetCartItems(),
                CartTotal = cart.GetTotal()
            };

            return View(viewModel);
        }
    }
}