using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LPP.Connectives;
using LPP.Predicate;
using MoreLinq;

namespace LPP.Semantic_Tableaux
{
    //check again later, need to improve for performance
    public class DerivationStep : Node
    {
        private List<Node> _logicFormulas;
        private List<PredicateVariable> _activeVariables;

        public DerivationStep(List<PredicateVariable> activeVariables = null)
        {
            this._logicFormulas = new List<Node>();
            this._activeVariables = (activeVariables == null) ?  new List<PredicateVariable>() : activeVariables.ToList(); 
        }

        public List<PredicateVariable> GetActiveVariables()
        {
            return this._activeVariables;
        }

        public PredicateVariable GetLastVar()
        {
            return this._activeVariables[this._activeVariables.Count - 1];
        }

        public void AddActiveVariable()
        {
            if(this._activeVariables.Count != 0)
            {
                PredicateVariable lastVar = this._activeVariables[this._activeVariables.Count - 1];
                string nextLetter = Convert.ToString((char)(lastVar.ToString()[0] + 1));
                this._activeVariables.Add(new PredicateVariable(nextLetter));
            }
            else
            {
                this._activeVariables.Add(new PredicateVariable("a"));
            }
        }

        public List<Node> GetFormulas()
        {
            return this._logicFormulas;
        }

        public override void AddFormulas(Node n)
        {
            this._logicFormulas.Add(n);
        }

        public override void DrawGraphHelper(ref string content)
        {
            if(this.LeftNode == null && this.RightNode == null)
            {
                content += "node" + Index + " [ label = \"" + this.ToString() + "\" ]\r\n";
            }
            if (this.LeftNode != null)
            {
                content += "node" + Index + " [ label = \"" + this.ToString() + "\" ]\r\n";
                content += "node" + Index + " -- " + "node" + LeftNode.Index + "\r\n";
            }
            if (this.RightNode != null)
            {
                content += "node" + Index + " [ label = \"" + this.ToString() + "\" ]\r\n";
                content += "node" + Index + " -- " + "node" + RightNode.Index + "\r\n";
            }
        }

        public override void Merge(List<Node> other)
        {
            this._logicFormulas.AddRange(other);
            List<Node> uniqueList = this._logicFormulas.DistinctBy(n => n.ToString()).ToList();
            this._logicFormulas = uniqueList;
        }

        public override string ToString()
        {
            string result = "{ ";
            for(int i = 0; i < this._logicFormulas.Count; i++)
            {
                if(i != this._logicFormulas.Count - 1)
                {
                    result += this._logicFormulas[i] + ", ";
                }
                else
                {
                    result += this._logicFormulas[i];
                }
            }
            result += " } [ ";
            for (int i = 0; i < this._activeVariables.Count; i++)
            {
                if (i != this._activeVariables.Count - 1)
                {
                    result += this._activeVariables[i] + ", ";
                }
                else
                {
                    result += this._activeVariables[i];
                }
            }
            return result + " ]";
        }
    }
}
