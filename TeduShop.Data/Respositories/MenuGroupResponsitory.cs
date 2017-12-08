using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeduShop.Data.Infrastructure;
using TeduShop.Model.Models;

namespace TeduShop.Data.Respositories
{
    public interface IMenuGroup
    {

    }
    public class MenuGroupResponsitory : RespositoryBase<MenuGroup>, IMenuGroup
    {
        public MenuGroupResponsitory(IDbFactory dbFactory):base(dbFactory)
        {

        }
    }
}
