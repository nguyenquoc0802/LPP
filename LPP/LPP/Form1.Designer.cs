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
            this.SuspendLayout();
            // 
            // btnRead
            // 
            this.btnRead.Location = new System.Drawing.Point(12, 12);
            this.btnRead.Name = "btnRead";
            this.btnRead.Size = new System.Drawing.Size(75, 23);
            this.btnRead.TabIndex = 0;
            this.btnRead.Text = "Read";
            this.btnRead.UseVisualStyleBackColor = true;
            this.btnRead.Click += new System.EventHandler(this.btnRead_Click);
            // 
            // tbInput
            // 
            this.tbInput.Location = new System.Drawing.Point(121, 12);
            this.tbInput.Name = "tbInput";
            this.tbInput.Size = new System.Drawing.Size(636, 20);
            this.tbInput.TabIndex = 1;
            // 
            // tbOutputInfix
            // 
            this.tbOutputInfix.Location = new System.Drawing.Point(121, 48);
            this.tbOutputInfix.Name = "tbOutputInfix";
            this.tbOutputInfix.Size = new System.Drawing.Size(636, 20);
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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lbInfix);
            this.Controls.Add(this.tbOutputInfix);
            this.Controls.Add(this.tbInput);
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
    }
}

