using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TeduShop.Model.Models;
using TeduShop.Service;
using TeduShop.Web.Infrastructure.Core;

namespace TeduShop.Web.Api
{
    [RoutePrefix("api/postcategory")]
    public class PostCategoryController : ApiControllerBase
    {
        IPostCategoryService _postCategoryService;
        public PostCategoryController(IErrorService errorService,IPostCategoryService postCategory):base(errorService)
        {
            this._postCategoryService = postCategory;
        }
        
        public HttpResponseMessage Post(HttpRequestMessage request,PostCategory postCategory)
        {
            return CreateHttpResponse(request, () =>
             {
                 HttpResponseMessage reponse=null;
                 if(ModelState.IsValid)
                 {
                     request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                 }
                 else
                 {
                     var category = _postCategoryService.Add(postCategory);
                     _postCategoryService.Save();

                     reponse = request.CreateResponse(HttpStatusCode.Created,category);
                 }
                 return reponse;
             }
            );
        }

        [Route("getall")]
        public HttpResponseMessage Get(HttpRequestMessage request)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage reponse = null;
                if (ModelState.IsValid)
                {
                    request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    var listCategory = _postCategoryService.GetAll();

                    reponse = request.CreateResponse(HttpStatusCode.OK,listCategory);
                }
                return reponse;
            }
            );
        }

        public HttpResponseMessage Put(HttpRequestMessage request, PostCategory postCategory)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage reponse = null;
                if (ModelState.IsValid)
                {
                    request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    _postCategoryService.Update(postCategory);
                    _postCategoryService.Save();

                    reponse = request.CreateResponse(HttpStatusCode.OK);
                }
                return reponse;
            }
            );
        }

        public HttpResponseMessage Delete(HttpRequestMessage request, int id)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage reponse = null;
                if (ModelState.IsValid)
                {
                    request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    var category = _postCategoryService.Delete(id);
                    _postCategoryService.Save();

                    reponse = request.CreateResponse(HttpStatusCode.OK);
                }
                return reponse;
            }
            );
        }
    }
}