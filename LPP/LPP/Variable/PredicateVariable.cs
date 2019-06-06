using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LPP
{
    class PredicateVariable: Node
    {
        //field

        //constructor
        public PredicateVariable(string name): base(name) { }

        public override string ToString()
        {
            return this._name;
        }
    }
}
