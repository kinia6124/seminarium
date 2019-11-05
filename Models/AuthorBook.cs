﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace seminarium.Models
{
    public class AuthorBook
    {
        public int ID { get; set; }
        public int AuthorID { get; set; }
        public int BookID { get; set; }

        public virtual Author Author { get; set; }
        public virtual Book Book { get; set; }
    }
}