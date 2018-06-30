using TeduShop.Data.Infrastructure;
using TeduShop.Model.Models;

namespace TeduShop.Data.Respositories
{
    public interface IOrderRespository : IRespository<Order>
    {

    }
    public class OrderRespository : RespositoryBase<Order>,IOrderRespository
    {
        public OrderRespository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}