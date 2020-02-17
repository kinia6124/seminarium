using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace seminarium.Models
{
    public class Author
    {
        [Key]
        public int ID { get; set; }

        public string Imie { get; set; }
        public string Nazwisko { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString ="{0:yyy-MM-dd}")]
        public DateTime Data_ur { get; set; }
        public string Zyciorys { get; set; }

        public virtual ICollection<AuthorBook> AuthorBooks { get; set; }

    }
}