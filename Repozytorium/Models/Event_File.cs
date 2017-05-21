using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Repozytorium.Models
{
    public class Event_File
    {
        public int Id { get; set; }
        [Required]
        public int EventId { get; set; }
        [Required]
        public int FileId { get; set; }

        public File File  { get; set; }

        public Event Event{ get; set; }

    }
}