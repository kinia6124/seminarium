using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using seminarium.Models;

namespace seminarium.Controllers
{
    public class CategoryBookController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: CategoryBook
        public ActionResult Index()
        {
            var categoryBooks = db.CategoryBooks.Include(c => c.Book).Include(c => c.Category);
            return View(categoryBooks.ToList());
        }

        // GET: CategoryBook/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CategoryBook categoryBook = db.CategoryBooks.Find(id);
            if (categoryBook == null)
            {
                return HttpNotFound();
            }
            return View(categoryBook);
        }

        // GET: CategoryBook/Create
        public ActionResult Create()
        {
            ViewBag.BookID = new SelectList(db.Books, "ID", "Tytul");
            ViewBag.CategoryID = new SelectList(db.Categories, "ID", "Nazwa");
            return View();
        }

        // POST: CategoryBook/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,BookID,CategoryID")] CategoryBook categoryBook)
        {
            if (ModelState.IsValid)
            {
                db.CategoryBooks.Add(categoryBook);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BookID = new SelectList(db.Books, "ID", "Tytul", categoryBook.BookID);
            ViewBag.CategoryID = new SelectList(db.Categories, "ID", "Nazwa", categoryBook.CategoryID);
            return View(categoryBook);
        }

        // GET: CategoryBook/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CategoryBook categoryBook = db.CategoryBooks.Find(id);
            if (categoryBook == null)
            {
                return HttpNotFound();
            }
            ViewBag.BookID = new SelectList(db.Books, "ID", "Tytul", categoryBook.BookID);
            ViewBag.CategoryID = new SelectList(db.Categories, "ID", "Nazwa", categoryBook.CategoryID);
            return View(categoryBook);
        }

        // POST: CategoryBook/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,BookID,CategoryID")] CategoryBook categoryBook)
        {
            if (ModelState.IsValid)
            {
                db.Entry(categoryBook).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BookID = new SelectList(db.Books, "ID", "Tytul", categoryBook.BookID);
            ViewBag.CategoryID = new SelectList(db.Categories, "ID", "Nazwa", categoryBook.CategoryID);
            return View(categoryBook);
        }

        // GET: CategoryBook/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CategoryBook categoryBook = db.CategoryBooks.Find(id);
            if (categoryBook == null)
            {
                return HttpNotFound();
            }
            return View(categoryBook);
        }

        // POST: CategoryBook/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CategoryBook categoryBook = db.CategoryBooks.Find(id);
            db.CategoryBooks.Remove(categoryBook);
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
    }
}
