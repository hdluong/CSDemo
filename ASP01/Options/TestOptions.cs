﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP01
{
    public class TestOptions
    {
        public string opt_key1 { get; set; }

        public SubTestOptions opt_key2 { get; set; }
    }

    public class SubTestOptions
    {
        public string k1 { get; set; }

        public string k2 { get; set; }
    }
}
