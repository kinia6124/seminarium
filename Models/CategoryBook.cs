using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace seminarium.Models
{
    public class CategoryBook
    {
        public int ID { get; set; }
        public int  BookID {get;set;}
        public int CategoryID { get; set; }
        public virtual Book Book { get; set; }
        public virtual Category Category { get; set; }


    }
}