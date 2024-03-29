﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LPP.Connectives;
using LPP.Predicate;
using System.Text.RegularExpressions;
using System.Diagnostics;
using System.Drawing;
using MoreLinq;
using LPP.Semantic_Tableaux;

namespace LPP
{
    public class Tree
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

        //create tree node
        public void InsertTree(string inputProposition)
        {
            string prefixPropositions = FunctionHelper.TrimInputPropositions(inputProposition);
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
                case "%":
                    n = new NANDOperator(c);
                    n.LeftNode = this._myStack.Pop();
                    n.RightNode = this._myStack.Pop();
                    this._myStack.Push(n);
                    break;
                case "!":
                    n = new Existential(c, new PredicateVariable(this._myStack.Pop().ToString()));
                    n.RightNode = this._myStack.Pop();
                    this._myStack.Push(n);
                    break;
                case "@":
                    n = new Universal(c, new PredicateVariable(this._myStack.Pop().ToString()));
                    n.RightNode = this._myStack.Pop();
                    this._myStack.Push(n);
                    break;
                default:
                    if(char.IsLower(char.Parse(c)))
                    {
                        n = new PredicateVariable(c);
                        this._myStack.Push(n);
                    }
                    else
                    {
                        n = new Variable(c);
                        int total = this._myStack.Count;
                        for (int i = 0; i < total; i++)
                        {
                            if (_myStack.Peek() is PredicateVariable p)
                            {
                                n.AddVariable(p);
                                _myStack.Pop();
                            }
                        }
                        this._myStack.Push(n);
                    }
                    break;
            }
        }

        //display
        public string DisplayInOrder()
        {
            return _root.ToString();
        }

        public string DisplayOnlyNAND()
        {
            return this._root.ConvertOperator();
        }

        //draw Tree
        public string DrawTree()
        {
            int index = 1;
            string content = "graph logic {\r\nnode [ fontname = \"Arial\" ]\r\n";
            FunctionHelper.SetIndexHelper(this._root, ref index);
            return FunctionHelper.DrawTreeHelper(this._root, ref content) + "}";
        }

        //help converse to prefix by convert reversed infix to postfix form
        private string InfixToPrefixHelper(string str1)
        {
            Stack<string> myStack = new Stack<string>();
            string result = "";
            string infix = FunctionHelper.TrimInputPropositions(str1);
            string reverseInfix = FunctionHelper.ReverseString(infix);
            for(int i = 0; i < reverseInfix.Length; i++)
            {
                if(FunctionHelper.IsOperator(reverseInfix[i].ToString()))
                {
                    while(myStack.Count > 0)
                    {
                        if(FunctionHelper.PriorityDeterminer(myStack.Peek()) >= FunctionHelper.PriorityDeterminer(reverseInfix[i].ToString()))
                        {
                            result += myStack.Pop();
                        }
                        else
                        {
                            break;
                        }
                    }
                    myStack.Push(reverseInfix[i].ToString());
                }
                else
                {
                    result += reverseInfix[i].ToString();
                }
            }
            //remaining operator in the stack
            while(myStack.Count > 0)
            {
                result += myStack.Pop();
            }
            return result;
        }

        //infix to prefix
        public string InfixToPrefix(string str1)
        {
            string reverse = this.InfixToPrefixHelper(str1);
            string result = FunctionHelper.ReverseString(reverse);
            return result;
        }

        public void FindBoundVar(Node n, ref List<string> bound)
        {
            if(n != null)
            {
                if(n is Quantifier q)
                {
                    bound.Add(q.GetVariable().ToString());
                    bound = bound.DistinctBy(v => v.ToString()).ToList();
                }
                this.FindBoundVar(n.LeftNode, ref bound);
                this.FindBoundVar(n.RightNode, ref bound);
            }
        }

        public void FindPredicateVar(Node n, ref List<string> unbound)
        {
            if(n != null)
            {
                if(n is Variable v)
                {
                    foreach(var pv in v.GetVariables())
                    {
                        unbound.Add(pv.ToString());
                    }
                    unbound = unbound.DistinctBy(x => x.ToString()).ToList();
                }
                this.FindPredicateVar(n.LeftNode, ref unbound);
                this.FindPredicateVar(n.RightNode, ref unbound);
            }
        }

        public List<string> GetBoundVar()
        {
            List<string> temp = new List<string>();
            this.FindBoundVar(this._root, ref temp);
            return temp;
        }

        public List<string> GetUnboundVar()
        {
            List<string> tempUnbound = new List<string>();
            List<string> tempBound = new List<string>();
            this.FindPredicateVar(this._root, ref tempUnbound);
            this.FindBoundVar(this._root, ref tempBound);
            foreach(var v in tempBound)
            {
                if(tempUnbound.Contains(v))
                {
                    tempUnbound.Remove(v);
                }
            }
            return tempUnbound;
        }
    }
}
