using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Repozytorium.Models;
using System.IO;
using System.Diagnostics;

namespace SongsOrganizer.Controllers
{
    public class FilesController : Controller
    {
        private AppContext db = new AppContext();

        // GET: Files
        public ActionResult Index()
        {
            return View(db.File.ToList());
        }
    

        // GET: Files/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Repozytorium.Models.File file = db.File.Find(id);
            if (file == null)
            {
                return HttpNotFound();
            }
            return View(file);
        }

        // GET: Files/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Files/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,DateInsert,DateUpdate,AccessId,Content,Path")] Repozytorium.Models.File file)
        {
            if (ModelState.IsValid)
            {
                file.Id = Guid.NewGuid();
                db.File.Add(file);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(file);
        }

        // GET: Files/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Repozytorium.Models.File file = db.File.Find(id);
            if (file == null)
            {
                return HttpNotFound();
            }
            return View(file);
        }

        // POST: Files/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,DateInsert,DateUpdate,AccessId,Content,Path")] Repozytorium.Models.File file)
        {
            if (ModelState.IsValid)
            {
                db.Entry(file).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(file);
        }

        // GET: Files/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Repozytorium.Models.File file = db.File.Find(id);
            if (file == null)
            {
                return HttpNotFound();
            }
            return View(file);
        }

        // POST: Files/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Repozytorium.Models.File file = db.File.Find(id);
            db.File.Remove(file);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public ActionResult FileUpload(HttpPostedFileBase file)
        {
            if (file != null)
            {
                string pic = System.IO.Path.GetFileName(file.FileName);
                string path = System.IO.Path.Combine(
                                       Server.MapPath("~/Files"), pic);

                var fileName = Path.GetFileName(file.FileName);
                // file is uploaded
                //file.SaveAs(path);
                file.SaveAs(Path.Combine(@"C:\Users\root\Desktop\Inżynierka\Projekt2\SongsOrganizer\SongsOrganizer\Pliki", path));

                //C:\Users\root\Desktop\Inżynierka\Projekt2\SongsOrganizer\SongsOrganizer

                // save the image path path to the database or you can send image 
                // directly to database
                // in-case if you want to store byte[] ie. for DB
                using (MemoryStream ms = new MemoryStream())
                {
                    file.InputStream.CopyTo(ms);
                    byte[] array = ms.GetBuffer();
                }

            }
            // after successfully uploading redirect the user
            return RedirectToAction("Index", "Plik");
        }

        public void SaveFilePathToDataBase(string path)
        {

        }

        public ActionResult GetPdf(string fileName)
        {
            /* var fileStream = new FileStream("~/Content/files/" + fileName,
                                              FileMode.Open,
                                              FileAccess.Read
                                            ); */

            var fileStream = new FileStream("C:/Users/root/Documents/Nuty/Ludovico Einaudi - Una Mattina.pdf",
                                                 FileMode.Open,
                                                 FileAccess.Read
                                               );
            var fsResult = new FileStreamResult(fileStream, "application/pdf");
            return fsResult;
        }
    }
}
