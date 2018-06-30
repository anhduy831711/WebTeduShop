using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TeduShop.Web.Models
{
    public class PostViewModel
    {
        public int ID { set; get; }

        public string Name { set; get; }

        public string Alias { set; get; }

        public int CategogyID { set; get; }

      
        public string Image { set; get; }

        public string Descreption { set; get; }

        public string Content { set; get; }

        public bool? HomeFlag { set; get; }
        public int? ViewCount { set; get; }
        public bool? HotFlag { set; get; }

        public virtual PostCategoryViewModel PostCategory { get; set; }

        public DateTime? CreatedDate { set; get; }


        public string CreadedBy { set; get; }

        public DateTime? UpdateDate { set; get; }


        public string UpdateBy { set; get; }

        public string MetaKeyWord { set; get; }

        public string MetaDescription { set; get; }

        public bool Status { get; set; }

        public virtual IEnumerable<PostTagViewModel> PostTags { get; set; }
    }
}