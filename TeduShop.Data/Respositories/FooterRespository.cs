using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeduShop.Data.Infrastructure;
using TeduShop.Model.Models;

namespace TeduShop.Data.Respositories
{
    public interface IFooterRespository
    {

    }
    public class FooterRespository : RespositoryBase<Footer>,IFooterRespository
    {
        public FooterRespository(IDbFactory dbFactory):base(dbFactory)
        {

        }
    }
}
