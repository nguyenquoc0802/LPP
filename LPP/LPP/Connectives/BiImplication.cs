using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LPP.Connectives
{
    class BiImplication: Connective
    {
        public BiImplication() : base()
        {
            this._value = "=";
        }

        public override string ToString()
        {
            return base.ToString() + this._value;
        }
    }
}
