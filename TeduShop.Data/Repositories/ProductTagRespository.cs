using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeduShop.Data.Infrastructure;
using TeduShop.Model.Models;

namespace TeduShop.Data.Respositories
{
    public interface IProductTagRespository : IRespository<ProductTag>
    {

    }
    public class ProductTagRespository : RespositoryBase<ProductTag>, IProductTagRespository
    {
        public ProductTagRespository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
