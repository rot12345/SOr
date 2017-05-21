using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Text.RegularExpressions;

namespace Repozytorium.Models
{

    public class AppContext : IdentityDbContext
    {
        public AppContext()
            : base("DefaultConnection")
        {
        }

        public static AppContext Create()
        {
            return new AppContext();
        }

        public DbSet<Access> Access { get; set; }
        public DbSet<Access_File> Access_File { get; set; }
        public DbSet<Event> Event { get; set; }  
        public DbSet<Event_File> Event_File { get; set; }
        public DbSet<Event_Message> Event_Message { get; set; }  
        public DbSet<File> File { get; set; } 
        public DbSet<File_Tag> File_Tag { get; set; }
        public DbSet<Group> Group { get; set; }
        public DbSet<Group_User> Group_User { get; set; }
        public DbSet<Tag> Tag { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<User_Access> User_Access { get; set; }
   

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Potrzebne dla klas Identity
            base.OnModelCreating(modelBuilder);
            //od konwencji nazewnictwa
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}