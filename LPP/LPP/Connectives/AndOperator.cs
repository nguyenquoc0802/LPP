using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LPP.Connectives
{
    class AndOperator: Connective
    {
        public AndOperator(): base() { }

        public override string ToString()
        {
            return base.ToString() + "&";
        }
    }
}
