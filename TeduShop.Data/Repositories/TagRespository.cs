using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeduShop.Data.Infrastructure;
using TeduShop.Model.Models;

namespace TeduShop.Data.Respositories
{
    public interface ITagRespository : IRespository<Tag>
    {

    }
    public class TagRespository : RespositoryBase<Tag>, ITagRespository
    {
        public TagRespository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
