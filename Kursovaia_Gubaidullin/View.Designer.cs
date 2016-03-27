namespace Kursovaia_Gubaidullin
{
    partial class View
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.Answer = new System.Windows.Forms.TextBox();
            this.Protokol = new System.Windows.Forms.RichTextBox();
            this.Errors = new System.Windows.Forms.RichTextBox();
            this.Question = new System.Windows.Forms.Label();
            this.QuestionNum = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.CreateDialog = new System.Windows.Forms.ToolStripLabel();
            this.OpenDialog = new System.Windows.Forms.ToolStripLabel();
            this.Settings = new System.Windows.Forms.ToolStripLabel();
            this.About = new System.Windows.Forms.ToolStripLabel();
            this.AvaliableAnswers = new System.Windows.Forms.ListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.label1.Location = new System.Drawing.Point(12, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Вопрос №";
            // 
            // Answer
            // 
            this.Answer.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.Answer.Location = new System.Drawing.Point(12, 103);
            this.Answer.Name = "Answer";
            this.Answer.Size = new System.Drawing.Size(450, 29);
            this.Answer.TabIndex = 1;
            this.Answer.Text = "Введите ответ";
            // 
            // Protokol
            // 
            this.Protokol.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Protokol.Location = new System.Drawing.Point(524, 28);
            this.Protokol.Name = "Protokol";
            this.Protokol.ReadOnly = true;
            this.Protokol.Size = new System.Drawing.Size(382, 509);
            this.Protokol.TabIndex = 2;
            this.Protokol.Text = "Протокол диалога:";
            // 
            // Errors
            // 
            this.Errors.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Errors.Location = new System.Drawing.Point(12, 382);
            this.Errors.Name = "Errors";
            this.Errors.ReadOnly = true;
            this.Errors.Size = new System.Drawing.Size(506, 155);
            this.Errors.TabIndex = 5;
            this.Errors.Text = "Сообщения об ошибках:";
            // 
            // Question
            // 
            this.Question.AutoSize = true;
            this.Question.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.Question.Location = new System.Drawing.Point(12, 71);
            this.Question.Name = "Question";
            this.Question.Size = new System.Drawing.Size(76, 24);
            this.Question.TabIndex = 6;
            this.Question.Text = "Вопрос";
            // 
            // QuestionNum
            // 
            this.QuestionNum.AutoSize = true;
            this.QuestionNum.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.QuestionNum.Location = new System.Drawing.Point(110, 40);
            this.QuestionNum.Name = "QuestionNum";
            this.QuestionNum.Size = new System.Drawing.Size(20, 24);
            this.QuestionNum.TabIndex = 7;
            this.QuestionNum.Text = "1";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CreateDialog,
            this.OpenDialog,
            this.Settings,
            this.About});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(918, 25);
            this.toolStrip1.TabIndex = 8;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // CreateDialog
            // 
            this.CreateDialog.Name = "CreateDialog";
            this.CreateDialog.Size = new System.Drawing.Size(50, 22);
            this.CreateDialog.Text = "Создать";
            this.CreateDialog.Click += new System.EventHandler(this.CreateDialog_Click);
            // 
            // OpenDialog
            // 
            this.OpenDialog.Name = "OpenDialog";
            this.OpenDialog.Size = new System.Drawing.Size(54, 22);
            this.OpenDialog.Text = "Открыть";
            this.OpenDialog.Click += new System.EventHandler(this.OpenDialog_Click);
            // 
            // Settings
            // 
            this.Settings.Name = "Settings";
            this.Settings.Size = new System.Drawing.Size(67, 22);
            this.Settings.Text = "Настройки";
            this.Settings.Click += new System.EventHandler(this.Settings_Click);
            // 
            // About
            // 
            this.About.Name = "About";
            this.About.Size = new System.Drawing.Size(82, 22);
            this.About.Text = "О программе";
            this.About.Click += new System.EventHandler(this.About_Click);
            // 
            // AvaliableAnswers
            // 
            this.AvaliableAnswers.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.AvaliableAnswers.FormattingEnabled = true;
            this.AvaliableAnswers.ItemHeight = 17;
            this.AvaliableAnswers.Location = new System.Drawing.Point(16, 155);
            this.AvaliableAnswers.Name = "AvaliableAnswers";
            this.AvaliableAnswers.Size = new System.Drawing.Size(502, 191);
            this.AvaliableAnswers.TabIndex = 9;
            this.AvaliableAnswers.SelectedIndexChanged += new System.EventHandler(this.AvaliableAnswers_SelectedIndexChanged);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.button1.Location = new System.Drawing.Point(468, 103);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(50, 29);
            this.button1.TabIndex = 10;
            this.button1.Text = "ОК";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.OK_Click);
            // 
            // Questions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(918, 549);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.AvaliableAnswers);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.QuestionNum);
            this.Controls.Add(this.Question);
            this.Controls.Add(this.Errors);
            this.Controls.Add(this.Protokol);
            this.Controls.Add(this.Answer);
            this.Controls.Add(this.label1);
            this.Name = "Questions";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox Answer;
        private System.Windows.Forms.RichTextBox Protokol;
        private System.Windows.Forms.RichTextBox Errors;
        private System.Windows.Forms.Label Question;
        private System.Windows.Forms.Label QuestionNum;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel CreateDialog;
        private System.Windows.Forms.ToolStripLabel OpenDialog;
        private System.Windows.Forms.ToolStripLabel About;
        private System.Windows.Forms.ToolStripLabel Settings;
        private System.Windows.Forms.ListBox AvaliableAnswers;
        private System.Windows.Forms.Button button1;
    }
}

