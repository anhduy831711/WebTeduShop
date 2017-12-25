using TeduShop.Data.Infrastructure;
using TeduShop.Model.Models;

namespace TeduShop.Data.Respositories
{
    public interface IMenuRespository : IRespository<Menu>
    {

    }
    public class MenuResponsitory : RespositoryBase<Menu>, IMenuRespository
    {
        public MenuResponsitory(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}