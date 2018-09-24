using System;
using System.ComponentModel.DataAnnotations;

namespace My.API_Event.Models
{
    public class Company
    {
        public int Id { get; set; }
        [MaxLength(100)]
        public string Name { get; set; }
        [MaxLength(14)]
        public string Cnpj { get; set; }
        public DateTime DateCreation { get; set; }
    }
}
