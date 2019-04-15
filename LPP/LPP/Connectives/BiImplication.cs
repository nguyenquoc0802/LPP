using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LPP.Connectives
{
    class BiImplication: Connective
    {
        public BiImplication(string value) : base(value) { }

        public override string CalculateResult()
        {
            if(this.LeftNode.TruthValue != this.RightNode.TruthValue)
            {
                return "0";
            }
            return "1";
        }
    }
}
