using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LPP
{
    abstract class Connective
    {
        //field
        protected string _value;

        //constructor
        public Connective(string value)
        {
            this._value = value;
        }

        public string GetVal()
        {
            return this._value;
        }

        public override string ToString()
        {
            return this._value;
        }
    }
}
