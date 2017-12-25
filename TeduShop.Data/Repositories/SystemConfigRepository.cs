using TeduShop.Data.Infrastructure;
using TeduShop.Model.Models;

namespace TeduShop.Data.Respositories
{
    public interface ISystemConfigRespository : IRespository<SystemConfig>
    {

    }
    public class SystemConfigRespository : RespositoryBase<SystemConfig>, ISystemConfigRespository
    {
        public SystemConfigRespository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}