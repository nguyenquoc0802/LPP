using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LPP
{
    class Variable: Node, IComparable<Variable>
    {
        //field
        private string _name;
        private bool _value;

        //constructor
        public Variable(string name)
        {
            this._name =  name;
        }

        public override void DrawGraphHelper(ref string content)
        {
            content += "node" + this.Index + " [ label = \"" + this.ToString() + "\" ]\r\n";
        }

        public int CompareTo(Variable other)
        {
            return this._name.CompareTo(other._name);
        }

        public override string CalculateResult()
        {
            return this.TruthValue;
        }

        public override string ToString()
        {
            return this._name;
        }
    }
}
