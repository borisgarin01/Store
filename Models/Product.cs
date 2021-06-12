using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Store.Models
{
    public partial class Product
    {
        public Product()
        {
            CartsItems = new HashSet<CartItem>();
            LeftoversInStores = new HashSet<LeftoversInStore>();
            OrdersItems = new HashSet<OrderItem>();
        }

        public long Id { get; set; }
        public int CategoryId { get; set; }
        public int ManufacturerId { get; set; }
        public int ProductKindId { get; set; }
        [Required][StringLength(255)]public string ProductName { get; set; }

        public virtual Category Category { get; set; }
        public virtual Manufacturer Manufacturer { get; set; }
        public virtual ProductKind ProductKind { get; set; }
        public virtual ICollection<CartItem> CartsItems { get; set; }
        public virtual ICollection<LeftoversInStore> LeftoversInStores { get; set; }
        public virtual ICollection<OrderItem> OrdersItems { get; set; }
    }
}
