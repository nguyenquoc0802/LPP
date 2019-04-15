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
            btnTruthTable.Enabled = true;
            btnDraw.Enabled = true;
            //function
            string proposition = tbInput.Text;
            myTree.InsertTree(proposition);
            tbOutputInfix.Text = myTree.DisplayInOrder();
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

        private void btnTruthTable_Click(object sender, EventArgs e)
        {
            DataTable myTruthTable = new DataTable();
            //set column
            myTruthTable.Clear();
            foreach(var v in myTree.GetVariableList())
            {
                myTruthTable.Columns.Add(v.ToString());
            }
            myTruthTable.Columns.Add(myTree.DisplayInOrder());
            string[,] matrix = myTree.GetTruthTable();
            //display table
            for(int i = 0; i < matrix.GetLength(0); i++)
            {
                int columnPointer = 0;
                DataRow currentRow = myTruthTable.NewRow();
                foreach(var c in myTruthTable.Columns)
                {
                    currentRow[c.ToString()] = matrix[i, columnPointer];
                    columnPointer++;
                }
                myTruthTable.Rows.Add(currentRow);
            }
            dgvTruthTable.DataSource = myTruthTable;
        }
    }
}
