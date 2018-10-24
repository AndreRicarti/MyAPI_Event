using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace My.API_Event.Models
{
    public class EventConfirmation
    {
        public int Id { get; set; }
        public int EventId { get; set; }
        public Event @event { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        [Required]
        public DateTime DateCreation { get; set; }
    }
}
