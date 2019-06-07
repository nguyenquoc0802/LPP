using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using LPP.Semantic_Tableaux;

namespace LPP
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            myTree = new Tree();
        }

        Tree myTree;
        SemanticTableaux proofTree;

        private void btnRead_Click(object sender, EventArgs e)
        {
            //enable button
            btnDraw.Enabled = true;
            btnDrawProofTree.Enabled = true;
            //create binary tree
            string proposition = tbInput.Text;
            //create normal tree
            myTree.InsertTree(proposition);
            //declare and create proof tree
            proofTree = new SemanticTableaux(myTree.GetRoot());
            proofTree.CreateProofTree();
            //check input
            if (FunctionHelper.EvaluateFormula(proposition))
            {
                tbOutputInfix.Text = myTree.DisplayInOrder();
            }
            else
            {
                btnReadDisjunction.Enabled = true;
                btnReadNAND.Enabled = true;
                TruthTable myTruthTable = new TruthTable(myTree.GetRoot());
                lbNAND.Items.Clear();
                lbDisjunctiveNormalForm.Items.Clear();
                //display 
                tbOutputInfix.Text = myTree.DisplayInOrder();
                tbTruthTable.Text = myTruthTable.GetTableInString();
                tbHashCode.Text = myTruthTable.GetTruthTableHashCode();
                lbDisjunctiveNormalForm.Items.Add(myTruthTable.DisjunctiveNormalForm());
                tbSimplified.Text = myTruthTable.MinimizeTruthTable();
                tbSimplifiedDisjunction.Text = myTruthTable.SimplifiedTableDisjunctiveForm();
                lbNAND.Items.Add(myTree.DisplayOnlyNAND());
            }
        }

        private void btnDraw_Click(object sender, EventArgs e)
        {
            string content = myTree.DrawTree();
            File.WriteAllText(@"tree.dot", content);
            Process dot = new Process();
            dot.StartInfo.FileName = @".\External\dot.exe";
            dot.StartInfo.Arguments = "-Tpng -otree.png tree.dot";
            dot.Start();
            dot.WaitForExit();
            Process.Start(@"tree.png");
        }

        private void btnReadDisjunction_Click(object sender, EventArgs e)
        {
            //convert infix to prefix
            TruthTable myTruthTable = new TruthTable(myTree.GetRoot());
            string prefixForm = myTree.InfixToPrefix(myTruthTable.DisjunctiveNormalForm());
            //create tree
            myTree.InsertTree(prefixForm);
            lbDisjunctiveNormalForm.Items.Clear();
            lbNAND.Items.Clear();
            //display
            tbOutputInfix.Text = myTree.DisplayInOrder();
            myTruthTable = new TruthTable(myTree.GetRoot());
            tbTruthTable.Text = myTruthTable.GetTableInString();
            tbHashCode.Text = myTruthTable.GetTruthTableHashCode();
            lbDisjunctiveNormalForm.Items.Add(myTruthTable.DisjunctiveNormalForm());
            lbNAND.Items.Add(myTree.DisplayOnlyNAND());
        }

        private void btnReadNAND_Click(object sender, EventArgs e)
        {
            string proposition = myTree.DisplayOnlyNAND();
            myTree.InsertTree(proposition);
            TruthTable myTruthTable = new TruthTable(myTree.GetRoot());
            lbDisjunctiveNormalForm.Items.Clear();
            //display 
            tbOutputInfix.Text = myTree.DisplayInOrder();
            tbTruthTable.Text = myTruthTable.GetTableInString();
            tbHashCode.Text = myTruthTable.GetTruthTableHashCode();
            lbDisjunctiveNormalForm.Items.Add(myTruthTable.DisjunctiveNormalForm());
            tbSimplified.Text = myTruthTable.MinimizeTruthTable();
            tbSimplifiedDisjunction.Text = myTruthTable.SimplifiedTableDisjunctiveForm();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            myTree = null;
            tbInput.Text = "";
            tbOutputInfix.Text = "";
            tbTruthTable.Text = "";
            tbHashCode.Text = "";
            tbSimplified.Text = "";
            tbSimplifiedDisjunction.Text = "";
            lbDisjunctiveNormalForm.Items.Clear();
            lbNAND.Items.Clear();
        }

        private void btnDrawProofTree_Click(object sender, EventArgs e)
        {
            string content = proofTree.DrawTree();
            File.WriteAllText(@"tree.dot", content);
            Process dot = new Process();
            dot.StartInfo.FileName = @".\External\dot.exe";
            dot.StartInfo.Arguments = "-Tpng -otree.png tree.dot";
            dot.Start();
            dot.WaitForExit();
            Process.Start(@"tree.png");
        }
    }
}
