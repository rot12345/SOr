using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Repozytorium.Models
{
    public class Access
    {

        public int Id { get; set; }
        [Required]
        public string Ident { get; set; }
        [Required]
        public string Name { get; set; }
    }
}