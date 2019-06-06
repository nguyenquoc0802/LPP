using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LPP.Semantic_Tableaux
{
    class SemanticTableaux
    {
        private Node _treeRoot;
        private Node _root;
        private Stack<Node> _branchingPoint;

        public SemanticTableaux(Node treeRoot)
        {
            this._treeRoot = treeRoot;
        }

        public bool BranchingRules()
        {


            return false;
        }

        public bool UnBranchingRules()
        {

            return false;
        }
    }
}
