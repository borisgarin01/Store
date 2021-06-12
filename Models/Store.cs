using System;
using System.Collections.Generic;

#nullable disable

namespace Store.Models
{
    public partial class Store
    {
        public Store()
        {
            LeftoversInStores = new HashSet<LeftoversInStore>();
        }

        public long Id { get; set; }
        public long AddressId { get; set; }

        public virtual Address Address { get; set; }
        public virtual ICollection<LeftoversInStore> LeftoversInStores { get; set; }
    }
}
