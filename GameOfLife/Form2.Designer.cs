namespace GameOfLife
{
    partial class Form2
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.milliUpDown = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.xUpDown = new System.Windows.Forms.NumericUpDown();
            this.yUpDown = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.colorLabel = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.milliUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.yUpDown)).BeginInit();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(-1, 2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(467, 316);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.milliUpDown);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(459, 287);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Time";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.yUpDown);
            this.tabPage2.Controls.Add(this.xUpDown);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(459, 287);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Size";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(228, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Milliseconds Between Generations:";
            // 
            // milliUpDown
            // 
            this.milliUpDown.Location = new System.Drawing.Point(12, 69);
            this.milliUpDown.Name = "milliUpDown";
            this.milliUpDown.Size = new System.Drawing.Size(120, 22);
            this.milliUpDown.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "X";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(17, 17);
            this.label3.TabIndex = 1;
            this.label3.Text = "Y";
            // 
            // xUpDown
            // 
            this.xUpDown.Location = new System.Drawing.Point(34, 50);
            this.xUpDown.Name = "xUpDown";
            this.xUpDown.Size = new System.Drawing.Size(120, 22);
            this.xUpDown.TabIndex = 2;
            // 
            // yUpDown
            // 
            this.yUpDown.Location = new System.Drawing.Point(34, 78);
            this.yUpDown.Name = "yUpDown";
            this.yUpDown.Size = new System.Drawing.Size(120, 22);
            this.yUpDown.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(31, 21);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 17);
            this.label4.TabIndex = 4;
            this.label4.Text = "Grid Size";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.colorLabel);
            this.tabPage3.Controls.Add(this.textBox1);
            this.tabPage3.Location = new System.Drawing.Point(4, 25);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(459, 287);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Color";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(57, 46);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(25, 22);
            this.textBox1.TabIndex = 0;
            // 
            // colorLabel
            // 
            this.colorLabel.AutoSize = true;
            this.colorLabel.Location = new System.Drawing.Point(10, 46);
            this.colorLabel.Name = "colorLabel";
            this.colorLabel.Size = new System.Drawing.Size(41, 17);
            this.colorLabel.TabIndex = 1;
            this.colorLabel.Text = "Color";
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(467, 316);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form2";
            this.Text = "Form2";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.milliUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.yUpDown)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.NumericUpDown milliUpDown;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown yUpDown;
        private System.Windows.Forms.NumericUpDown xUpDown;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Label colorLabel;
        private System.Windows.Forms.TextBox textBox1;
    }
}