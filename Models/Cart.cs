using System;
using System.Collections.Generic;
using Store.Data;

#nullable disable

namespace Store.Models
{
    public partial class Cart
    {
        private StoreContext storeContext;

        public Cart()
        {
            CartsItems = new HashSet<CartsItem>();
        }

        public Cart(StoreContext context)
        {
            storeContext = context;    
        }

        public long Id { get; set; }
        public long ClientId { get; set; }


        public virtual Client Client { get; set; }
        public virtual ICollection<CartsItem> CartsItems { get; set; }
    }
}
