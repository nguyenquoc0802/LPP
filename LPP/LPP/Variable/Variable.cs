using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LPP.Predicate
{
    class PredicateVariable: Node, IComparable<PredicateVariable>
    {
        private List<Node> _variables;

        public PredicateVariable(string name): base (name)
        {
            this._variables = new List<Node>();
        }

        public override void DrawGraphHelper(ref string content)
        {
            content += "node" + this.Index + " [ label = \"" + this.ToString() + "\" ]\r\n";
        }

        public int CompareTo(PredicateVariable other)
        {
            return this._name.CompareTo(other._name);
        }

        public override bool CalculateResult()
        {
            return this.TruthValue;
        }

        public override string ConvertOperator()
        {
            return this._name;
        }

        public List<Node> GetVariables()
        {
            return this._variables;
        }

        public override void AddVariable(Node variable)
        {
            this._variables.Add(variable);
        }

        public override string ToString()
        {
            string result = "";
            if(this._variables.Count > 0)
            {
                result = this._name + "(";
                for (int i = 0; i < this._variables.Count; i++)
                {
                    if (i == this._variables.Count - 1)
                    {
                        result += this._variables[i] + ")";
                    }
                    else
                    {
                        result += this._variables[i] + ", ";
                    }
                }
                return result;
            }
            else
            {
                return this._name;
            }
        }
    }
}
