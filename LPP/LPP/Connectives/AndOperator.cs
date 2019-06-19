using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LPP.Connectives
{
    [Serializable]
    class AndOperator: Connective
    {
        public AndOperator(string value, Node leftNode = null, Node rightNode = null) : base(value)
        {
            this.LeftNode = leftNode;
            this.RightNode = rightNode;
        }

        public override bool CalculateResult()
        {
            return this.TruthValue = (this.RightNode.TruthValue & this.LeftNode.TruthValue);
        }

        public override string ConvertOperator()
        {
            return string.Format("%(%({0}, {1}), %({0}, {1}))", this.LeftNode.ConvertOperator(), this.RightNode.ConvertOperator());
        }

        public override string ToString()
        {
            return string.Format("({0} {1} {2})", this.LeftNode, this._name, this.RightNode);
        }
    }
}
