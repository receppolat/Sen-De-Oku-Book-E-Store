﻿using SenDeOku.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SenDeOku.Models
{
    public class AlintiModel
    {
        public Alinti Alinti { get; set; }
        public Book Book { get; set; }
        public Author Author { get; set; }

    }
}
