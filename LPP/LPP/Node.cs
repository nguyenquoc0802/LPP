using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LPP.Connectives;

namespace LPP
{
    [Serializable]
    public class Node : ICalculateExpression
    {
        //field
        protected string _name;
        public Node LeftNode { get; set; }
        public Node RightNode { get; set; }
        public bool TruthValue { get; set; }
        public int Index { get; set; }

        public Node(string name)
        {
            this._name = name;
            this.LeftNode = null;
            this.RightNode = null;
        }

        public Node() { }

        public virtual void ChangeVariable(PredicateVariable p) { }

        public virtual void Merge(List<Node> other) { }

        public virtual void AddFormulas(Node n) { }

        public virtual void AddVariable(PredicateVariable p) { }

        public virtual bool CalculateResult() { return true; }

        public virtual void DrawGraphHelper(ref string content) { }

        public virtual string ConvertOperator() { return ""; }

        public override string ToString()
        {
            return this._name;
        }
    }
}
