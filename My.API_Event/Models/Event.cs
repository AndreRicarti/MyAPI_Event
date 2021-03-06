﻿using System;
using System.ComponentModel.DataAnnotations;

namespace My.API_Event.Models
{
    public class Event
    {
        public int Id { get; set; }

        public int CompanyId { get; set; }

        public Company Company { get; set; }

        [Required]
        [MaxLength(100)]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public DateTime DateStart { get; set; }

        [Required]
        public DateTime DateEnd { get; set; }

        [Required]
        public DateTime DateCreation { get; set; }
    }
}
