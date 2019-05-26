using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LPP.Predicate
{
    class Existential: Quantifier
    {
        public Existential(string name, Variable variable): base(name, variable) { }
    }
}
