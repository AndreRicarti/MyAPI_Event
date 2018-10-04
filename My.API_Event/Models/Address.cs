using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace My.API_Event.Models
{
    public class Address
    {
        public int Id { get; set; }

        public int CompanyId { get; set; }

        public Company Company { get; set; }

        [Required]
        [MaxLength(100)]
        public string Street { get; set; }

        public int Number { get; set; }

        [Required]
        [MaxLength(100)]
        public string City { get; set; }

        [Required]
        [Column(TypeName = "char(2)")]
        public string State { get; set; }

        [Required]
        [MaxLength(100)]
        public string Country { get; set; }

        [Required]
        public DateTime DateCreation { get; set; }
    }
}
