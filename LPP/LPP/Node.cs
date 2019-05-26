using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LPP.Connectives;

namespace LPP
{
    class Node : ICalculateExpression
    {
        //field
        //might have method to set node privately
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

        public virtual void AddVariable(Node n) { }

        public virtual bool CalculateResult() { return true; }

        public virtual string ConvertOperator() { return ""; }

        //each node have different implementation
        public virtual void DrawGraphHelper(ref string content) { }
    }
}
