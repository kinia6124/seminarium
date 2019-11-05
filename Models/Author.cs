using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace seminarium.Models
{
    public class Author
    {
        public int ID { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public DateTime Data_ur { get; set; }
        public string Zyciorys { get; set; }

        public virtual ICollection<AuthorBook> AuthorBooks { get; set; }

    }
}