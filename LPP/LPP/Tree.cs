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

        }
    }
}
