using seminarium.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace seminarium.DAL
{
    public class CzytelniaInitializer :
System.Data.Entity.DropCreateDatabaseIfModelChanges<CzytelniaContext>
    {
        protected override void Seed(CzytelniaContext context)
        {
            var authors = new List<Author>
            {
              new Author{Imie="Jan", Nazwisko="Kochanowski", Data_ur=DateTime.Parse("2019-05-21"), Zyciorys="zyl sobie autor"}
            };
            authors.ForEach(a => context.Authors.Add(a));
            context.SaveChanges();

            var authorbooks = new List<AuthorBook>
            {
              new AuthorBook{AuthorID=1,BookID=1}
            };
            authorbooks.ForEach(a => context.AuthorBooks.Add(a));
            context.SaveChanges();

            var books = new List<Book>
            {
              new Book{Tytul="Odprawa Posłów Greckich", Strony=250, Rok_wydania=DateTime.Parse("1578-00-00"), AuthorID=1, Streszczenie="streszczenie", Link="https://drive.google.com/file/d/1jvOwPAnnPZ9aYx03bTD3AAsxGMJcc_lH/view?usp=sharing"}
            };
            books.ForEach(a => context.Books.Add(a));
            context.SaveChanges();

            var categories = new List<Category>
            {
              new Category{Nazwa="Dramat"}
            };
            categories.ForEach(a => context.Categories.Add(a));
            context.SaveChanges();

            var categorybooks = new List<CategoryBook>
            {
              new CategoryBook{BookID=1, CategoryID=1}
            };
            categorybooks.ForEach(a => context.CategoryBooks.Add(a));
            context.SaveChanges();
        }

    }
}