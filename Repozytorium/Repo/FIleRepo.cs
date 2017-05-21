using Repozytorium.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace Repozytorium.Repo
{
    public class FileRepo
    {
        private AppContext db = new AppContext();

        public IEnumerable<File> GetFiles()
        {
           // db.Database.Log = message => Trace.WriteLine(message);
            return db.File.ToList();  // db.File.AsNoTracking();
        }





    }
}