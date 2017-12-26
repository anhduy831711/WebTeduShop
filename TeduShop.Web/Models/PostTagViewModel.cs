using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TeduShop.Web.Models
{
    public class PostTagViewModel
    {
        public int PostID { set; get; }

        public string TagID { set; get; }

        public virtual PostViewModel Posts { get; set; }

        public virtual TagViewModel Tags { get; set; }
    }
}