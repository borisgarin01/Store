using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Store.Models
{
    public partial class ClientPhoneNumber
    {
        public long Id { get; set; }
        public long ClientId { get; set; }
        [Required][StringLength(20)]public string PhoneNumber { get; set; }

        public virtual Client Client { get; set; }
    }
}
