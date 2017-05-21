using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;

namespace Repozytorium.Models
{
    public class User : IdentityUser
    {
        public User()
        {
            this.Group_User = new HashSet<Group_User>();
            this.Files = new HashSet<File>();
        }

        // Klucz podstawowy odziedziczony po klasie IdentityUser

        // Dodajemy pola Imie i Nazwisko:
        
       // [Display(Name = "Imię:")]
       // public string Imie { get; set; }
        
       // [Display(Name = "Nazwisko:")]
       // public string Nazwisko { get; set; }


        #region dodatkowe pole notmapped

        /*[NotMapped]     // using System.ComponentModel.DataAnnotations.Schema;
        [Display(Name = "Pan/Pani:")]
        public string PelneNazwisko
        {
           // get { return Imie + " " + Nazwisko; }
        }
        */



        public ICollection<Group_User> Group_User { get; set; }
        public virtual ICollection<File> Files { get; set; }

        #endregion


        //  public virtual ICollection<Ogloszenie> Ogloszenia { get; private set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }
}