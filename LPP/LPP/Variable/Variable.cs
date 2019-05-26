using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LPP
{
    class Variable: Node
    {
        //field

        //constructor
        public Variable(string name): base(name) { }

        public override string ToString()
        {
            return this._name;
        }
    }
}
