using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LPP.Connectives
{
    class AndOperator: Connective
    {
        public AndOperator() : base()
        {
            this._value = "&";
        }

        public override string ToString()
        {
            return base.ToString() + this._value;
        }
    }
}
