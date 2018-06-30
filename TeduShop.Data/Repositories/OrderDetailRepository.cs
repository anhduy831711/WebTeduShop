using TeduShop.Data.Infrastructure;
using TeduShop.Model.Models;

namespace TeduShop.Data.Respositories
{
    public interface IOrderDetailRespository : IRespository<OrderDetail>
    {

    }
    public class OrderDetailRespository : RespositoryBase<OrderDetail>, IOrderDetailRespository
    {
        public OrderDetailRespository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}