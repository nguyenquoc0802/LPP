using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LPP.Connectives
{
    class Negation: Connective
    {
        public Negation(string value) : base(value) { }

        public override string CalculateResult()
        {
            if(this.RightNode.TruthValue == "0")
            {
                return "1";
            }
            return "0";
        }
    }
}
