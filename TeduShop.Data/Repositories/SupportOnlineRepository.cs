using TeduShop.Data.Infrastructure;
using TeduShop.Model.Models;

namespace TeduShop.Data.Respositories
{
    public interface ISupportOnlineRespository : IRepository<SupportOnline>
    {

    }
    public class SupportOnlineRespository : RespositoryBase<SupportOnline>, ISupportOnlineRespository
    {
        public SupportOnlineRespository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}