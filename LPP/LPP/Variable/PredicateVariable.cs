using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LPP
{
    [Serializable]
    public class PredicateVariable: Node
    {
        //field
        private bool _subtitution;

        //constructor
        public PredicateVariable(string name): base(name)
        {
            this._subtitution = false;
        }

        public bool IsSubtituted()
        {
            return _subtitution;
        }

        public override void ChangeVariable(PredicateVariable p)
        {
            this._subtitution = true;
            this._name = p.ToString();
        }

        public override string ToString()
        {
            return this._name;
        }
    }
}
