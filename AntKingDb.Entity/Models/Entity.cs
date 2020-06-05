using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AntKingDb.Entity.Models
{
    [Table("UserInfo")]
    public class UserInfo:BaseEntity
    { 
        [MaxLength(50), Required]
        public string Name { get; set; }
        [MaxLength(50), Required]
        public string Password { get; set; }
    } 
}
