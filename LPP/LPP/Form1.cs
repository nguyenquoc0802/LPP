﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

        }
    }
}
