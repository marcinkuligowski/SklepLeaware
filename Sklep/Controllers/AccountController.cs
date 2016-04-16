using Model;
using Model.Models;
using System.Linq;
using System.Web.Mvc;
using System.Web.Security;

namespace Sklep.Controllers
{
    public class AccountController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        private void MigrateShopingCart(string userName)
        {
            var cart = ShoppingCart.GetCart(this.HttpContext);

            cart.MigrateCart(userName);
            Session[ShoppingCart.CartSessionKey] = userName;
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(User account)
        {
            if (ModelState.IsValid)
            {
                using (WebContext db = new WebContext())
                {
                    db.userAccount.Add(account);
                    db.SaveChanges();
                }
                ModelState.Clear();
                MigrateShopingCart(account.Username);
                ViewBag.Message = account.FirstName + " " + account.LastName + " Zarejestrowny";
                
            }
            return RedirectToAction("Login");
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(User user, string returnUrl)
        {

            using (WebContext db = new WebContext())
            {
                try
                {
                    var usr = db.userAccount.Single(u => u.Username == user.Username && u.Password == user.Password);
                    MigrateShopingCart(user.Username);
                    Session["UserID"] = user.UserID.ToString();
                    Session["UserName"] = user.Username.ToString();
                    FormsAuthentication.SetAuthCookie(user.Username, false);
                    if (Url.IsLocalUrl(returnUrl) && returnUrl.Length > 1 && returnUrl.StartsWith("/")
                        && !returnUrl.StartsWith("//") && !returnUrl.StartsWith("/\\"))
                    {
                        return Redirect(returnUrl);
                    }
                }
                catch (System.Exception)
                {
                    ModelState.AddModelError("", "UserName or password is wrong");
                    
                }
               
                return View();
            }
        }

        [Authorize]
        public ActionResult SignOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index", "Store");
        }
    }
}