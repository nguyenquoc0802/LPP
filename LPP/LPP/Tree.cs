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

        //return unique variable list
        public List<Variable> GetUniqueVariableList()
        {
            List<Variable> temp = new List<Variable>();
            this.PopulateListOfVariable(this._root, ref temp);
            // third party library, will try to do by myself
            List<Variable> uniqueList = temp.DistinctBy(v => v.ToString()).ToList();
            return uniqueList;
        }

        private List<Variable> GetVariableList()
        {
            List<Variable> temp = new List<Variable>();
            this.PopulateListOfVariable(this._root, ref temp);
            return temp;
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
        // help with evaluation
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

        // get matrix 
        public string[,] GetTruthTable()
        {
            List<Variable> temp = this.GetUniqueVariableList();
            // all node in case of matching node and in the order from left to right
            List<Variable> allNode = this.GetVariableList();
            int totalVariable = temp.Count;
            string result = "";
            // create matrix with row = 2 ^ n, and column = n + 1(n = totalVariable)
            int rows = Convert.ToInt32(Math.Pow(2, totalVariable));
            string[,] matrix = new string[rows, totalVariable + 1];
            for(int i = 0; i < rows; i++)
            {
                string needValue = this.ConvertToBinary(i, temp.Count);
                for (int j = 0; j < totalVariable; j++)
                {
                    matrix[i, j] = needValue[j].ToString();
                    // check if there is any matching node and set truth value to them
                    foreach(var c in allNode)
                    {
                        if(c.ToString() == temp[j].ToString())
                        {
                            c.TruthValue = needValue[j].ToString();
                        }
                    }
                }
                this.CalculateLogicExpressionHelper(this._root, ref result);
                matrix[i, matrix.GetLength(1) - 1] = result;
            }
            return matrix;
        }

        // convert to binary
        private string ConvertToBinary(int inputNo, int maxNo)
        {
            char[] binaryNo = new char[maxNo];
            string convertBinary = Convert.ToString(inputNo, 2);
            int index = convertBinary.Length - 1;
            for(int i = maxNo - 1; i >= 0; i--)
            {
                if(index >= 0)
                {
                    binaryNo[i] = convertBinary[index];
                    index--;
                }
                else
                {
                    binaryNo[i] = '0';
                }
            }
            return new string(binaryNo);
        }
        //using post order to calculate
        private void CalculateLogicExpressionHelper(Node root, ref string result)
        {
            if(root != null)
            {
                this.CalculateLogicExpressionHelper(root.LeftNode, ref result);
                this.CalculateLogicExpressionHelper(root.RightNode, ref result);
                result = root.CalculateResult();
            }
        }

        //populate list of varible including the same variable
        private void PopulateListOfVariable(Node root, ref List<Variable> variableList)
        {
            //tranverse through the tree using pre-order
            if(root != null)
            {
                if(root is Variable v)
                {
                    variableList.Add(v);
                }
                this.PopulateListOfVariable(root.LeftNode, ref variableList);
                this.PopulateListOfVariable(root.RightNode, ref variableList);
            }
        }
    }
}
