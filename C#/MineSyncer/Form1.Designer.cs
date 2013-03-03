namespace MineSyncer
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.registerButton = new System.Windows.Forms.Button();
            this.userBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.passBox = new System.Windows.Forms.MaskedTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.mailBox = new System.Windows.Forms.TextBox();
            this.uLogBox = new System.Windows.Forms.TextBox();
            this.loginButton = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.pLogBox = new System.Windows.Forms.MaskedTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.manualUpdateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.worldManagerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bugSuggestionReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.donateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.newCaptcha = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.captchaBox = new System.Windows.Forms.TextBox();
            this.captchaPic = new System.Windows.Forms.PictureBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cPassBox = new System.Windows.Forms.MaskedTextBox();
            this.noAccount = new System.Windows.Forms.LinkLabel();
            this.label9 = new System.Windows.Forms.Label();
            this.reportBug = new System.Windows.Forms.LinkLabel();
            this.contextMenu.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.captchaPic)).BeginInit();
            this.SuspendLayout();
            // 
            // registerButton
            // 
            this.registerButton.Location = new System.Drawing.Point(56, 233);
            this.registerButton.Name = "registerButton";
            this.registerButton.Size = new System.Drawing.Size(112, 22);
            this.registerButton.TabIndex = 2;
            this.registerButton.Text = "Register";
            this.registerButton.UseVisualStyleBackColor = true;
            this.registerButton.Click += new System.EventHandler(this.registerButton_Click);
            // 
            // userBox
            // 
            this.userBox.Location = new System.Drawing.Point(108, 19);
            this.userBox.Name = "userBox";
            this.userBox.Size = new System.Drawing.Size(112, 20);
            this.userBox.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(47, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Username";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(49, 49);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Password";
            // 
            // passBox
            // 
            this.passBox.Location = new System.Drawing.Point(108, 45);
            this.passBox.Name = "passBox";
            this.passBox.PasswordChar = '*';
            this.passBox.Size = new System.Drawing.Size(112, 20);
            this.passBox.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(25, 101);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "E-Mail Address";
            // 
            // mailBox
            // 
            this.mailBox.Location = new System.Drawing.Point(108, 97);
            this.mailBox.Name = "mailBox";
            this.mailBox.Size = new System.Drawing.Size(112, 20);
            this.mailBox.TabIndex = 6;
            // 
            // uLogBox
            // 
            this.uLogBox.Location = new System.Drawing.Point(84, 85);
            this.uLogBox.Name = "uLogBox";
            this.uLogBox.Size = new System.Drawing.Size(141, 20);
            this.uLogBox.TabIndex = 0;
            // 
            // loginButton
            // 
            this.loginButton.Location = new System.Drawing.Point(85, 139);
            this.loginButton.Name = "loginButton";
            this.loginButton.Size = new System.Drawing.Size(79, 23);
            this.loginButton.TabIndex = 2;
            this.loginButton.Text = "Login";
            this.loginButton.UseVisualStyleBackColor = true;
            this.loginButton.Click += new System.EventHandler(this.loginButton_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(23, 89);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Username";
            // 
            // pLogBox
            // 
            this.pLogBox.Location = new System.Drawing.Point(84, 112);
            this.pLogBox.Name = "pLogBox";
            this.pLogBox.PasswordChar = '*';
            this.pLogBox.Size = new System.Drawing.Size(141, 20);
            this.pLogBox.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(25, 116);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "Password";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(48, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(144, 20);
            this.label1.TabIndex = 12;
            this.label1.Text = "By Christian Nieves";
            // 
            // notifyIcon
            // 
            this.notifyIcon.ContextMenuStrip = this.contextMenu;
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "MineSync";
            // 
            // contextMenu
            // 
            this.contextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.manualUpdateToolStripMenuItem,
            this.worldManagerToolStripMenuItem,
            this.bugSuggestionReportToolStripMenuItem,
            this.settingsToolStripMenuItem,
            this.donateToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.contextMenu.Name = "contextMenu";
            this.contextMenu.Size = new System.Drawing.Size(198, 136);
            // 
            // manualUpdateToolStripMenuItem
            // 
            this.manualUpdateToolStripMenuItem.Name = "manualUpdateToolStripMenuItem";
            this.manualUpdateToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
            this.manualUpdateToolStripMenuItem.Text = "Manual Update";
            this.manualUpdateToolStripMenuItem.Click += new System.EventHandler(this.manualUpdateToolStripMenuItem_Click);
            // 
            // worldManagerToolStripMenuItem
            // 
            this.worldManagerToolStripMenuItem.Name = "worldManagerToolStripMenuItem";
            this.worldManagerToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
            this.worldManagerToolStripMenuItem.Text = "World Manager";
            this.worldManagerToolStripMenuItem.Click += new System.EventHandler(this.worldManagerToolStripMenuItem_Click);
            // 
            // bugSuggestionReportToolStripMenuItem
            // 
            this.bugSuggestionReportToolStripMenuItem.Name = "bugSuggestionReportToolStripMenuItem";
            this.bugSuggestionReportToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
            this.bugSuggestionReportToolStripMenuItem.Text = "Bug/Suggestion Report";
            this.bugSuggestionReportToolStripMenuItem.Click += new System.EventHandler(this.bugSuggestionReportToolStripMenuItem_Click);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
            this.settingsToolStripMenuItem.Text = "Settings";
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
            // 
            // donateToolStripMenuItem
            // 
            this.donateToolStripMenuItem.ForeColor = System.Drawing.Color.Blue;
            this.donateToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("donateToolStripMenuItem.Image")));
            this.donateToolStripMenuItem.Name = "donateToolStripMenuItem";
            this.donateToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
            this.donateToolStripMenuItem.Text = "Donate";
            this.donateToolStripMenuItem.Click += new System.EventHandler(this.donateToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.newCaptcha);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.captchaBox);
            this.groupBox1.Controls.Add(this.captchaPic);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.cPassBox);
            this.groupBox1.Controls.Add(this.userBox);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.passBox);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.registerButton);
            this.groupBox1.Controls.Add(this.mailBox);
            this.groupBox1.Location = new System.Drawing.Point(9, 196);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(230, 261);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Register";
            // 
            // newCaptcha
            // 
            this.newCaptcha.Location = new System.Drawing.Point(108, 148);
            this.newCaptcha.Name = "newCaptcha";
            this.newCaptcha.Size = new System.Drawing.Size(112, 23);
            this.newCaptcha.TabIndex = 21;
            this.newCaptcha.Text = "New Captcha";
            this.newCaptcha.UseVisualStyleBackColor = true;
            this.newCaptcha.Click += new System.EventHandler(this.newCaptcha_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(55, 126);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(47, 13);
            this.label7.TabIndex = 20;
            this.label7.Text = "Captcha";
            // 
            // captchaBox
            // 
            this.captchaBox.Location = new System.Drawing.Point(108, 123);
            this.captchaBox.Name = "captchaBox";
            this.captchaBox.Size = new System.Drawing.Size(112, 20);
            this.captchaBox.TabIndex = 19;
            // 
            // captchaPic
            // 
            this.captchaPic.Location = new System.Drawing.Point(0, 177);
            this.captchaPic.Name = "captchaPic";
            this.captchaPic.Size = new System.Drawing.Size(230, 50);
            this.captchaPic.TabIndex = 18;
            this.captchaPic.TabStop = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(11, 75);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(91, 13);
            this.label8.TabIndex = 10;
            this.label8.Text = "Confirm Password";
            // 
            // cPassBox
            // 
            this.cPassBox.Location = new System.Drawing.Point(108, 71);
            this.cPassBox.Name = "cPassBox";
            this.cPassBox.PasswordChar = '*';
            this.cPassBox.Size = new System.Drawing.Size(112, 20);
            this.cPassBox.TabIndex = 5;
            // 
            // noAccount
            // 
            this.noAccount.AutoSize = true;
            this.noAccount.Location = new System.Drawing.Point(62, 165);
            this.noAccount.Name = "noAccount";
            this.noAccount.Size = new System.Drawing.Size(122, 13);
            this.noAccount.TabIndex = 15;
            this.noAccount.TabStop = true;
            this.noAccount.Text = "Don\'t have an account?";
            this.noAccount.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.noAccount_LinkClicked);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 32.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(20, -4);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(208, 59);
            this.label9.TabIndex = 16;
            this.label9.Text = "MineSync";
            // 
            // reportBug
            // 
            this.reportBug.AutoSize = true;
            this.reportBug.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.reportBug.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.reportBug.Location = new System.Drawing.Point(41, 180);
            this.reportBug.Name = "reportBug";
            this.reportBug.Size = new System.Drawing.Size(167, 13);
            this.reportBug.TabIndex = 17;
            this.reportBug.TabStop = true;
            this.reportBug.Text = "Report a Bug/Leave a Suggestion";
            this.reportBug.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.reportBug_LinkClicked);
            // 
            // Form1
            // 
            this.AcceptButton = this.loginButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(248, 196);
            this.Controls.Add(this.reportBug);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.noAccount);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.loginButton);
            this.Controls.Add(this.uLogBox);
            this.Controls.Add(this.pLogBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.contextMenu.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.captchaPic)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button registerButton;
        private System.Windows.Forms.TextBox userBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.MaskedTextBox passBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox mailBox;
        private System.Windows.Forms.TextBox uLogBox;
        private System.Windows.Forms.Button loginButton;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.MaskedTextBox pLogBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.LinkLabel noAccount;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.MaskedTextBox cPassBox;
        private System.Windows.Forms.ContextMenuStrip contextMenu;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manualUpdateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem worldManagerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem donateToolStripMenuItem;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox captchaBox;
        private System.Windows.Forms.PictureBox captchaPic;
        private System.Windows.Forms.Button newCaptcha;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.LinkLabel reportBug;
        private System.Windows.Forms.ToolStripMenuItem bugSuggestionReportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
    }
}

