using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LPP.Predicate;
using LPP.Connectives;

namespace LPP
{
    [Serializable]
    class Quantifier: Node
    {
        protected bool _subtitution;
        protected PredicateVariable _variable;

        public Quantifier(string name, PredicateVariable variable) : base(name)
        {
            this._subtitution = false;
            this._variable = variable;
        }

        public bool ReplaceChecked()
        {
            return _subtitution;
        }

        public void SetSubtitution()
        {
            this._subtitution = true;
        }

        public PredicateVariable GetVariable()
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
