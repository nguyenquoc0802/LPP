using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LPP.Connectives;
using System.Text.RegularExpressions;

namespace LPP
{
    class Tree
    {
        private Node _root;

        public Tree()
        {
            this._root = null;
        }

        //remove parenthesis and comma
        private string TrimInputPropositions(string inputProposition)
        {
            Regex pattern = new Regex("[,()]");
            char[] result = pattern.Replace(inputProposition, string.Empty).Where(c => !char.IsWhiteSpace(c)).ToArray();
            return new string(result);
        }
        //set the node using switch case
        private void SetNodeChecker(Node node , string c)
        {
            switch (c)
            {
                case "&":
                    node = new Node(new AndOperator());
                    break;
                case "|":
                    node = new Node(new OrOperator());
                    break;
                case ">":
                    node = new Node(new Implication());
                    break;
                case "~":
                    node = new Node(new Negation());
                    break;
                case "=":
                    node = new Node(new BiImplication());
                    break;
                default:
                    node = new Node(new Variable(c));
                    break;
            }
        }
        //create tree node
        public void InsertTree(string inputProposition)
        {
            string input = this.TrimInputPropositions(inputProposition);
            while(input.Length > 0)
            {
                if(this._root == null)
                {
                    this.SetNodeChecker(this._root, input[0].ToString());
                    //remove the first char
                    input.Substring(1);
                }
                else
                {
                    this.PreOrderHelper(this._root, ref input);
                }
            }
        }
        //display node in pre-order ordering
        public string DisplayPreOrder()
        {
            string display = "";
            return this.DisplayPreOrderHelper(this._root, ref display);
        }

        private string DisplayPreOrderHelper(Node root, ref string display)
        {
            if (root != null)
            {
                display += root.Connective.GetVal();
                this.DisplayPreOrderHelper(root.LeftNode, ref display);
                this.DisplayPreOrderHelper(root.RightNode, ref display);
            }
            return display;
        }

        private void PreOrderHelper(Node root, ref string propositions)
        {
            string c = propositions[0].ToString();
            switch (c)
            {
                case "&":
                    if(root.LeftNode == null)
                    {
                        root.InsertLeftNode(new Node(new AndOperator()));
                        propositions.Substring(1);
                        this.PreOrderHelper(root.LeftNode, ref propositions);
                    }
                    else
                    {
                        root.InsertRightNode(new Node(new AndOperator()));
                        propositions.Substring(1);
                        this.PreOrderHelper(root.LeftNode, ref propositions);
                    }
                    break;
                //case '|':
                //    root = new Node(new OrOperator());
                //    break;
                //case '>':
                //    root = new Node(new Implication());
                //    break;
                //case '~':
                //    root = new Node(new Negation());
                //    break;
                //case '=':
                //    root = new Node(new BiImplication());
                //    break;
                default:
                    if(root.LeftNode == null)
                    {
                        root.InsertLeftNode(new Node(new Variable(c)));
                    }
                    else
                    {
                        root.InsertRightNode(new Node(new Variable(c)));
                    }
                    break;
            }
        }
    }
}
