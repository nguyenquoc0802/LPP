using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LPP.Connectives;

namespace LPP
{
    class Node
    {
        //field

        public Node LeftNode { get; set; }
        public Node RightNode { get; set; }
        public Connective Connective { get; set; }
        public Variable Variable { get; set; }

        public Node()
        {
            this.LeftNode = null;
            this.RightNode = null;
        }

        public Node(Connective connective): base()
        {
            this.Connective = connective;
        }

        public Node(Variable variable)
        {
            this.Variable = variable;
        }

        public override string ToString()
        {
            if(Connective != null)
            {
                return Connective.ToString();
            }
            else
            {
                return Variable.ToString();
            }
        }
    }
}
