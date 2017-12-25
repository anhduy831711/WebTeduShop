using TeduShop.Data.Infrastructure;
using TeduShop.Model.Models;

namespace TeduShop.Data.Respositories
{
    public interface ISlideRespository : IRespository<Slide>
    {

    }
    public class SlideRespository : RespositoryBase<Slide>, ISlideRespository
    {
        public SlideRespository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}