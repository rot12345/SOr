using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Repozytorium.Models
{
    public class Group
    {
        public Group()
        {
            this.Grupa_Uzytkownik = new HashSet<Group_User>();
        }
        public int Id { get; set; }

        [Display(Name = "Nazwa kategorii:")]
        [Required]
        public string Name { get; set; }

        [Required]
        public int AccessId { get; set; }


        public Access Access { get; set; }
        public virtual ICollection<Group_User> Grupa_Uzytkownik { get; set; }
    }
}