using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LPP.Connectives;
using LPP;

namespace LPP
{
    class Node
    {
        //field

        public Node LeftNode { get; set; }
        public Node RightNode { get; set; } 
        public Connective PropConnective { get; set; } 
        public Variable PropVariable { get; set; } 

        public Node()
        {
            this.LeftNode = null;
            this.RightNode = null;
        }

        public Node(Connective connective): base()
        {
            this.PropConnective = connective;
        }

        public Node(Variable variable)
        {
            this.PropVariable = variable;
        }
    }
}
