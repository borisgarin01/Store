using System;
using System.Collections.Generic;

#nullable disable

namespace Store.Models
{
    public partial class ClientAddress
    {
        public long Id { get; set; }
        public long ClientId { get; set; }
        public long AddressId { get; set; }

        public virtual Address Address { get; set; }
        public virtual Client Client { get; set; }
    }
}
