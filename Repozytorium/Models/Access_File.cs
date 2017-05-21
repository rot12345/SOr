using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Repozytorium.Models
{
    public class Access_File
    {
        public int Id { get; set; }
        [Required]
        public int AccessId { get; set; }
        [Required]
        public int FileId { get; set; }

        public Access Access{ get; set; }

        public File File { get; set; }
    
    }
}