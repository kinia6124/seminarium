using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Web;

namespace seminarium.Models
{
    public class Book
    {
        public int ID { get; set; }
        public string Tytul { get; set; }
        public int PublishingID { get; set; }
        public int Strony { get; set; }
        public DateTime Rok_wydania { get; set; }
        public int AuthorID { get; set; }
        public string Streszczenie { get; set; }
        public Url Link { get; set; }

        public virtual ICollection<AuthorBook> AuthorBooks { get; set; }
        public virtual ICollection<CategoryBook> CategoryBooks { get; set; }
        public virtual ICollection<PublishingBook> PublishingBooks { get; set; }


    }
}