﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _01人员信息_作业
{
    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public override string ToString()
        {
            return this.Name;
        }
    }
}
