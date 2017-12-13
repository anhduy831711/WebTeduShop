using TeduShop.Data.Infrastructure;
using TeduShop.Model.Models;

namespace TeduShop.Data.Respositories
{
    public interface IPostCategoryRespository :IRepository<PostCategory>
    {

    }
    public class PostCategoryRespository : RespositoryBase<PostCategory>, IPostCategoryRespository
    {
        public PostCategoryRespository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}