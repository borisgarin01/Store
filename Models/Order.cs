using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Store.Models
{
    public partial class Order
    {
        public Order()
        {
            OrdersItems = new HashSet<OrderItem>();
        }

        public long Id { get; set; }
        public long ClientAddressId { get; set; }
        public DateTime OrderingDate { get; set; }
        [Required]public bool? IsCompleted { get; set; }

        public virtual ICollection<OrderItem> OrdersItems { get; set; }
    }
}
