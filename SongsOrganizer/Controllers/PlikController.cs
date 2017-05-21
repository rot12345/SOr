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

namespace SongsOrganizer.Controllers
{
    public class PlikController : Controller
    {
       /* private AppContext db = new AppContext();

        // GET: Plik
        public ActionResult Index()
        {
            var plik = db.Plik.Include(p => p.Typ);
            return View(plik.ToList());
        }

        // GET: Plik/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            File plik = db.Plik.Find(id);
            if (plik == null)
            {
                return HttpNotFound();
            }
            return View(plik);
        }

        // GET: Plik/Create
        public ActionResult Create()
        {
            ViewBag.TypId = new SelectList(db.Typ, "Id", "Nazwa");
            return View();
        }

        // POST: Plik/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nazwa,DataDodania,DataAktualizacji,TypId,DostepId,Tresc,Sciezka")] File plik)
        {
            if (ModelState.IsValid)
            {
                plik.Id = Guid.NewGuid();
                db.Plik.Add(plik);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TypId = new SelectList(db.Typ, "Id", "Nazwa", plik.TypId);
            return View(plik);
        }

        // GET: Plik/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            File plik = db.Plik.Find(id);
            if (plik == null)
            {
                return HttpNotFound();
            }
            ViewBag.TypId = new SelectList(db.Typ, "Id", "Nazwa", plik.TypId);
            return View(plik);
        }

        // POST: Plik/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nazwa,DataDodania,DataAktualizacji,TypId,DostepId,Tresc,Sciezka")] File plik)
        {
            if (ModelState.IsValid)
            {
                db.Entry(plik).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TypId = new SelectList(db.Typ, "Id", "Nazwa", plik.TypId);
            return View(plik);
        }

        // GET: Plik/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            File plik = db.Plik.Find(id);
            if (plik == null)
            {
                return HttpNotFound();
            }
            return View(plik);
        }

        // POST: Plik/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            File plik = db.Plik.Find(id);
            db.Plik.Remove(plik);
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
        //
        public ActionResult FileUpload(HttpPostedFileBase file)
        {
            if (file != null)
            {
                string pic = System.IO.Path.GetFileName(file.FileName);
                string path = System.IO.Path.Combine(
                                       Server.MapPath("~/Files"), pic);

                var fileName=Path.GetFileName(file.FileName);
                // file is uploaded
                //file.SaveAs(path);
                file.SaveAs(Path.Combine(@"C:\Users\root\Desktop\Inżynierka\Projekt2\SongsOrganizer\SongsOrganizer\Files", path));

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

        /*    var fileStream = new FileStream("C:/Users/root/Documents/NutyLudovico Einaudi - Una Mattina.pdf",
                                             FileMode.Open,
                                             FileAccess.Read
                                           );
            var fsResult = new FileStreamResult(fileStream, "application/pdf");
            return fsResult;
        }
    */
    }
}
