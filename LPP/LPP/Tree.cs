using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LPP.Connectives;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace LPP
{
    class Tree
    {
        private Node _root;
        private Stack<Node> _myStack;

        public Tree()
        {
            this._root = null;
            this._myStack = new Stack<Node>();
        }

        //remove parenthesis and comma
        private string TrimInputPropositions(string inputProposition)
        {
            Regex pattern = new Regex("[,()]");
            char[] result = pattern.Replace(inputProposition, string.Empty).Where(c => !char.IsWhiteSpace(c)).ToArray();
            return new string(result);
        }
        //set the node using switch case
        private bool IsOperator(string c)
        {
            switch (c)
            {
                case ("&"):
                    return true;
                case "|":
                    return true;
                case ">":
                    return true;
                case "~":
                    return true;
                case "=":
                    return true;
                default:
                    return false;
            }
        }

        private Node Setnode(string c)
        {
            switch (c)
            {
                case "&":
                    return new Node(new AndOperator(c));
                case "|":
                    return new Node(new OrOperator(c));
                case ">":
                    return new Node(new Implication(c));
                case "~":
                    return new Node(new Negation(c));
                case "=":
                    return new Node(new BiImplication(c));
                default:
                    return new Node(new Variable(c));
            }
        }
        //create tree node
        public string InsertTree(string inputProposition)
        {
            string display = "";
            string input = this.TrimInputPropositions(inputProposition);
            while(input.Length > 0)
            {
                if (this._root == null)
                {
                    this._root = this.Setnode(input[0].ToString());
                    input.Remove(0, 1);
                }
                else
                {
                    this.PrefixHelper(this._root, input);
                }
            }
            return display;
        }

        private void PrefixHelper(Node root, string propositions)
        {
            if(root.LeftNode == null)
            {
                string c = propositions[0].ToString();
                switch(c)
                {
                    case "&":
                        root.LeftNode = new Node(new AndOperator(c));
                        this.PrefixHelper(root.LeftNode, propositions.Remove(0, 1));

                        break;
                    default:
                        root = new Node(new Variable(c));
                        propositions.Remove(0, 1);
                        break;
                }
            }
            else
            {
                string c = propositions[0].ToString();
                switch (c)
                {
                    case "&":
                        root = new Node(new AndOperator(c));
                        this.PrefixHelper(root.RightNode, propositions.Remove(0, 1));

                        break;
                    default:
                        root = new Node(new Variable(c));
                        propositions.Remove(0, 1);
                        break;
                }
            }
        }

        //display
        public string DisplayInOrder()
        {
            string display = "";
            return this.InOrderHelper(this._root, ref display);
        }

        public string InOrderHelper(Node root, ref string display)
        {
            if (root != null)
            {
                this.InOrderHelper(root.LeftNode, ref display);
                display += root + " ";
                this.InOrderHelper(root.RightNode, ref display);
            }
            return display;
        }
    }
}
