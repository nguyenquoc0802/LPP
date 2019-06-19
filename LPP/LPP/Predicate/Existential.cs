using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LPP
{
    [Serializable]
    class Existential: Quantifier
    {
        public Existential(string name, PredicateVariable variable): base(name, variable) { }
    }
}
