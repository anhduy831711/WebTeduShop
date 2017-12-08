using TeduShop.Data.Infrastructure;
using TeduShop.Model.Models;

namespace TeduShop.Data.Respositories
{
    public interface IMenuGroup
    {
    }

    public class MenuGroupRespository : RespositoryBase<MenuGroup>, IMenuGroup
    {
        public MenuGroupRespository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}