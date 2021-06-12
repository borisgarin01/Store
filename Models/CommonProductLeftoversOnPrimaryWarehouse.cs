using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Store.Models
{
    public partial class CommonProductLeftoversOnPrimaryWarehouse
    {
        public long Id { get; set; }
        public long ProductId { get; set; }
        [Range(0,long.MaxValue)]public long Quantity { get; set; }
    }
}
