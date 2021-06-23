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
            CartsItems = new HashSet<CartsItem>();
            CommonProductsLeftoversOnPrimaryWarehouses = new HashSet<CommonProductsLeftoversOnPrimaryWarehouse>();
            LeftoversInStores = new HashSet<LeftoversInStore>();
            OrdersItems = new HashSet<OrdersItem>();
        }

        public long Id { get; set; }
        [Required][StringLength(255)]public string ProductName { get; set; }
        [Range(0,double.MaxValue)]public double Price { get; set; }
        public long CategoryId { get; set; }
        public long ManufacturerId { get; set; }
        public long ProductKindId { get; set; }

        public virtual Category Category { get; set; }
        public virtual Manufacturer Manufacturer { get; set; }
        public virtual ProductsKind ProductKind { get; set; }
        public virtual ICollection<CartsItem> CartsItems { get; set; }
        public virtual ICollection<CommonProductsLeftoversOnPrimaryWarehouse> CommonProductsLeftoversOnPrimaryWarehouses { get; set; }
        public virtual ICollection<LeftoversInStore> LeftoversInStores { get; set; }
        public virtual ICollection<OrdersItem> OrdersItems { get; set; }
    }
}
