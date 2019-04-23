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

        private void btnRead_Click(object sender, EventArgs e)
        {
            //enable button
            btnDraw.Enabled = true;
            //function
            string proposition = tbInput.Text;
            myTree.InsertTree(proposition);
            tbOutputInfix.Text = myTree.DisplayInOrder();
            TruthTable myTruthTable = new TruthTable(myTree.GetRoot());
            tbTruthTable.Text = myTruthTable.GetTableInString();
            tbHashCode.Text = myTruthTable.GetTruthTableHashCode();
        }

        private void btnDraw_Click(object sender, EventArgs e)
        {
            string content = myTree.DrawTree();
            tbTest.Text = content;
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
