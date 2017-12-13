using TeduShop.Data.Infrastructure;
using TeduShop.Model.Models;

namespace TeduShop.Data.Respositories
{
    public interface IPageRespository : IRepository<Page>
    {

    }

    public class PageRespository : RespositoryBase<Page>, IPageRespository
    {
        public PageRespository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}