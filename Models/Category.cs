using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace seminarium.Models
{
    public class Category
    {
        public int ID { get; set; }
        public string Nazwa { get; set; }
        public virtual ICollection<CategoryBook> CategoryBooks { get; set; }

    }
}