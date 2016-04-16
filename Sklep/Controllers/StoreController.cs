using System.Linq;
using System.Web.Mvc;
using Model;

namespace Sklep.Controllers
{
    public class StoreController : Controller
    {
        WebContext storeDB = new WebContext();

        public ActionResult Index()
        {
            var categories = storeDB.Categories.ToList();
            return View(categories);
        }

        public ActionResult Details(int id)
        {
            
            var product = storeDB.Products.Find(id);
            return View(product);
        }

        public ActionResult Browse(string item)
        {
            var categoryModel = storeDB.Categories.Include("Products").Single(x => x.Name == item);
            return View(categoryModel);
        }

    }
}