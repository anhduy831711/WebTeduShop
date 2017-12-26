using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TeduShop.Model.Models;
using TeduShop.Web.Models;

namespace TeduShop.Web.Infrastructure.Extensions
{
    public static class EntityExtensions
    {
        public static void UpdatePostCategory(this PostCategory postCategory, PostCategoryViewModel postCategoryVm)
        {
            postCategory.ID = postCategoryVm.ID;
            postCategory.Name = postCategoryVm.Name;
            postCategory.Alias = postCategoryVm.Alias;
            postCategory.ParentID = postCategoryVm.ParentID;
            postCategory.Decription = postCategoryVm.Decription;
            postCategory.DisplayOrder = postCategoryVm.DisplayOrder;
            postCategory.Image = postCategoryVm.Image;
            postCategory.HomeFlag = postCategoryVm.HomeFlag;
            postCategory.CreatedDate = postCategoryVm.CreatedDate;
            postCategory.CreadedBy = postCategoryVm.CreadedBy;
            postCategory.UpdateDate = postCategoryVm.UpdateDate;
            postCategory.UpdateBy = postCategoryVm.UpdateBy;
            postCategory.MetaKeyWord = postCategoryVm.MetaKeyWord;
            postCategory.MetaDescription = postCategoryVm.MetaDescription;
            postCategory.Status = postCategoryVm.Status;
        }

        public static void UpdatePost(this Post post, PostViewModel postVm)
        {
            post.ID = postVm.ID;
            post.Name = postVm.Name;
            post.Alias = postVm.Alias;
            post.CategogyID = postVm.CategogyID;
            post.Descreption = postVm.Descreption;
            post.Content = postVm.Content;
            post.ViewCount = postVm.ViewCount;
            post.Image = postVm.Image;
            post.HomeFlag = postVm.HomeFlag;
            post.CreatedDate = postVm.CreatedDate;
            post.CreadedBy = postVm.CreadedBy;
            post.UpdateDate = postVm.UpdateDate;
            post.UpdateBy = postVm.UpdateBy;
            post.MetaKeyWord = postVm.MetaKeyWord;
            post.MetaDescription = postVm.MetaDescription;
            post.Status = postVm.Status;
        }

        public static void UpdatePostTag(this PostTag postTag, PostTagViewModel postTagVm)
        {
            postTag.PostID = postTagVm.PostID;
            postTag.TagID = postTagVm.TagID;
        }

        public static void UpdateProductTag(this ProductTag productTag,ProductTagViewModel productTagVm)
        {
            productTag.ProductId = productTagVm.ProductId;
            productTag.TagID = productTagVm.TagID;
        }

        public static void UpdateTag(this Tag tag, TagViewModel tagVm)
        {
            tag.Id = tagVm.Id;
            tag.Name = tagVm.Name;
            tag.Type = tagVm.Type;
        }
    }
}