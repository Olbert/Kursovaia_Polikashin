namespace Kursovaia_Gubaidullin
{
    partial class Settings
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SCompiler = new System.Windows.Forms.TextBox();
            this.BrowseSharp = new System.Windows.Forms.Button();
            this.Back = new System.Windows.Forms.Button();
            this.CCompiler = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.GameTheory = new System.Windows.Forms.CheckBox();
            this.BrowseCpp = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(534, 40);
            this.label1.TabIndex = 0;
            this.label1.Text = "Если в программе предполагается компиляция \r\nприложения, укажите путь к соответст" +
    "вующим компиляторам\r\n";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.label2.Location = new System.Drawing.Point(14, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "С#";
            // 
            // SCompiler
            // 
            this.SCompiler.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.SCompiler.Location = new System.Drawing.Point(87, 75);
            this.SCompiler.Name = "SCompiler";
            this.SCompiler.Size = new System.Drawing.Size(499, 26);
            this.SCompiler.TabIndex = 3;
            // 
            // BrowseSharp
            // 
            this.BrowseSharp.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.BrowseSharp.Location = new System.Drawing.Point(592, 75);
            this.BrowseSharp.Name = "BrowseSharp";
            this.BrowseSharp.Size = new System.Drawing.Size(42, 26);
            this.BrowseSharp.TabIndex = 4;
            this.BrowseSharp.Text = "...";
            this.BrowseSharp.UseVisualStyleBackColor = true;
            this.BrowseSharp.Click += new System.EventHandler(this.BrowseSharp_Click);
            // 
            // Back
            // 
            this.Back.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.Back.Location = new System.Drawing.Point(513, 185);
            this.Back.Name = "Back";
            this.Back.Size = new System.Drawing.Size(148, 64);
            this.Back.TabIndex = 5;
            this.Back.Text = "Назад";
            this.Back.UseVisualStyleBackColor = true;
            this.Back.Click += new System.EventHandler(this.Back_Click);
            // 
            // CCompiler
            // 
            this.CCompiler.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.CCompiler.Location = new System.Drawing.Point(87, 117);
            this.CCompiler.Name = "CCompiler";
            this.CCompiler.Size = new System.Drawing.Size(499, 26);
            this.CCompiler.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.label3.Location = new System.Drawing.Point(12, 120);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 20);
            this.label3.TabIndex = 7;
            this.label3.Text = "C++";
            // 
            // GameTheory
            // 
            this.GameTheory.AutoSize = true;
            this.GameTheory.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.GameTheory.Location = new System.Drawing.Point(87, 168);
            this.GameTheory.Name = "GameTheory";
            this.GameTheory.Size = new System.Drawing.Size(328, 24);
            this.GameTheory.TabIndex = 9;
            this.GameTheory.Text = "Использовать теорию игр в далоге";
            this.GameTheory.UseVisualStyleBackColor = true;
            this.GameTheory.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // BrowseCpp
            // 
            this.BrowseCpp.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.BrowseCpp.Location = new System.Drawing.Point(592, 120);
            this.BrowseCpp.Name = "BrowseCpp";
            this.BrowseCpp.Size = new System.Drawing.Size(42, 26);
            this.BrowseCpp.TabIndex = 10;
            this.BrowseCpp.Text = "...";
            this.BrowseCpp.UseVisualStyleBackColor = true;
            this.BrowseCpp.Click += new System.EventHandler(this.BrowseCpp_Click);
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(673, 261);
            this.Controls.Add(this.BrowseCpp);
            this.Controls.Add(this.GameTheory);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.CCompiler);
            this.Controls.Add(this.Back);
            this.Controls.Add(this.BrowseSharp);
            this.Controls.Add(this.SCompiler);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Settings";
            this.Text = "Settings";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox SCompiler;
        private System.Windows.Forms.Button BrowseSharp;
        private System.Windows.Forms.Button Back;
        private System.Windows.Forms.TextBox CCompiler;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox GameTheory;
        private System.Windows.Forms.Button BrowseCpp;
    }
}