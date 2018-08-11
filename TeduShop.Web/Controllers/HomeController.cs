using AutoMapper;
using System.Collections.Generic;
using System.Web.Mvc;
using TeduShop.Model.Models;
using TeduShop.Service;
using TeduShop.Web.Models;

namespace TeduShop.Web.Controllers
{
    public class HomeController : Controller
    {
        private IProductCategoryService _productCategoryService;
        public HomeController(IProductCategoryService productCategoryService)
        {
            this._productCategoryService = productCategoryService;
        }
        public ActionResult Index()
        {
            return View();
        }

        [ChildActionOnly]
        public ActionResult Footer()
        {
            return PartialView();
        }

        [ChildActionOnly]
        public ActionResult Menu()
        {
            var productCategory = _productCategoryService.GetAll();
            var productCategoryViewModels = Mapper.Map<IEnumerable<ProductCategory>, IEnumerable<ProductCategoryViewModel>>(productCategory);
            return PartialView(productCategoryViewModels);
        }
    }
}