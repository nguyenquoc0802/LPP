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

        public override bool CalculateResult()
        {
            return this.TruthValue = (this.RightNode.TruthValue & this.LeftNode.TruthValue);
        }

        public override string ToString()
        {
            return string.Format("({0} {1} {2})", this.LeftNode, this._value, this.RightNode);
        }
    }
}
