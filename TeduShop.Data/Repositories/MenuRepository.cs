using TeduShop.Data.Infrastructure;
using TeduShop.Model.Models;

namespace TeduShop.Data.Respositories
{
    public interface IMenuRespository : IRepository<Menu>
    {

    }
    public class MenuResponsitory : RespositoryBase<Menu>, IMenuRespository
    {
        public MenuResponsitory(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}