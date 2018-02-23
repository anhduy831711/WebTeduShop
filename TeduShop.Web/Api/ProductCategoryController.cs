﻿using AutoMapper;
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
        public HttpResponseMessage getAll(HttpRequestMessage request,int page,int pageSize = 20)
        {
            return CreateHttpResponse(request, () =>
             {
                 int totalRow = 0;
                 var model = _productCategorySevice.GetAll();
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
    }
}
