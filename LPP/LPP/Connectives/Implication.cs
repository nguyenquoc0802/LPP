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

        public override bool CalculateResult()
        {
            if(this.LeftNode.TruthValue == true && this.RightNode.TruthValue == false)
            {
                return this.TruthValue = false;
            }
            return this.TruthValue = true;
        }

        public override string ConvertOperator()
        {
            return string.Format("%({0}, %({1}, {1}))", this.LeftNode.ConvertOperator(), this.RightNode.ConvertOperator());
        }

        public override string ToString()
        {
            return string.Format("({0} {1} {2})", this.LeftNode, this._value, this.RightNode);
        }
    }
}
