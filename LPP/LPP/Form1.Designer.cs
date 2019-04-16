namespace LPP
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnRead = new System.Windows.Forms.Button();
            this.tbInput = new System.Windows.Forms.TextBox();
            this.tbOutputInfix = new System.Windows.Forms.TextBox();
            this.lbInfix = new System.Windows.Forms.Label();
            this.btnDraw = new System.Windows.Forms.Button();
            this.tbTest = new System.Windows.Forms.TextBox();
            this.dgvTruthTable = new System.Windows.Forms.DataGridView();
            this.btnTruthTable = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTruthTable)).BeginInit();
            this.SuspendLayout();
            // 
            // btnRead
            // 
            this.btnRead.Location = new System.Drawing.Point(16, 15);
            this.btnRead.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnRead.Name = "btnRead";
            this.btnRead.Size = new System.Drawing.Size(100, 28);
            this.btnRead.TabIndex = 0;
            this.btnRead.Text = "Read";
            this.btnRead.UseVisualStyleBackColor = true;
            this.btnRead.Click += new System.EventHandler(this.btnRead_Click);
            // 
            // tbInput
            // 
            this.tbInput.Location = new System.Drawing.Point(161, 15);
            this.tbInput.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbInput.Name = "tbInput";
            this.tbInput.Size = new System.Drawing.Size(847, 22);
            this.tbInput.TabIndex = 1;
            // 
            // tbOutputInfix
            // 
            this.tbOutputInfix.Location = new System.Drawing.Point(161, 59);
            this.tbOutputInfix.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbOutputInfix.Name = "tbOutputInfix";
            this.tbOutputInfix.Size = new System.Drawing.Size(847, 22);
            this.tbOutputInfix.TabIndex = 1;
            // 
            // lbInfix
            // 
            this.lbInfix.AutoSize = true;
            this.lbInfix.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbInfix.Location = new System.Drawing.Point(16, 59);
            this.lbInfix.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbInfix.Name = "lbInfix";
            this.lbInfix.Size = new System.Drawing.Size(106, 20);
            this.lbInfix.TabIndex = 2;
            this.lbInfix.Text = "Infix Notation";
            // 
            // btnDraw
            // 
            this.btnDraw.Enabled = false;
            this.btnDraw.Location = new System.Drawing.Point(16, 108);
            this.btnDraw.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnDraw.Name = "btnDraw";
            this.btnDraw.Size = new System.Drawing.Size(100, 28);
            this.btnDraw.TabIndex = 0;
            this.btnDraw.Text = "Draw Tree";
            this.btnDraw.UseVisualStyleBackColor = true;
            this.btnDraw.Click += new System.EventHandler(this.btnDraw_Click);
            // 
            // tbTest
            // 
            this.tbTest.Location = new System.Drawing.Point(749, 282);
            this.tbTest.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbTest.Multiline = true;
            this.tbTest.Name = "tbTest";
            this.tbTest.Size = new System.Drawing.Size(300, 256);
            this.tbTest.TabIndex = 1;
            // 
            // dgvTruthTable
            // 
            this.dgvTruthTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTruthTable.Location = new System.Drawing.Point(16, 282);
            this.dgvTruthTable.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgvTruthTable.Name = "dgvTruthTable";
            this.dgvTruthTable.Size = new System.Drawing.Size(686, 257);
            this.dgvTruthTable.TabIndex = 3;
            // 
            // btnTruthTable
            // 
            this.btnTruthTable.Enabled = false;
            this.btnTruthTable.Location = new System.Drawing.Point(16, 144);
            this.btnTruthTable.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnTruthTable.Name = "btnTruthTable";
            this.btnTruthTable.Size = new System.Drawing.Size(100, 28);
            this.btnTruthTable.TabIndex = 0;
            this.btnTruthTable.Text = "Truth Table";
            this.btnTruthTable.UseVisualStyleBackColor = true;
            this.btnTruthTable.Click += new System.EventHandler(this.btnTruthTable_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.dgvTruthTable);
            this.Controls.Add(this.lbInfix);
            this.Controls.Add(this.tbTest);
            this.Controls.Add(this.tbOutputInfix);
            this.Controls.Add(this.tbInput);
            this.Controls.Add(this.btnTruthTable);
            this.Controls.Add(this.btnDraw);
            this.Controls.Add(this.btnRead);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dgvTruthTable)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnRead;
        private System.Windows.Forms.TextBox tbInput;
        private System.Windows.Forms.TextBox tbOutputInfix;
        private System.Windows.Forms.Label lbInfix;
        private System.Windows.Forms.Button btnDraw;
        private System.Windows.Forms.TextBox tbTest;
        private System.Windows.Forms.DataGridView dgvTruthTable;
        private System.Windows.Forms.Button btnTruthTable;
    }
}

