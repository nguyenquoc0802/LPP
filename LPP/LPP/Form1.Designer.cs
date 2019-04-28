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
            this.tbTruthTable = new System.Windows.Forms.TextBox();
            this.tbHashCode = new System.Windows.Forms.TextBox();
            this.tbSimplified = new System.Windows.Forms.TextBox();
            this.tbDisjunctiveNormalForm = new System.Windows.Forms.TextBox();
            this.btnReadDisjunction = new System.Windows.Forms.Button();
            this.tbSimplifiedDisjunction = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnRead
            // 
            this.btnRead.Location = new System.Drawing.Point(12, 12);
            this.btnRead.Name = "btnRead";
            this.btnRead.Size = new System.Drawing.Size(75, 20);
            this.btnRead.TabIndex = 0;
            this.btnRead.Text = "Read";
            this.btnRead.UseVisualStyleBackColor = true;
            this.btnRead.Click += new System.EventHandler(this.btnRead_Click);
            // 
            // tbInput
            // 
            this.tbInput.Location = new System.Drawing.Point(121, 12);
            this.tbInput.Name = "tbInput";
            this.tbInput.Size = new System.Drawing.Size(695, 20);
            this.tbInput.TabIndex = 1;
            // 
            // tbOutputInfix
            // 
            this.tbOutputInfix.Location = new System.Drawing.Point(121, 48);
            this.tbOutputInfix.Name = "tbOutputInfix";
            this.tbOutputInfix.Size = new System.Drawing.Size(822, 20);
            this.tbOutputInfix.TabIndex = 1;
            // 
            // lbInfix
            // 
            this.lbInfix.AutoSize = true;
            this.lbInfix.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbInfix.Location = new System.Drawing.Point(12, 48);
            this.lbInfix.Name = "lbInfix";
            this.lbInfix.Size = new System.Drawing.Size(89, 17);
            this.lbInfix.TabIndex = 2;
            this.lbInfix.Text = "Infix Notation";
            // 
            // btnDraw
            // 
            this.btnDraw.Enabled = false;
            this.btnDraw.Location = new System.Drawing.Point(12, 146);
            this.btnDraw.Name = "btnDraw";
            this.btnDraw.Size = new System.Drawing.Size(75, 20);
            this.btnDraw.TabIndex = 0;
            this.btnDraw.Text = "Draw Tree";
            this.btnDraw.UseVisualStyleBackColor = true;
            this.btnDraw.Click += new System.EventHandler(this.btnDraw_Click);
            // 
            // tbTruthTable
            // 
            this.tbTruthTable.BackColor = System.Drawing.Color.White;
            this.tbTruthTable.Location = new System.Drawing.Point(12, 405);
            this.tbTruthTable.Multiline = true;
            this.tbTruthTable.Name = "tbTruthTable";
            this.tbTruthTable.ReadOnly = true;
            this.tbTruthTable.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbTruthTable.Size = new System.Drawing.Size(451, 209);
            this.tbTruthTable.TabIndex = 3;
            // 
            // tbHashCode
            // 
            this.tbHashCode.Location = new System.Drawing.Point(822, 12);
            this.tbHashCode.Name = "tbHashCode";
            this.tbHashCode.Size = new System.Drawing.Size(121, 20);
            this.tbHashCode.TabIndex = 1;
            // 
            // tbSimplified
            // 
            this.tbSimplified.BackColor = System.Drawing.Color.White;
            this.tbSimplified.Location = new System.Drawing.Point(488, 405);
            this.tbSimplified.Multiline = true;
            this.tbSimplified.Name = "tbSimplified";
            this.tbSimplified.ReadOnly = true;
            this.tbSimplified.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbSimplified.Size = new System.Drawing.Size(455, 209);
            this.tbSimplified.TabIndex = 3;
            // 
            // tbDisjunctiveNormalForm
            // 
            this.tbDisjunctiveNormalForm.Location = new System.Drawing.Point(143, 84);
            this.tbDisjunctiveNormalForm.Name = "tbDisjunctiveNormalForm";
            this.tbDisjunctiveNormalForm.Size = new System.Drawing.Size(800, 20);
            this.tbDisjunctiveNormalForm.TabIndex = 1;
            // 
            // btnReadDisjunction
            // 
            this.btnReadDisjunction.Enabled = false;
            this.btnReadDisjunction.Location = new System.Drawing.Point(12, 84);
            this.btnReadDisjunction.Name = "btnReadDisjunction";
            this.btnReadDisjunction.Size = new System.Drawing.Size(125, 46);
            this.btnReadDisjunction.TabIndex = 0;
            this.btnReadDisjunction.Text = "Read Disjunctive Form";
            this.btnReadDisjunction.UseVisualStyleBackColor = true;
            this.btnReadDisjunction.Click += new System.EventHandler(this.btnReadDisjunction_Click);
            // 
            // tbSimplifiedDisjunction
            // 
            this.tbSimplifiedDisjunction.Location = new System.Drawing.Point(143, 110);
            this.tbSimplifiedDisjunction.Name = "tbSimplifiedDisjunction";
            this.tbSimplifiedDisjunction.Size = new System.Drawing.Size(800, 20);
            this.tbSimplifiedDisjunction.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(955, 626);
            this.Controls.Add(this.tbSimplified);
            this.Controls.Add(this.tbTruthTable);
            this.Controls.Add(this.lbInfix);
            this.Controls.Add(this.tbHashCode);
            this.Controls.Add(this.tbSimplifiedDisjunction);
            this.Controls.Add(this.tbDisjunctiveNormalForm);
            this.Controls.Add(this.tbOutputInfix);
            this.Controls.Add(this.tbInput);
            this.Controls.Add(this.btnReadDisjunction);
            this.Controls.Add(this.btnDraw);
            this.Controls.Add(this.btnRead);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnRead;
        private System.Windows.Forms.TextBox tbInput;
        private System.Windows.Forms.TextBox tbOutputInfix;
        private System.Windows.Forms.Label lbInfix;
        private System.Windows.Forms.Button btnDraw;
        private System.Windows.Forms.TextBox tbTruthTable;
        private System.Windows.Forms.TextBox tbHashCode;
        private System.Windows.Forms.TextBox tbSimplified;
        private System.Windows.Forms.TextBox tbDisjunctiveNormalForm;
        private System.Windows.Forms.Button btnReadDisjunction;
        private System.Windows.Forms.TextBox tbSimplifiedDisjunction;
    }
}

