using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LPP.Predicate
{
    class Quantifier: Node
    {
        protected Variable _variable;

        public Quantifier(string name, Variable variable) : base(name)
        {
            this._variable = variable;
        }

        public Variable GetVariable()
        {
            return this._variable;
        }

        public override void DrawGraphHelper(ref string content)
        {
            if (this.RightNode != null)
            {
                content += "node" + Index + " [ label = \"" + this._name + this._variable + "\" ]\r\n";
                content += "node" + Index + " -- " + "node" + RightNode.Index + "\r\n";
            }
        }

        public override string ToString()
        {
            return this._name + this._variable + "." + this.RightNode;
        }
    }
}
