using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LPP.Connectives
{
    class Implication: Connective
    {
        public Implication(string value) : base(value) { }

        public override string CalculateResult()
        {
            if(this.LeftNode.TruthValue == "1" && this.RightNode.TruthValue == "0")
            {
                return "0";
            }
            return "1";
        }
    }
}
