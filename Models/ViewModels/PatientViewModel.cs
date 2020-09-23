﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SahayogNepal.Models.ViewModels
{
    public class PatientViewModel
    {
        public string name { get; set; }
        public string mobile { get; set; }
        public float age { get; set; }
        public string gender { get; set; }
        public string city { get; set; }
        public string blood { get; set; }
        public string hospital { get; set; }
        public bool hasCaseSheet { get; set; }
    }
}
