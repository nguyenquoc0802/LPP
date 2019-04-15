using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LPP.Connectives
{
    class AndOperator: Connective
    {
        public AndOperator(string value) : base(value) { }

        public override string CalculateResult()
        {
            if(this.RightNode.TruthValue == "0" | this.LeftNode.TruthValue == "0")
            {
                return "0";
            }
            return "1";
        }
    }
}
