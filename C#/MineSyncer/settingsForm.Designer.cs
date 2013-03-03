namespace MineSyncer
{
    partial class settingsForm
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
            this.saveOverride = new System.Windows.Forms.CheckBox();
            this.savepathText = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cancelButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.intervalCheck = new System.Windows.Forms.CheckBox();
            this.chkStartUp = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // saveOverride
            // 
            this.saveOverride.AutoSize = true;
            this.saveOverride.Location = new System.Drawing.Point(363, 8);
            this.saveOverride.Name = "saveOverride";
            this.saveOverride.Size = new System.Drawing.Size(66, 17);
            this.saveOverride.TabIndex = 0;
            this.saveOverride.Text = "Override";
            this.saveOverride.UseVisualStyleBackColor = true;
            this.saveOverride.CheckedChanged += new System.EventHandler(this.saveOverride_CheckedChanged);
            // 
            // savepathText
            // 
            this.savepathText.Location = new System.Drawing.Point(72, 6);
            this.savepathText.Name = "savepathText";
            this.savepathText.Size = new System.Drawing.Size(285, 20);
            this.savepathText.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Save Path";
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(271, 72);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 3;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(352, 72);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 4;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // intervalCheck
            // 
            this.intervalCheck.AutoSize = true;
            this.intervalCheck.Location = new System.Drawing.Point(12, 32);
            this.intervalCheck.Name = "intervalCheck";
            this.intervalCheck.Size = new System.Drawing.Size(201, 17);
            this.intervalCheck.TabIndex = 6;
            this.intervalCheck.Text = "Show the interval check notification. ";
            this.intervalCheck.UseVisualStyleBackColor = true;
            // 
            // chkStartUp
            // 
            this.chkStartUp.AutoSize = true;
            this.chkStartUp.Location = new System.Drawing.Point(12, 56);
            this.chkStartUp.Name = "chkStartUp";
            this.chkStartUp.Size = new System.Drawing.Size(212, 17);
            this.chkStartUp.TabIndex = 7;
            this.chkStartUp.Text = "Open MineSync when Windows starts. ";
            this.chkStartUp.UseVisualStyleBackColor = true;
            // 
            // settingsForm
            // 
            this.AcceptButton = this.saveButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(439, 107);
            this.Controls.Add(this.chkStartUp);
            this.Controls.Add(this.intervalCheck);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.savepathText);
            this.Controls.Add(this.saveOverride);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "settingsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.settingsForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox saveOverride;
        private System.Windows.Forms.TextBox savepathText;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.CheckBox intervalCheck;
        private System.Windows.Forms.CheckBox chkStartUp;
    }
}