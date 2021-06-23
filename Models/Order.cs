using System;
using System.Collections.Generic;

#nullable disable

namespace Store.Models
{
    public partial class Order
    {
        public Order()
        {
            OrdersItems = new HashSet<OrdersItem>();
        }

        public long Id { get; set; }
        public DateTime OrderingDate { get; set; }
        public long ClientAddressId { get; set; }

        public virtual ClientsAddress ClientAddress { get; set; }
        public virtual ICollection<OrdersItem> OrdersItems { get; set; }
    }
}
