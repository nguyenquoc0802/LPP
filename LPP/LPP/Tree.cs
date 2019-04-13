using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LPP.Connectives;

namespace LPP
{
    class Tree
    {
        private Node _root;

        public Tree()
        {
            this._root = null;
        }

        public void InsertTree(string inputProposition)
        {
            char[] propositions = inputProposition.Where(c => !char.IsWhiteSpace(c)).ToArray();
            if(this._root == null)
            {
                char check = propositions[0];
                switch (check)
                {
                    case '&':
                        this._root = new Node(new AndOperator());
                        break;
                    case '|':
                        this._root = new Node(new OrOperator());
                        break;
                    case '>':
                        this._root = new Node(new Implication());
                        break;
                    case '~':
                        this._root = new Node(new Negation());
                        break;
                    case '=':
                        this._root = new Node(new BiImplication());
                        break;
                    default:
                        this._root = new Node(new Variable(check));
                        break;
                }
            }
            else
            {
                this._root.is
            }
        }

        private void PreOrderHelper(Node root, char[] propositions)
        {
            
        }
    }
}
