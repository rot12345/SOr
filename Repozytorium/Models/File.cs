using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Repozytorium.Models
{
    public class File
    {
        public File()
        {

            this.Access_File = new HashSet<Access_File>();
            this.File_Tag = new HashSet<File_Tag>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
      //  [Required]
        //public int UserId { get; set; } //Autor
        [Required, DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        //[DataType(DataType.Date)]
        public System.DateTime DateInsert { get; set; }

        [DataType(DataType.Date)]
        public System.DateTime? DateUpdate { get; set; }

        public int AccessId { get; set; }
        [StringLength(1800)]
        public string Content { get; set; }

        public string Path { get; set; }



        public virtual ICollection<File_Tag> File_Tag { get; set; }
        public virtual ICollection<Access_File> Access_File { get; set; }
        public virtual User User { get; set; }
    }
     
}