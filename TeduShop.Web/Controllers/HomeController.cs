using System.Web.Mvc;

namespace TeduShop.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [ChildActionOnly]
        public ActionResult Footer()
        {
            return PartialView();
        }

        public ActionResult Menu()
        {
            return PartialView();
        }
    }
}