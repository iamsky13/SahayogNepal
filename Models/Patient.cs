using SahayogNepal.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SahayogNepal.Models
{
    public class Patient
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string MobileNumber { get; set; }
        public float Age { get; set; }
        public Gender  Gender { get; set; }
        public string City { get; set; }
        public string BloodGroup { get; set; }
        public string Hospital { get; set; }
        public bool HasCaseSheet { get; set; }
        public DateTime RegisteredDate { get; set; }
    }
}
