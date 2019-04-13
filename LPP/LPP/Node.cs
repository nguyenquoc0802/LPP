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
        private Node _leftNode;
        private Node _rightNode;
        private Connective _connective;
        private Variable _variable;

        public Connective Connective
        {
            get
            {
                return this._connective;
            }
        }

        public Variable Variable
        {
            get
            {
                return this._variable;
            }
        }

        public Node()
        {
            this._leftNode = null;
            this._rightNode = null;
        }

        public Node(Connective connective): base()
        {
            this._connective = connective;
        }

        public Node(Variable variable)
        {
            this._variable = variable;
        }

        public void InsertLeftNode(Node left)
        {
            this._leftNode = left;
        }

        public void InsertRightNode(Node right)
        {
            this._rightNode = right;
        }

    }
}
