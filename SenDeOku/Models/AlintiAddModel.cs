﻿using Microsoft.AspNetCore.Mvc.Rendering;
using SenDeOku.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SenDeOku.Models
{
    public class AlintiAddModel
    {
        public Alinti Alinti { get; set; }
        public SelectList Books { get; set; }
    }
}
