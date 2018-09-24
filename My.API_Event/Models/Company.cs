using System;
using System.ComponentModel.DataAnnotations;

namespace My.API_Event.Models
{
    public class Company
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [Required]
        [MaxLength(14)]
        public int Cnpj { get; set; }
        [Required]
        public DateTime DateCreation { get; set; }
    }
}
