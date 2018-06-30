using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using TeduShop.Data.Infrastructure;
using TeduShop.Model.Models;

namespace TeduShop.Data.Respositories
{
    public interface IMenuGroupRespository : IRespository<MenuGroup>
    {
    }

    public class MenuGroupRespository : RespositoryBase<MenuGroup>, IMenuGroupRespository
    {
        public MenuGroupRespository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}