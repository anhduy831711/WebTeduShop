using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TeduShop.Web.Models
{
    public class ProductTagViewModel
    {
        public int ProductId { get; set; }

       
        public string TagID { get; set; }

        
        public virtual ProductTagViewModel Product { get; set; }

       
        public virtual TagViewModel Tag { get; set; }
    }
}