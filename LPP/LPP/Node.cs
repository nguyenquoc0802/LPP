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
        public int Index { get; set; }

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

        //each node have different implementation
        public void DrawGraphHelper(ref string content)
        {
            if(this.Connective != null)
            {
                if(this.LeftNode != null)
                {
                    content += "node" + Index + " [ label = \"" + this.ToString() + "\" ]\r\n";
                    content += "node" + Index + " -- " + "node" + LeftNode.Index + "\r\n";
                }
                if(this.RightNode != null)
                {
                    content += "node" + Index + " [ label = \"" + this.ToString() + "\" ]\r\n";
                    content += "node" + Index + " -- " + "node" + RightNode.Index + "\r\n";
                }
            }
            else
            {
                content += "node" + this.Index + " [ label = \"" + this.ToString() + "\" ]\r\n";
            }
        }

        public override string ToString()
        {
            if(this.Connective != null)
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
