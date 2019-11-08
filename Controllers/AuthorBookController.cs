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
    public class AuthorBookController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: AuthorBook
        public ActionResult Index()
        {
            var authorBooks = db.AuthorBooks.Include(a => a.Author).Include(a => a.Book);
            return View(authorBooks.ToList());
        }

        // GET: AuthorBook/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AuthorBook authorBook = db.AuthorBooks.Find(id);
            if (authorBook == null)
            {
                return HttpNotFound();
            }
            return View(authorBook);
        }

        // GET: AuthorBook/Create
        public ActionResult Create()
        {
            ViewBag.AuthorID = new SelectList(db.Authors, "ID", "Imie");
            ViewBag.BookID = new SelectList(db.Books, "ID", "Tytul");
            return View();
        }

        // POST: AuthorBook/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,AuthorID,BookID")] AuthorBook authorBook)
        {
            if (ModelState.IsValid)
            {
                db.AuthorBooks.Add(authorBook);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AuthorID = new SelectList(db.Authors, "ID", "Imie", authorBook.AuthorID);
            ViewBag.BookID = new SelectList(db.Books, "ID", "Tytul", authorBook.BookID);
            return View(authorBook);
        }

        // GET: AuthorBook/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AuthorBook authorBook = db.AuthorBooks.Find(id);
            if (authorBook == null)
            {
                return HttpNotFound();
            }
            ViewBag.AuthorID = new SelectList(db.Authors, "ID", "Imie", authorBook.AuthorID);
            ViewBag.BookID = new SelectList(db.Books, "ID", "Tytul", authorBook.BookID);
            return View(authorBook);
        }

        // POST: AuthorBook/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,AuthorID,BookID")] AuthorBook authorBook)
        {
            if (ModelState.IsValid)
            {
                db.Entry(authorBook).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AuthorID = new SelectList(db.Authors, "ID", "Imie", authorBook.AuthorID);
            ViewBag.BookID = new SelectList(db.Books, "ID", "Tytul", authorBook.BookID);
            return View(authorBook);
        }

        // GET: AuthorBook/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AuthorBook authorBook = db.AuthorBooks.Find(id);
            if (authorBook == null)
            {
                return HttpNotFound();
            }
            return View(authorBook);
        }

        // POST: AuthorBook/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AuthorBook authorBook = db.AuthorBooks.Find(id);
            db.AuthorBooks.Remove(authorBook);
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
