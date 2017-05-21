using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Repozytorium.Models
{
    public class File_Tag
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int TagId { get; set; }
        [Required]
        public int FileId { get; set; }

        public Tag Tag { get; set; }

        public File File { get; set; }


    }
}