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
            ConverterButton = new Button();
            QueryInput = new TextBox();
            label2 = new Label();
            QueryOuput = new TextBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BorderStyle = BorderStyle.FixedSingle;
            label1.Location = new Point(29, 24);
            label1.Name = "label1";
            label1.Size = new Size(61, 22);
            label1.TabIndex = 0;
            label1.Text = "MYSQL:\r\n";
            label1.Click += label1_Click;
            // 
            // ConverterButton
            // 
            ConverterButton.Location = new Point(838, 219);
            ConverterButton.Name = "ConverterButton";
            ConverterButton.Size = new Size(150, 75);
            ConverterButton.TabIndex = 1;
            ConverterButton.Text = "Çevir";
            ConverterButton.UseVisualStyleBackColor = true;
            ConverterButton.Click += ConverterButton_Click;
            // 
            // QueryInput
            // 
            QueryInput.Location = new Point(29, 64);
            QueryInput.Multiline = true;
            QueryInput.Name = "QueryInput";
            QueryInput.Size = new Size(713, 907);
            QueryInput.TabIndex = 2;
            QueryInput.TextChanged += QueryInput_TextChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BorderStyle = BorderStyle.FixedSingle;
            label2.Location = new Point(1094, 24);
            label2.Name = "label2";
            label2.Size = new Size(57, 22);
            label2.TabIndex = 3;
            label2.Text = "Oracle:";
            // 
            // QueryOuput
            // 
            QueryOuput.Location = new Point(1094, 64);
            QueryOuput.Margin = new Padding(3, 4, 3, 4);
            QueryOuput.Multiline = true;
            QueryOuput.Name = "QueryOuput";
            QueryOuput.Size = new Size(747, 907);
            QueryOuput.TabIndex = 4;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1902, 1033);
            Controls.Add(QueryOuput);
            Controls.Add(label2);
            Controls.Add(QueryInput);
            Controls.Add(ConverterButton);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button ConverterButton;
        private TextBox QueryInput;
        private Label label2;
        private Label QueryResult;
        private TextBox QueryOuput;
    }
}