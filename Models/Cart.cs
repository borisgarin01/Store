using System;
using System.Collections.Generic;

#nullable disable

namespace Store.Models
{
    public partial class Cart
    {
        public Cart()
        {
            CartsItems = new HashSet<CartsItem>();
        }

        public long Id { get; set; }
        public long ClientId { get; set; }

        public virtual Client Client { get; set; }
        public virtual ICollection<CartsItem> CartsItems { get; set; }
    }
}
