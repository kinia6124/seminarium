using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace seminarium.Models
{
    public class PublishingBook
    {
        public int ID { get; set; }
        public int PublishingID { get; set; }
        public int BookID { get; set; }

        public virtual PublishingHouse PublishingHouse { get; set; }
        public virtual Book Book { get; set; }

    }
}