namespace MYSQLToPLSQLConverter
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            button1 = new Button();
            QueryInput = new TextBox();
            label2 = new Label();
            QueryOuput = new TextBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(25, 10);
            label1.Name = "label1";
            label1.Size = new Size(67, 15);
            label1.TabIndex = 0;
            label1.Text = "Sorgu Giriş:";
            label1.Click += label1_Click;
            // 
            // button1
            // 
            button1.Location = new Point(707, 173);
            button1.Margin = new Padding(3, 2, 3, 2);
            button1.Name = "button1";
            button1.Size = new Size(89, 56);
            button1.TabIndex = 1;
            button1.Text = "Çevir";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // QueryInput
            // 
            QueryInput.Location = new Point(25, 48);
            QueryInput.Margin = new Padding(3, 2, 3, 2);
            QueryInput.Multiline = true;
            QueryInput.Name = "QueryInput";
            QueryInput.Size = new Size(624, 733);
            QueryInput.TabIndex = 2;
            QueryInput.TextChanged += QueryInput_TextChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(853, 9);
            label2.Name = "label2";
            label2.Size = new Size(34, 15);
            label2.TabIndex = 3;
            label2.Text = "Çıktı:";
            // 
            // QueryOuput
            // 
            QueryOuput.Location = new Point(853, 48);
            QueryOuput.Multiline = true;
            QueryOuput.Name = "QueryOuput";
            QueryOuput.Size = new Size(654, 732);
            QueryOuput.TabIndex = 4;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1519, 792);
            Controls.Add(QueryOuput);
            Controls.Add(label2);
            Controls.Add(QueryInput);
            Controls.Add(button1);
            Controls.Add(label1);
            Margin = new Padding(3, 2, 3, 2);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button button1;
        private TextBox QueryInput;
        private Label label2;
        private Label QueryResult;
        private TextBox QueryOuput;
    }
}