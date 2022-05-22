using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Departments_Core.Entities
{
    [Table("Tokens")]
    public class TokenEntity
    {
        [Key]
        public string Token { get; set; }
        public string Ci { get; set; }
        [Column("Expiration_Date")]
        public DateTime ExpirationDate { get; set; }
    }
}