using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LPP.Connectives;
using System.Text.RegularExpressions;
using System.Diagnostics;
using System.Drawing;
using MoreLinq;

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

        public Node GetRoot()
        {
            return this._root;
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
                    this.InsertTreeHelper(ref this._root, prefixPropositions[i].ToString());
                }
                else
                {
                    string c = prefixPropositions[i].ToString();
                    Node node = null;
                    this.InsertTreeHelper(ref node, c);
                }
            }
        }
        // help with creating binary tree
        private void InsertTreeHelper(ref Node n, string c)
        {
            switch (c)
            {
                case "&":
                    n = new AndOperator(c);
                    n.LeftNode = this._myStack.Pop();
                    n.RightNode = this._myStack.Pop();
                    this._myStack.Push(n);
                    break;
                case "|":
                    n = new OrOperator(c);
                    n.LeftNode = this._myStack.Pop();
                    n.RightNode = this._myStack.Pop();
                    this._myStack.Push(n);
                    break;
                case ">":
                    n = new Implication(c);
                    n.LeftNode = this._myStack.Pop();
                    n.RightNode = this._myStack.Pop();
                    this._myStack.Push(n);
                    break;
                case "~":
                    n = new Negation(c);
                    n.RightNode = this._myStack.Pop();
                    this._myStack.Push(n);
                    break;
                case "=":
                    n = new BiImplication(c);
                    n.LeftNode = this._myStack.Pop();
                    n.RightNode = this._myStack.Pop();
                    this._myStack.Push(n);
                    break;
                default:
                    n = new Variable(c);
                    this._myStack.Push(n);
                    break;
            }
        }

        //display
        public string DisplayInOrder()
        {
            return _root.ToString();
        }

        //draw Tree
        public string DrawTree()
        {
            int index = 1;
            string content = "graph logic {\r\nnode [ fontname = \"Arial\" ]\r\n";
            this.SetIndexHelper(this._root, ref index);
            return this.DrawTreeHelper(this._root, ref content) + "}";
        }

        //help to create the content
        private string DrawTreeHelper(Node root, ref string content)
        {
            if(root != null)
            {
                root.DrawGraphHelper(ref content);
                this.DrawTreeHelper(root.LeftNode, ref content);
                this.DrawTreeHelper(root.RightNode, ref content);
            }
            return content;
        }

        //set index for each node
        private void SetIndexHelper(Node root, ref int index)
        {
            if(root != null)
            {
                root.Index = index;
                index++;
                this.SetIndexHelper(root.LeftNode, ref index);
                this.SetIndexHelper(root.RightNode, ref index);
            }
        }
    }
}
