using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Repozytorium.Models
{
    public class Event_Message
    {
        public int Id { get; set; }
        [Required]
        public int EventId { get; set; }
        [Required]
        public int MessageId { get; set; }

        public Event Event { get; set; }

        public Message Message { get; set; }
    }
}