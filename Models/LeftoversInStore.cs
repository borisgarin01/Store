using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Store.Models
{
    public partial class LeftoversInStore
    {
        public long Id { get; set; }
        public long ProductId { get; set; }
        public long StoreId { get; set; }
        [Range(0,int.MaxValue)]public int Quantity { get; set; }

        public virtual Product Product { get; set; }
        public virtual Store Store { get; set; }
    }
}
