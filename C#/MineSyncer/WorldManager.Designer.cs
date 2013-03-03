namespace MineSyncer
{
    partial class WorldManager
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
            this.worldsUD = new System.Windows.Forms.DomainUpDown();
            this.downloadCheck = new System.Windows.Forms.CheckBox();
            this.dateLabel = new System.Windows.Forms.Label();
            this.deleteButton = new System.Windows.Forms.Button();
            this.dlButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // worldsUD
            // 
            this.worldsUD.Location = new System.Drawing.Point(12, 12);
            this.worldsUD.Name = "worldsUD";
            this.worldsUD.Size = new System.Drawing.Size(156, 20);
            this.worldsUD.TabIndex = 0;
            this.worldsUD.Text = "Worlds";
            this.worldsUD.SelectedItemChanged += new System.EventHandler(this.worldsUD_SelectedItemChanged);
            // 
            // downloadCheck
            // 
            this.downloadCheck.AutoSize = true;
            this.downloadCheck.Location = new System.Drawing.Point(14, 41);
            this.downloadCheck.Name = "downloadCheck";
            this.downloadCheck.Size = new System.Drawing.Size(94, 17);
            this.downloadCheck.TabIndex = 1;
            this.downloadCheck.Text = "Downloadable";
            this.downloadCheck.UseVisualStyleBackColor = true;
            this.downloadCheck.CheckedChanged += new System.EventHandler(this.downloadCheck_CheckedChanged);
            // 
            // dateLabel
            // 
            this.dateLabel.AutoSize = true;
            this.dateLabel.Location = new System.Drawing.Point(174, 14);
            this.dateLabel.Name = "dateLabel";
            this.dateLabel.Size = new System.Drawing.Size(82, 13);
            this.dateLabel.TabIndex = 2;
            this.dateLabel.Text = "Date Modified : ";
            // 
            // deleteButton
            // 
            this.deleteButton.Location = new System.Drawing.Point(37, 67);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(226, 23);
            this.deleteButton.TabIndex = 5;
            this.deleteButton.Text = "Delete this World from the MineSync Server";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // dlButton
            // 
            this.dlButton.Location = new System.Drawing.Point(114, 38);
            this.dlButton.Name = "dlButton";
            this.dlButton.Size = new System.Drawing.Size(172, 23);
            this.dlButton.TabIndex = 6;
            this.dlButton.Text = "Copy Download Link to Clipboard";
            this.dlButton.UseVisualStyleBackColor = true;
            this.dlButton.Click += new System.EventHandler(this.dlButton_Click);
            // 
            // WorldManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(300, 96);
            this.Controls.Add(this.dlButton);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.dateLabel);
            this.Controls.Add(this.downloadCheck);
            this.Controls.Add(this.worldsUD);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "WorldManager";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "World Manager";
            this.Load += new System.EventHandler(this.WorldManager_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DomainUpDown worldsUD;
        private System.Windows.Forms.CheckBox downloadCheck;
        private System.Windows.Forms.Label dateLabel;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.Button dlButton;

    }
}