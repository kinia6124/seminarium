using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Policy;
using System.Web;

namespace seminarium.Models
{
    public class Book
    {
        [Key]
        public int ID { get; set; }
        public string Tytul { get; set; }
        public int Strony { get; set; }
        public DateTime Rok_wydania { get; set; }
        public int AuthorID { get; set; }
        public string Streszczenie { get; set; }
        public string Link { get; set; }

        public virtual ICollection<AuthorBook> AuthorBooks { get; set; }
        public virtual ICollection<CategoryBook> CategoryBooks { get; set; }


    }
}