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
                return this.TruthValue = "1";
            }
            return this.TruthValue = "0";
        }

        public override string ToString()
        {
            return string.Format("{0}{1}", this._value, this.RightNode); 
        }
    }
}
