using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Store.Models
{
    public partial class Category
    {
        public Category()
        {
            Products = new HashSet<Product>();
        }

        public long Id { get; set; }
        [Required][StringLength(255)]public string CategoryName { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
