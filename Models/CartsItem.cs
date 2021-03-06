using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Store.Models
{
    public partial class CartsItem
    {
        public long Id { get; set; }
        [Range(1,short.MaxValue)]public short Quantity { get; set; }
        public long ProductId { get; set; }
        public long CartId { get; set; }

        public virtual Cart Cart { get; set; }
        public virtual Product Product { get; set; }
    }
}
