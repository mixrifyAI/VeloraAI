namespace VeloraAI.WinForms
{
    partial class App
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
            tbPrompt = new RichTextBox();
            label1 = new Label();
            label2 = new Label();
            tbResponse = new RichTextBox();
            btnSend = new Button();
            label3 = new Label();
            label4 = new Label();
            tbTemperature = new TextBox();
            tbMaxTokens = new TextBox();
            tbTopP = new TextBox();
            label5 = new Label();
            tbTopK = new TextBox();
            label6 = new Label();
            SuspendLayout();
            // 
            // tbPrompt
            // 
            tbPrompt.Location = new Point(26, 51);
            tbPrompt.Name = "tbPrompt";
            tbPrompt.Size = new Size(333, 120);
            tbPrompt.TabIndex = 0;
            tbPrompt.Text = "";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(22, 26);
            label1.Name = "label1";
            label1.Size = new Size(58, 20);
            label1.TabIndex = 1;
            label1.Text = "Prompt";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(22, 181);
            label2.Name = "label2";
            label2.Size = new Size(72, 20);
            label2.TabIndex = 3;
            label2.Text = "Response";
            // 
            // tbResponse
            // 
            tbResponse.Location = new Point(26, 206);
            tbResponse.Name = "tbResponse";
            tbResponse.Size = new Size(703, 120);
            tbResponse.TabIndex = 2;
            tbResponse.Text = "";
            // 
            // btnSend
            // 
            btnSend.Location = new Point(694, 409);
            btnSend.Name = "btnSend";
            btnSend.Size = new Size(94, 29);
            btnSend.TabIndex = 4;
            btnSend.Text = "Send";
            btnSend.UseVisualStyleBackColor = true;
            btnSend.Click += btnSend_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(374, 26);
            label3.Name = "label3";
            label3.Size = new Size(93, 20);
            label3.TabIndex = 5;
            label3.Text = "Temperature";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(511, 26);
            label4.Name = "label4";
            label4.Size = new Size(82, 20);
            label4.TabIndex = 6;
            label4.Text = "MaxTokens";
            // 
            // tbTemperature
            // 
            tbTemperature.Location = new Point(374, 51);
            tbTemperature.Name = "tbTemperature";
            tbTemperature.Size = new Size(125, 27);
            tbTemperature.TabIndex = 7;
            tbTemperature.Text = "0.3";
            // 
            // tbMaxTokens
            // 
            tbMaxTokens.Location = new Point(511, 51);
            tbMaxTokens.Name = "tbMaxTokens";
            tbMaxTokens.Size = new Size(125, 27);
            tbMaxTokens.TabIndex = 8;
            tbMaxTokens.Text = "80";
            // 
            // tbTopP
            // 
            tbTopP.Location = new Point(374, 124);
            tbTopP.Name = "tbTopP";
            tbTopP.Size = new Size(125, 27);
            tbTopP.TabIndex = 10;
            tbTopP.Text = "0";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(374, 99);
            label5.Name = "label5";
            label5.Size = new Size(42, 20);
            label5.TabIndex = 9;
            label5.Text = "TopP";
            // 
            // tbTopK
            // 
            tbTopK.Location = new Point(511, 124);
            tbTopK.Name = "tbTopK";
            tbTopK.Size = new Size(125, 27);
            tbTopK.TabIndex = 12;
            tbTopK.Text = "0";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(511, 99);
            label6.Name = "label6";
            label6.Size = new Size(43, 20);
            label6.TabIndex = 11;
            label6.Text = "TopK";
            // 
            // App
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(tbTopK);
            Controls.Add(label6);
            Controls.Add(tbTopP);
            Controls.Add(label5);
            Controls.Add(tbMaxTokens);
            Controls.Add(tbTemperature);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(btnSend);
            Controls.Add(label2);
            Controls.Add(tbResponse);
            Controls.Add(label1);
            Controls.Add(tbPrompt);
            Name = "App";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            Load += App_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private RichTextBox tbPrompt;
        private Label label1;
        private Label label2;
        private RichTextBox tbResponse;
        private Button btnSend;
        private Label label3;
        private Label label4;
        private TextBox tbTemperature;
        private TextBox tbMaxTokens;
        private TextBox tbTopP;
        private Label label5;
        private TextBox tbTopK;
        private Label label6;
    }
}
