using System;
using System.Collections.Generic;
using System.Text;

namespace XamarinFirebase.Models
{
    public class Person
    {
        public int PersonId { get; set; }
        public string Name { get; set; }
        public double Weight { get; set; }
        public double Height { get; set; }
        public double BMI { get; set; }
        public string Status { get; set; }
    }
}
