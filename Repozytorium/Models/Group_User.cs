using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace Repozytorium.Models
{
    public class Group_User
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public int GroupId { get; set; }
        [Required]
        public int UserId { get; set; }

        public User User { get; set; }

        public Group Group { get; set; }
    }
}