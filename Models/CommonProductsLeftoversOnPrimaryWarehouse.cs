using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Store.Models
{
    public partial class CommonProductsLeftoversOnPrimaryWarehouse
    {
        public long Id { get; set; }
        [Range(1,long.MaxValue)]public long Quantity { get; set; }
        public long ProductId { get; set; }

        public virtual Product Product { get; set; }
    }
}
