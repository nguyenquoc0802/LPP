using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LPP.Connectives
{
    [Serializable]
    class Negation: Connective
    {
        public Negation(string value, Node rightNode = null) : base(value)
        {
            this.RightNode = rightNode;
        }

        public override bool CalculateResult()
        {
            return this.TruthValue = !(this.RightNode.TruthValue);
        }

        public override string ConvertOperator()
        {
            return string.Format("%({0}, {0})", this.RightNode.ConvertOperator());
        }

        public override string ToString()
        {
            return string.Format("{0}{1}", this._name, this.RightNode); 
        }
    }
}
