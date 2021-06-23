using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Store.Models
{
    public partial class Client
    {
        public Client()
        {
            Carts = new HashSet<Cart>();
            ClientsAddresses = new HashSet<ClientsAddress>();
            ClientsEmails = new HashSet<ClientsEmail>();
            ClientsPhonesNumbers = new HashSet<ClientsPhonesNumber>();
        }

        public long Id { get; set; }
        [Required] [StringLength(255)] public string FirstName { get; set; }
        [Required] [StringLength(255)] public string LastName { get; set; }

        public virtual ICollection<Cart> Carts { get; set; }
        public virtual ICollection<ClientsAddress> ClientsAddresses { get; set; }
        public virtual ICollection<ClientsEmail> ClientsEmails { get; set; }
        public virtual ICollection<ClientsPhonesNumber> ClientsPhonesNumbers { get; set; }
    }
}
