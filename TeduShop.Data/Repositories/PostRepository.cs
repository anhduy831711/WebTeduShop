using System.Collections.Generic;
using System.Linq;
using TeduShop.Data.Infrastructure;
using TeduShop.Model.Models;

namespace TeduShop.Data.Respositories
{
    public interface IPostRespository : IRespository<Post>
    {
        IEnumerable<Post> GetAllByTag(string tag, int pageIndex, int pageSize, out int TotalRow);
    }

    public class PostRespository : RespositoryBase<Post>, IPostRespository
    {
        public PostRespository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        public IEnumerable<Post> GetAllByTag(string tag, int pageIndex, int pageSize, out int TotalRow)
        {
            var entity = from p in DbContext.Posts
                         join pt in DbContext.PostTags
                         on p.ID equals pt.PostID
                         where pt.TagID == tag && p.Status
                         orderby p.CreatedDate descending
                         select p;
            TotalRow = entity.Count();

            entity = entity.Skip((pageIndex - 1) * pageSize).Take(pageSize);

            return entity;
        }
    }
}