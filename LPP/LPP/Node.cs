using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LPP.Connectives;

namespace LPP
{
    class Node: ICalculateExpression
    {
        //field
        //might have method to set node privately
        public Node LeftNode { get; set; }
        public Node RightNode { get; set; }
        public string TruthValue { get; set; }
        public int Index { get; set; }

        public Node()
        {
            this.LeftNode = null;
            this.RightNode = null;
        }

        public virtual string CalculateResult() { return ""; }

        //each node have different implementation
        public virtual void DrawGraphHelper(ref string content) { }
    }
}
