namespace Kursovaia_Gubaidullin
{
    partial class Creator
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
            this.QuestionBox = new System.Windows.Forms.TextBox();
            this.NextPart = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SourceGrid = new System.Windows.Forms.DataGridView();
            this.Answer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Next = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OK = new System.Windows.Forms.Button();
            this.NextQuestion = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.NewDialog = new System.Windows.Forms.ToolStripMenuItem();
            this.EditDialog = new System.Windows.Forms.ToolStripMenuItem();
            this.Save = new System.Windows.Forms.ToolStripMenuItem();
            this.TypeOfView = new System.Windows.Forms.ToolStripMenuItem();
            this.SimpleView = new System.Windows.Forms.ToolStripMenuItem();
            this.SourceView = new System.Windows.Forms.ToolStripMenuItem();
            this.Help = new System.Windows.Forms.ToolStripMenuItem();
            this.SourceBox = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.SourceGrid)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // QuestionBox
            // 
            this.QuestionBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.QuestionBox.Location = new System.Drawing.Point(12, 66);
            this.QuestionBox.Name = "QuestionBox";
            this.QuestionBox.Size = new System.Drawing.Size(417, 29);
            this.QuestionBox.TabIndex = 0;
            // 
            // NextPart
            // 
            this.NextPart.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.NextPart.Location = new System.Drawing.Point(435, 136);
            this.NextPart.Name = "NextPart";
            this.NextPart.Size = new System.Drawing.Size(123, 48);
            this.NextPart.TabIndex = 1;
            this.NextPart.Text = "Следующая часть диалога";
            this.NextPart.UseVisualStyleBackColor = true;
            this.NextPart.Click += new System.EventHandler(this.NextPart_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.label1.Location = new System.Drawing.Point(12, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(495, 24);
            this.label1.TabIndex = 2;
            this.label1.Text = "Введите ваш вопрос, возможные ответы и переходы";
            // 
            // SourceGrid
            // 
            this.SourceGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.SourceGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Answer,
            this.Next});
            this.SourceGrid.Location = new System.Drawing.Point(12, 107);
            this.SourceGrid.Name = "SourceGrid";
            this.SourceGrid.Size = new System.Drawing.Size(400, 200);
            this.SourceGrid.TabIndex = 3;
            // 
            // Answer
            // 
            this.Answer.FillWeight = 250F;
            this.Answer.HeaderText = "Ответ";
            this.Answer.Name = "Answer";
            this.Answer.Width = 270;
            // 
            // Next
            // 
            this.Next.HeaderText = "Переход";
            this.Next.Name = "Next";
            this.Next.Width = 70;
            // 
            // OK
            // 
            this.OK.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.OK.Location = new System.Drawing.Point(435, 244);
            this.OK.Name = "OK";
            this.OK.Size = new System.Drawing.Size(123, 48);
            this.OK.TabIndex = 4;
            this.OK.Text = "Готово";
            this.OK.UseVisualStyleBackColor = true;
            this.OK.Click += new System.EventHandler(this.OK_Click);
            // 
            // NextQuestion
            // 
            this.NextQuestion.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.NextQuestion.Location = new System.Drawing.Point(435, 190);
            this.NextQuestion.Name = "NextQuestion";
            this.NextQuestion.Size = new System.Drawing.Size(123, 48);
            this.NextQuestion.TabIndex = 5;
            this.NextQuestion.Text = "Следующий вопрос";
            this.NextQuestion.UseVisualStyleBackColor = true;
            this.NextQuestion.Click += new System.EventHandler(this.NextQuestion_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.NewDialog,
            this.EditDialog,
            this.Save,
            this.TypeOfView,
            this.Help});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(580, 24);
            this.menuStrip1.TabIndex = 6;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // NewDialog
            // 
            this.NewDialog.Name = "NewDialog";
            this.NewDialog.Size = new System.Drawing.Size(57, 20);
            this.NewDialog.Text = "Новый";
            this.NewDialog.Click += new System.EventHandler(this.NewDialog_Click);
            // 
            // EditDialog
            // 
            this.EditDialog.Name = "EditDialog";
            this.EditDialog.Size = new System.Drawing.Size(66, 20);
            this.EditDialog.Text = "Открыть";
            this.EditDialog.Click += new System.EventHandler(this.EditDialog_Click);
            // 
            // Save
            // 
            this.Save.Name = "Save";
            this.Save.Size = new System.Drawing.Size(77, 20);
            this.Save.Text = "Сохранить";
            this.Save.Click += new System.EventHandler(this.OK_Click);
            // 
            // TypeOfView
            // 
            this.TypeOfView.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SimpleView,
            this.SourceView});
            this.TypeOfView.Name = "TypeOfView";
            this.TypeOfView.Size = new System.Drawing.Size(39, 20);
            this.TypeOfView.Text = "Вид";
            // 
            // SimpleView
            // 
            this.SimpleView.Name = "SimpleView";
            this.SimpleView.Size = new System.Drawing.Size(154, 22);
            this.SimpleView.Text = "Простой";
            this.SimpleView.Click += new System.EventHandler(this.SimpleView_Click);
            // 
            // SourceView
            // 
            this.SourceView.Name = "SourceView";
            this.SourceView.Size = new System.Drawing.Size(154, 22);
            this.SourceView.Text = "Расширенный";
            this.SourceView.Click += new System.EventHandler(this.SourceView_Click);
            // 
            // Help
            // 
            this.Help.Name = "Help";
            this.Help.Size = new System.Drawing.Size(65, 20);
            this.Help.Text = "Справка";
            this.Help.Click += new System.EventHandler(this.Help_Click);
            // 
            // SourceBox
            // 
            this.SourceBox.Location = new System.Drawing.Point(12, 62);
            this.SourceBox.Name = "SourceBox";
            this.SourceBox.Size = new System.Drawing.Size(555, 245);
            this.SourceBox.TabIndex = 7;
            this.SourceBox.Text = "";
            this.SourceBox.Visible = false;
            // 
            // Creator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(580, 318);
            this.Controls.Add(this.SourceBox);
            this.Controls.Add(this.NextQuestion);
            this.Controls.Add(this.OK);
            this.Controls.Add(this.SourceGrid);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.NextPart);
            this.Controls.Add(this.QuestionBox);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Creator";
            this.Text = "Creator";
            ((System.ComponentModel.ISupportInitialize)(this.SourceGrid)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox QuestionBox;
        private System.Windows.Forms.Button NextPart;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView SourceGrid;
        private System.Windows.Forms.Button OK;
        private System.Windows.Forms.Button NextQuestion;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem TypeOfView;
        private System.Windows.Forms.ToolStripMenuItem SimpleView;
        private System.Windows.Forms.ToolStripMenuItem SourceView;
        private System.Windows.Forms.RichTextBox SourceBox;
        private System.Windows.Forms.ToolStripMenuItem NewDialog;
        private System.Windows.Forms.ToolStripMenuItem EditDialog;
        private System.Windows.Forms.DataGridViewTextBoxColumn Answer;
        private System.Windows.Forms.DataGridViewTextBoxColumn Next;
        private System.Windows.Forms.ToolStripMenuItem Save;
        private System.Windows.Forms.ToolStripMenuItem Help;
    }
}