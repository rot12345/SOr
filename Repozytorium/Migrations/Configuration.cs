namespace Repozytorium.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Repozytorium.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Repozytorium.Models.AppContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Repozytorium.Models.AppContext context)
        {
            // Do debugowania metody seed
            // if (System.Diagnostics.Debugger.IsAttached == false)
            // System.Diagnostics.Debugger.Launch();
            SeedRoles(context);
           // SeedUsers(context);
           // SeedOgloszenia(context);
           // SeedKategorie(context);
           // SeedOgloszenie_Kategoria(context);
        }
       private void SeedRoles(AppContext context)
       {
            var roleManager = new RoleManager<Microsoft.AspNet.Identity.EntityFramework.IdentityRole>(new RoleStore<IdentityRole>());

            if (!roleManager.RoleExists("Admin"))
            {
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "Admin";
                roleManager.Create(role);
            }
           if (!roleManager.RoleExists("Lider"))
            {
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "Lider";
                roleManager.Create(role);
            }
            if (!roleManager.RoleExists("Muzyk"))
            {
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "Muzyk";
                roleManager.Create(role);
            }

       }


    }
}
