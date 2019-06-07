using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LPP.Connectives;
using LPP.Predicate;

namespace LPP.Semantic_Tableaux
{
    //check again later, need to improve for performance
    class DerivationStep : Node
    {
        private List<Node> _logicFormulas;

        public DerivationStep()
        {
            this._logicFormulas = new List<Node>();
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
            return result + " }";
        }
    }
}
