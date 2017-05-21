using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Repozytorium.Models
{
    public class User_Access
    {
        public int Id { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        public int AccessId { get; set; }

        public User User { get; set; }

        public Access Access { get; set; }
    }
}