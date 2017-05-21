using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Repozytorium.Models
{
    public class Tag
    {
        public Tag()
        {
            this.File_Tag = new HashSet<File_Tag>();
        }

        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Tag:")]
        public string Name { get; set; }

        public ICollection<File_Tag> File_Tag { get; set; }
     
    }
}