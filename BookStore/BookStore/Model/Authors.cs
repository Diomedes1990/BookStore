﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Model
{
    public class Authors
    {
        public int ID { get; set; }
        public int IDBook { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
