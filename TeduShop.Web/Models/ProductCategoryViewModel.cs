using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TeduShop.Web.Models
{
    public class ProductCategoryViewModel
    {
        public int ID { set; get; }

        [Required]
        public string Name { set; get; }

        [Required]
        public string Alias { set; get; }

        public int? ParentID { set; get; }

        public string Decription { set; get; }

        public int? DisplayOrder { set; get; }

        public string Image { set; get; }

        public bool? HomeFlag { set; get; }

        public DateTime? CreatedDate { set; get; }

        public string CreadedBy { set; get; }

        public DateTime? UpdateDate { set; get; }

        public string UpdateBy { set; get; }

        public string MetaKeyWord { set; get; }

        public string MetaDescription { set; get; }

        [Required]
        public bool Status { get; set; }
    }
}