﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LPP
{
    class Variable
    {
        //field
        private string _name;
        private bool _value;

        //constructor
        public Variable(string name)
        {
            this._name =  name;
        }

        public override string ToString()
        {
            return this._name;
        }
    }
}
