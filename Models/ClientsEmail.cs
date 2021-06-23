using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Store.Models
{
    public partial class ClientsEmail
    {
        public long Id { get; set; }
        [Required] [StringLength(255)] public string EmailAddress { get; set; }
        public long ClientId { get; set; }

        public virtual Client Client { get; set; }
    }
}
