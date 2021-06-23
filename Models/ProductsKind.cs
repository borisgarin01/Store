using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Store.Models
{
    public partial class ProductsKind
    {
        public ProductsKind()
        {
            Products = new HashSet<Product>();
        }

        public long Id { get; set; }
        [Required] [StringLength(255)] public string KindName { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
