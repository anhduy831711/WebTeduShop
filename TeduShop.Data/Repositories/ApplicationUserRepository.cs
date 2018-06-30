using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeduShop.Data.Infrastructure;
using TeduShop.MoDel.Models;

namespace TeduShop.Data.Repositories
{
    public interface IApplicationUserRepository : IRespository<ApplicationUser>
    {

    }
    public class ApplicationUserRepository : RespositoryBase<ApplicationUser>, IApplicationUserRepository
    {
        public ApplicationUserRepository(IDbFactory dbFactory) :base(dbFactory)
        {

        }
    }
}
