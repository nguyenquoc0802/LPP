using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LPP.Predicate
{
    [Serializable]
    class Variable: Node, IComparable<Variable>
    {
        private List<PredicateVariable> _variables;

        public Variable(string name): base (name)
        {
            this._variables = new List<PredicateVariable>();
        }

        public void ChangePredicateVariable(PredicateVariable p, string oldVar)
        {
            foreach (PredicateVariable v in _variables)
            {
                if (!v.IsSubtituted())
                {
                    if(v.ToString() == oldVar)
                    {
                        v.ChangeVariable(p);
                        break;
                    }
                }
            }
        }

        public override void ChangeVariable(PredicateVariable p)
        {
            foreach (PredicateVariable v in _variables)
            {
                if (v.ToString() != p.ToString())
                {
                    if (!v.IsSubtituted())
                    {
                        v.ChangeVariable(p);
                        break;
                    }
                }
            }
        }

        public bool AllReplace()
        {
            foreach(var v in this._variables)
            {
                if(!v.IsSubtituted())
                {
                    return false;
                }
            }
            return true;
        }

        public int CompareTo(Variable other)
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

        public List<PredicateVariable> GetVariables()
        {
            return this._variables;
        }

        public override void DrawGraphHelper(ref string content)
        {
            content += "node" + this.Index + " [ label = \"" + this.ToString() + "\" ]\r\n";
        }


        public override void AddVariable(PredicateVariable variable)
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
