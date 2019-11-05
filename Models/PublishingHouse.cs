using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace seminarium.Models
{
    public class PublishingHouse
    {
        public int ID { get; set; }
        public string Nazwa { get; set; }

        public virtual ICollection<PublishingBook> PublishingBooks { get; set; }

    }
}