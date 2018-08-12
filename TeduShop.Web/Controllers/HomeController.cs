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
        private IProductService _productService;
        private ICommonService _commonService;
        
        public HomeController(IProductCategoryService productCategoryService, ICommonService commonService, IProductService productService)
        {
            this._productCategoryService = productCategoryService;
            this._commonService = commonService;
            this._productService = productService;
        }
        public ActionResult Index()
        {
            IEnumerable<Slide> listSlide = _commonService.GetAllSlide();
            IEnumerable<Product> listHotProduct = _productService.GetHotProduct(3);
            IEnumerable<Product> listLastProduct = _productService.GetLastProduct(3);
            var listSlideViewModel = Mapper.Map<IEnumerable<Slide>, IEnumerable<SlideViewModel>>(listSlide);
            var listHotProductModel = Mapper.Map<IEnumerable<Product>, IEnumerable<ProductViewModel>>(listHotProduct);
            var listLastProductModel = Mapper.Map<IEnumerable<Product>, IEnumerable<ProductViewModel>>(listLastProduct);
            HomeViewModel homeViewModel = new HomeViewModel()
            {
                Slides = listSlideViewModel,
                HotProducts = listHotProductModel,
                LastestProducts = listLastProductModel
            };
            return View(homeViewModel);
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