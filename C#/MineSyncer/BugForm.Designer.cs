namespace MineSyncer
{
    partial class BugForm
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
            this.titleBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.reportType = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.bodyText = new System.Windows.Forms.RichTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.sendButton = new System.Windows.Forms.Button();
            this.captchaPic = new System.Windows.Forms.PictureBox();
            this.newCaptcha = new System.Windows.Forms.Button();
            this.captchaLbl = new System.Windows.Forms.Label();
            this.captchaBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.captchaPic)).BeginInit();
            this.SuspendLayout();
            // 
            // titleBox
            // 
            this.titleBox.Location = new System.Drawing.Point(96, 60);
            this.titleBox.Name = "titleBox";
            this.titleBox.Size = new System.Drawing.Size(100, 20);
            this.titleBox.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Title";
            // 
            // reportType
            // 
            this.reportType.FormattingEnabled = true;
            this.reportType.Items.AddRange(new object[] {
            "Bug",
            "Suggestion"});
            this.reportType.Location = new System.Drawing.Point(96, 86);
            this.reportType.Name = "reportType";
            this.reportType.Size = new System.Drawing.Size(100, 21);
            this.reportType.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Type of Report";
            // 
            // bodyText
            // 
            this.bodyText.Location = new System.Drawing.Point(96, 113);
            this.bodyText.Name = "bodyText";
            this.bodyText.Size = new System.Drawing.Size(265, 185);
            this.bodyText.TabIndex = 4;
            this.bodyText.Text = "";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 116);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Body";
            // 
            // sendButton
            // 
            this.sendButton.Location = new System.Drawing.Point(286, 407);
            this.sendButton.Name = "sendButton";
            this.sendButton.Size = new System.Drawing.Size(75, 23);
            this.sendButton.TabIndex = 6;
            this.sendButton.Text = "Send";
            this.sendButton.UseVisualStyleBackColor = true;
            this.sendButton.Click += new System.EventHandler(this.sendButton_Click);
            // 
            // captchaPic
            // 
            this.captchaPic.Location = new System.Drawing.Point(96, 330);
            this.captchaPic.Name = "captchaPic";
            this.captchaPic.Size = new System.Drawing.Size(265, 71);
            this.captchaPic.TabIndex = 7;
            this.captchaPic.TabStop = false;
            // 
            // newCaptcha
            // 
            this.newCaptcha.Location = new System.Drawing.Point(12, 348);
            this.newCaptcha.Name = "newCaptcha";
            this.newCaptcha.Size = new System.Drawing.Size(75, 35);
            this.newCaptcha.TabIndex = 8;
            this.newCaptcha.Text = "New Captcha";
            this.newCaptcha.UseVisualStyleBackColor = true;
            this.newCaptcha.Click += new System.EventHandler(this.newCaptcha_Click);
            // 
            // captchaLbl
            // 
            this.captchaLbl.AutoSize = true;
            this.captchaLbl.Location = new System.Drawing.Point(12, 307);
            this.captchaLbl.Name = "captchaLbl";
            this.captchaLbl.Size = new System.Drawing.Size(47, 13);
            this.captchaLbl.TabIndex = 10;
            this.captchaLbl.Text = "Captcha";
            // 
            // captchaBox
            // 
            this.captchaBox.Location = new System.Drawing.Point(96, 304);
            this.captchaBox.Name = "captchaBox";
            this.captchaBox.Size = new System.Drawing.Size(124, 20);
            this.captchaBox.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label4.Location = new System.Drawing.Point(12, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(351, 39);
            this.label4.TabIndex = 11;
            this.label4.Text = "Please be as accurate as possible when writing your title/body regardless\r\n of if" +
    " it\'s a suggestion or a bug report. If you got an exception, copy and\r\n paste it" +
    " into this form as well. ";
            // 
            // BugForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(373, 436);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.captchaLbl);
            this.Controls.Add(this.captchaBox);
            this.Controls.Add(this.newCaptcha);
            this.Controls.Add(this.captchaPic);
            this.Controls.Add(this.sendButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.bodyText);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.reportType);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.titleBox);
            this.MaximizeBox = false;
            this.Name = "BugForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bug Report/Suggestion";
            ((System.ComponentModel.ISupportInitialize)(this.captchaPic)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox titleBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox reportType;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox bodyText;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button sendButton;
        private System.Windows.Forms.PictureBox captchaPic;
        private System.Windows.Forms.Button newCaptcha;
        private System.Windows.Forms.Label captchaLbl;
        private System.Windows.Forms.TextBox captchaBox;
        private System.Windows.Forms.Label label4;
    }
}