using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeduShop.Data.Infrastructure;
using TeduShop.MoDel.Models;

namespace TeduShop.Data.Repositories
{
    public interface IErrorRespository : IRespository<Error>
    {

    }
    public class ErrorRespository : RespositoryBase<Error>, IErrorRespository
    {
        public ErrorRespository(IDbFactory dbFactory) : base(dbFactory)
        {
            
        }
    }
}
