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
        public Connective()
        {

        }

        public string GetVal()
        {
            return this._value;
        }

        public override string ToString()
        {
            return "";
        }
    }
}
