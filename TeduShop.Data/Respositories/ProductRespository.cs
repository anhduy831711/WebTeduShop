using TeduShop.Data.Infrastructure;
using TeduShop.Model.Models;

namespace TeduShop.Data.Respositories
{
    public interface IProductRespository
    {
    }

    public class ProductRespository : RespositoryBase<Product>, IProductRespository
    {
        public ProductRespository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}