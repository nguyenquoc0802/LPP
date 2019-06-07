using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LPP.Connectives;
using LPP.Predicate;

namespace LPP.Semantic_Tableaux
{
    //need to improve for performance
    class SemanticTableaux
    {
        private Node _treeRoot;
        private DerivationStep _root;
        private Stack<Node> _branchingPoint;

        public SemanticTableaux(Node treeRoot)
        {
            this._branchingPoint = new Stack<Node>();
            this._root = new DerivationStep();
            this._treeRoot = treeRoot;
        }

        private void SetIndexHelper(Node root, ref int index)
        {
            if (root != null)
            {
                root.Index = index;
                index++;
                this.SetIndexHelper(root.LeftNode, ref index);
                this.SetIndexHelper(root.RightNode, ref index);
            }
        }

        public string DrawTree()
        {
            int index = 1;
            string content = "graph logic {\r\nnode [ fontname = \"Arial\" ]\r\n";
            FunctionHelper.SetIndexHelper(this._root, ref index);
            return FunctionHelper.DrawTreeHelper(this._root, ref content) + "}";
        }

        public void CreateProofTree()
        {
            this._root.AddFormulas(new Negation("~", _treeRoot));
            this._branchingPoint.Push(this._root);
            while(this._branchingPoint.Count > 0)
            {
                DerivationStep s = (DerivationStep)this._branchingPoint.Pop();
                if (FunctionHelper.IsClosed(s.GetFormulas()))
                {
                    s.RightNode = new DerivationStep();
                    s.RightNode.AddFormulas(new Node("X"));
                }
                else
                {
                    if (this.UnBranchingRules(ref s) || this.BranchingRules(ref s))
                    {
                        continue;
                    }
                }
            }
        }
        
        public bool BranchingRules(ref DerivationStep s)
        {
            List<Node> temp = s.GetFormulas().ToList();
            foreach (var n in s.GetFormulas())
            {
                int index = s.GetFormulas().IndexOf(n);
                if (n is Negation && n.RightNode is AndOperator a)
                {
                    temp.RemoveAt(index);
                    s.LeftNode = new DerivationStep();
                    s.LeftNode.AddFormulas(new Negation("~", a.LeftNode));
                    s.LeftNode.Merge(temp);
                    this._branchingPoint.Push(s.LeftNode);
                    s.RightNode = new DerivationStep();
                    s.RightNode.AddFormulas(new Negation("~", a.RightNode));
                    s.RightNode.Merge(temp);
                    this._branchingPoint.Push(s.RightNode);
                    return true;
                }
                else if (n is Implication i)
                {
                    temp.RemoveAt(index);
                    s.LeftNode = new DerivationStep();
                    s.LeftNode.AddFormulas(new Negation("~", i.LeftNode));
                    s.LeftNode.Merge(temp);
                    this._branchingPoint.Push(s.LeftNode);
                    s.RightNode = new DerivationStep();
                    s.RightNode.AddFormulas(i.RightNode);
                    s.RightNode.Merge(temp);
                    this._branchingPoint.Push(s.RightNode);
                    return true;
                }
                else if (n is BiImplication b)
                {
                    temp.RemoveAt(index);
                    s.LeftNode = new DerivationStep();
                    s.LeftNode.AddFormulas(b.LeftNode);
                    s.LeftNode.AddFormulas(b.RightNode);
                    s.LeftNode.Merge(temp);
                    this._branchingPoint.Push(s.LeftNode);
                    s.RightNode = new DerivationStep();
                    s.RightNode.AddFormulas(new Negation("~", b.LeftNode));
                    s.RightNode.AddFormulas(new Negation("~", b.RightNode));
                    s.RightNode.Merge(temp);
                    this._branchingPoint.Push(s.RightNode);
                    return true;
                }
                else if (n is Negation && n.RightNode is BiImplication b1)
                {
                    temp.RemoveAt(index);
                    s.LeftNode = new DerivationStep();
                    s.LeftNode.AddFormulas(b1.LeftNode);
                    s.LeftNode.AddFormulas(new Negation("~", b1.RightNode));
                    s.LeftNode.Merge(temp);
                    this._branchingPoint.Push(s.LeftNode);
                    s.RightNode = new DerivationStep();
                    s.RightNode.AddFormulas(new Negation("~", b1.LeftNode));
                    s.RightNode.AddFormulas(b1.RightNode);
                    s.RightNode.Merge(temp);
                    this._branchingPoint.Push(s.RightNode);
                    return true;
                }
                else if (n is OrOperator o)
                {
                    temp.RemoveAt(index);
                    s.LeftNode = new DerivationStep();
                    s.LeftNode.AddFormulas(o.LeftNode);
                    s.LeftNode.Merge(temp);
                    this._branchingPoint.Push(s.LeftNode);
                    s.RightNode = new DerivationStep();
                    s.RightNode.AddFormulas(o.RightNode);
                    s.RightNode.Merge(temp);
                    this._branchingPoint.Push(s.RightNode);
                    return true;
                }
            }
            return false;
        }

        public bool UnBranchingRules(ref DerivationStep s)
        {
            List<Node> temp = s.GetFormulas().ToList();
            foreach (var n in s.GetFormulas())
            {
                int index = s.GetFormulas().IndexOf(n);
                if (n is Negation && n.RightNode is OrOperator o)
                {
                    temp.RemoveAt(index);
                    s.RightNode = new DerivationStep();
                    s.RightNode.AddFormulas(new Negation("~", o.LeftNode));
                    s.RightNode.AddFormulas(new Negation("~", o.RightNode));
                    s.RightNode.Merge(temp);
                    this._branchingPoint.Push(s.RightNode);
                    return true;
                }
                else if (n is Negation && n.RightNode is Negation n1)
                {
                    temp.RemoveAt(index);
                    s.RightNode = new DerivationStep();
                    s.RightNode.AddFormulas(n1.RightNode);
                    s.RightNode.Merge(temp);
                    this._branchingPoint.Push(s.RightNode);
                    return true;
                }
                else if (n is Negation && n.RightNode is Implication i)
                {
                    temp.RemoveAt(index);
                    s.RightNode = new DerivationStep();
                    s.RightNode.AddFormulas(i.LeftNode);
                    s.RightNode.AddFormulas(new Negation("~", i.RightNode));
                    s.RightNode.Merge(temp);
                    this._branchingPoint.Push(s.RightNode);
                    return true;
                }
                else if (n is AndOperator a)
                {
                    temp.RemoveAt(index);
                    s.RightNode = new DerivationStep();
                    s.RightNode.AddFormulas(a.LeftNode);
                    s.RightNode.AddFormulas(a.RightNode);
                    s.RightNode.Merge(temp);
                    this._branchingPoint.Push(s.RightNode);
                    return true;
                }
            }
            return false;
        }
    }
}
