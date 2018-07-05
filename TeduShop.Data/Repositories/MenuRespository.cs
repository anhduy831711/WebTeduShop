using TeduShop.Data.Infrastructure;
using TeduShop.Model.Models;

namespace TeduShop.Data.Respositories
{
    public interface IMenuRespository : IRespository<Menu>
    {

    }
    public class MenuRespository : RespositoryBase<Menu>, IMenuRespository
    {
        public MenuRespository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}