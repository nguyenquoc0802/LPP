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
        Stack<Node> _myStack;

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
        //create tree node
        public void InsertTree(string inputProposition)
        {
            string prefixPropositions = this.TrimInputPropositions(inputProposition);
            for(int i = prefixPropositions.Length - 1; i >= 0; i--)
            {
                if(i == 0)
                {
                    this._root = new Node(new AndOperator(prefixPropositions[0].ToString()));
                    this._root.LeftNode = this._myStack.Pop();
                    this._root.RightNode = this._myStack.Pop();
                }
                else
                {
                    string c = prefixPropositions[i].ToString();
                    switch(c)
                    {
                        case "&":
                            Node andOperator = new Node(new AndOperator(c));
                            andOperator.LeftNode = this._myStack.Pop();
                            andOperator.RightNode = this._myStack.Pop();
                            this._myStack.Push(andOperator);
                            break;
                        case "|":
                            Node orOperator = new Node(new OrOperator(c));
                            orOperator.LeftNode = this._myStack.Pop();
                            orOperator.RightNode = this._myStack.Pop();
                            this._myStack.Push(orOperator);
                            break;
                        case ">":
                            Node implication = new Node(new Implication(c));
                            implication.LeftNode = this._myStack.Pop();
                            implication.RightNode = this._myStack.Pop();
                            this._myStack.Push(implication);
                            break;
                        case "~":
                            Node negation = new Node(new Negation(c));
                            negation.LeftNode = this._myStack.Pop();
                            negation.RightNode = this._myStack.Pop();
                            this._myStack.Push(negation);
                            break;
                        case "=":
                            Node biImplication = new Node(new BiImplication(c));
                            biImplication.LeftNode = this._myStack.Pop();
                            biImplication.RightNode = this._myStack.Pop();
                            this._myStack.Push(biImplication);
                            break;
                        default:
                            Node variable = new Node(new Variable(c));
                            this._myStack.Push(variable);
                            break;
                    }
                }
            }
        }

        //display
        public string DisplayInOrder()
        {
            string display = "";
            return this.InOrderHelper(this._root, ref display);
        }

        private string InOrderHelper(Node root, ref string display)
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
