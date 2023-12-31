﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridlineInterviewAPI.Core.Models
{
    public class Truck
    {
        public int Id { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public List<Driver> Drivers { get; } = new(); // part of many-to-many relationship
    }
}
