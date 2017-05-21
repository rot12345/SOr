using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Repozytorium.Models
{
    public class Message
    {
        public int Id { get; set; }

        public int  UserId {get; set; }

        public string Content { get; set; }

        [Required, DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public System.DateTime DateInsert { get; set; }

        public string StatusEvent { get; set; }

        public User User { get; set; }




    }
}