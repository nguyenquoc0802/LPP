using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LPP.Connectives
{
    class NANDOperator: Connective
    {
        public NANDOperator(string value): base(value) { }

        public override bool CalculateResult()
        {
            return this.TruthValue = !(this.RightNode.TruthValue & this.LeftNode.TruthValue);
        }

        public override string ConvertOperator()
        {
            return string.Format("{0}({1}, {2})", this._name, this.LeftNode, this.RightNode);
        }

        public override string ToString()
        {
            return string.Format("{0}({1}, {2})", this._name, this.LeftNode, this.RightNode);
        }
    }
}
