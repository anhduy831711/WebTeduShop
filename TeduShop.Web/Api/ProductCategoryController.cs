using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TeduShop.Model.Models;
using TeduShop.Service;
using TeduShop.Web.Infrastructure.Core;
using TeduShop.Web.Models;

namespace TeduShop.Web.Api
{
    [RoutePrefix("api/productcategory")]
    public class ProductCategoryController : ApiControllerBase
    {
        IProductCategoryService _productCategorySevice;

        public ProductCategoryController(IErrorService errorService,IProductCategoryService productCategoryService):base(errorService)
        {
            this._productCategorySevice = productCategoryService;
        }

        [Route("getall")]
        public HttpResponseMessage getAll(HttpRequestMessage request)
        {
            return CreateHttpResponse(request, () =>
             {
                 var model = _productCategorySevice.GetAll();
                 var responseData = Mapper.Map<IEnumerable<ProductCategory>, IEnumerable<ProductCategoryViewModel>>(model);
                 var response = request.CreateResponse(HttpStatusCode.OK, responseData);
                 return response;
             });
        }
    }
}
