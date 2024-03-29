﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LPP.Connectives
{
    [Serializable]
    class OrOperator: Connective
    {
        public OrOperator(string value) : base(value) { }

        public override bool CalculateResult()
        {
            return this.TruthValue = (this.RightNode.TruthValue | this.LeftNode.TruthValue);
        }

        public override string ConvertOperator()
        {
            return string.Format("%(%({0}, {0}), %({1}, {1}))", this.LeftNode.ConvertOperator(), this.RightNode.ConvertOperator());
        }

        public override string ToString()
        {
            return string.Format("({0} {1} {2})", this.LeftNode, this._name, this.RightNode);
        }
    }
}
