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
using TeduShop.Web.Infrastructure.Extensions;
using System.Web.Script.Serialization;

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
        [HttpGet]
        public HttpResponseMessage getAll(HttpRequestMessage request,string keyword, int page,int pageSize = 20)
        {
            return CreateHttpResponse(request, () =>
             {
                 int totalRow = 0;
                 var model = _productCategorySevice.GetAll(keyword);
                 totalRow = model.Count();
                 var query = model.OrderByDescending(x => x.CreatedDate).Skip(page * pageSize).Take(pageSize);
                 var responseData = Mapper.Map<IEnumerable<ProductCategory>, IEnumerable<ProductCategoryViewModel>>(query);

                 var paginationSet = new PaginationSet<ProductCategoryViewModel>()
                 {
                     Items = responseData,
                     Page = page,
                     TotalCount = totalRow,
                     TotalPage = (int)Math.Ceiling((decimal)totalRow/pageSize)
                 };

                 var response = request.CreateResponse(HttpStatusCode.OK, paginationSet);
                 return response;
             });
        }

        [Route("getallparent")]
        [HttpGet]
        public HttpResponseMessage getAllParent(HttpRequestMessage request)
        {
            return CreateHttpResponse(request, () =>
            {
                var model = _productCategorySevice.GetAll();
                var responseData = Mapper.Map<IEnumerable<ProductCategory>, IEnumerable<ProductCategoryViewModel>>(model);

                var response = request.CreateResponse(HttpStatusCode.OK, responseData);
                return response;
            });
        }

        [Route("getbyid/{id}")]
        [HttpGet]
        public HttpResponseMessage GetById(HttpRequestMessage request,int id)
        {
            return CreateHttpResponse(request, () =>
            {
                var model = _productCategorySevice.GetById(id);
                var responseData = Mapper.Map<ProductCategory, ProductCategoryViewModel>(model);

                var response = request.CreateResponse(HttpStatusCode.OK, responseData);
                return response;
            });
        }

        [Route("create")]
        [HttpPost]
        public HttpResponseMessage Create(HttpRequestMessage request,ProductCategoryViewModel productCategoryVm)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage reponse = null;
                if (!ModelState.IsValid)
                {
                    reponse = request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    var newProductCategory = new ProductCategory();
                    newProductCategory.UpdateProductCategory(productCategoryVm);
                    newProductCategory.CreatedDate = DateTime.Now;
                    _productCategorySevice.Add(newProductCategory);
                    _productCategorySevice.Save();
                    var reposeData = Mapper.Map<ProductCategory, ProductCategoryViewModel>(newProductCategory);
                    reponse = request.CreateResponse(HttpStatusCode.Created, reposeData);
                }
                return reponse;
            });
        }

        [Route("update")]
        [HttpPut]
        public HttpResponseMessage Update(HttpRequestMessage request, ProductCategoryViewModel productCategoryVm)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage reponse = null;
                if (!ModelState.IsValid)
                {
                    reponse = request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    var dbProductCategory = _productCategorySevice.GetById(productCategoryVm.ID);
                    dbProductCategory.UpdateProductCategory(productCategoryVm);
                    dbProductCategory.UpdateDate = DateTime.Now;
                    _productCategorySevice.Update(dbProductCategory);
                    _productCategorySevice.Save();
                    var reposeData = Mapper.Map<ProductCategory, ProductCategoryViewModel>(dbProductCategory);
                    reponse = request.CreateResponse(HttpStatusCode.Created, reposeData);
                }
                return reponse;
            });
        }

        [Route("delete")]
        [HttpDelete]
        public HttpResponseMessage Delete(HttpRequestMessage request, int id)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage reponse = null;
                if (!ModelState.IsValid)
                {
                    reponse = request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    _productCategorySevice.Delete(id);
                    _productCategorySevice.Save();
                    reponse = request.CreateResponse(HttpStatusCode.Created);
                }
                return reponse;
            });
        }

        [Route("deletemulti")]
        [HttpDelete]
        public HttpResponseMessage DeleteMulti(HttpRequestMessage request, string checkedProductCategories)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage reponse = null;
                if (!ModelState.IsValid)
                {
                    reponse = request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    var listProductCategory = new JavaScriptSerializer().Deserialize<List<int>>(checkedProductCategories);
                    foreach(var item in listProductCategory)
                    {
                        _productCategorySevice.Delete(item);
                    }
                    _productCategorySevice.Save();
                    reponse = request.CreateResponse(HttpStatusCode.Created);
                }
                return reponse;
            });
        }
    }
}
