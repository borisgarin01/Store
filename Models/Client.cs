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
            ClientsAddresses = new HashSet<ClientAddress>();
            ClientsEmails = new HashSet<ClientEmail>();
            ClientsPhonesNumbers = new HashSet<ClientPhoneNumber>();
        }

        public long Id { get; set; }
        [Required][StringLength(255)]public string FirstName { get; set; }
        [Required][StringLength(255)]public string LastName { get; set; }

        public virtual ICollection<Cart> Carts { get; set; }
        public virtual ICollection<ClientAddress> ClientsAddresses { get; set; }
        public virtual ICollection<ClientEmail> ClientsEmails { get; set; }
        public virtual ICollection<ClientPhoneNumber> ClientsPhonesNumbers { get; set; }
    }
}
