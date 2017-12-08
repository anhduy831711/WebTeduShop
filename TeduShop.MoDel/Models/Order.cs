using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TeduShop.Model.Models
{
    [Table("Orders")]
    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required]
        [MaxLength(256)]
        public string CustumerName { get; set; }

        [Required]
        [MaxLength(256)]
        public string CustummerAddress { get; set; }

        [Required]
        [MaxLength(256)]
        public string CustumerEmail { get; set; }

        [Required]
        [MaxLength(256)]
        public string CustumnerPhone { get; set; }

        [MaxLength(256)]
        public string CustumerMessage { get; set; }

        public DateTime CreateDate { set; get; }
        public DateTime CreateBy { get; set; }

        [MaxLength(256)]
        public string PaymentMethod { get; set; }

        [MaxLength(256)]
        public string PaymentStatus { get; set; }

        [MaxLength(500)]
        public string Status { get; set; }

        public virtual IEnumerable<OrderDetail> OrderDetails { get; set; }
    }
}