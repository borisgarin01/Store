using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Store.Models
{
    public partial class Address
    {
        public Address()
        {
            ClientsAddresses = new HashSet<ClientsAddress>();
            Stores = new HashSet<Store>();
        }

        public long Id { get; set; }
        [Required][StringLength(25)]public string PostIndex { get; set; }
        [Range(1,short.MaxValue)]public short FlatNumber { get; set; }
        [Required][StringLength(10)]public string HouseNumber { get; set; }
        [Required][StringLength(255)]public string Street { get; set; }
        [Required] [StringLength(255)] public string City { get; set; }
        [Required] [StringLength(255)] public string Country { get; set; }

        public virtual ICollection<ClientsAddress> ClientsAddresses { get; set; }
        public virtual ICollection<Store> Stores { get; set; }
    }
}
