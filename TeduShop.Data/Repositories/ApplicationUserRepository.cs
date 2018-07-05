using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeduShop.Data.Infrastructure;
using TeduShop.MoDel.Models;

namespace TeduShop.Data.Repositories
{
    public interface IApplicationUserRespository : IRespository<ApplicationUser>
    {

    }
    public class ApplicationUserRespository : RespositoryBase<ApplicationUser>, IApplicationUserRespository
    {
        public ApplicationUserRespository(IDbFactory dbFactory) :base(dbFactory)
        {

        }
    }
}
