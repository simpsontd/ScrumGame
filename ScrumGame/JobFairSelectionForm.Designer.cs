namespace ScrumGame
{
    partial class JobFairSelectionForm
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
            this.FullStackDeveloperSupplyPictureBox = new System.Windows.Forms.PictureBox();
            this.BackEndDeveloperSupplyPictureBox = new System.Windows.Forms.PictureBox();
            this.FrontEndDeveloperSupplyPictureBox = new System.Windows.Forms.PictureBox();
            this.PrompLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.FullStackDeveloperSupplyPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BackEndDeveloperSupplyPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FrontEndDeveloperSupplyPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // FullStackDeveloperSupplyPictureBox
            // 
            this.FullStackDeveloperSupplyPictureBox.BackColor = System.Drawing.Color.Transparent;
            this.FullStackDeveloperSupplyPictureBox.BackgroundImage = global::ScrumGame.Properties.Resources.FullStackDeveloperNeutral;
            this.FullStackDeveloperSupplyPictureBox.Location = new System.Drawing.Point(143, 72);
            this.FullStackDeveloperSupplyPictureBox.Name = "FullStackDeveloperSupplyPictureBox";
            this.FullStackDeveloperSupplyPictureBox.Size = new System.Drawing.Size(40, 40);
            this.FullStackDeveloperSupplyPictureBox.TabIndex = 50;
            this.FullStackDeveloperSupplyPictureBox.TabStop = false;
            this.FullStackDeveloperSupplyPictureBox.Click += new System.EventHandler(this.FullStackDeveloperSupplyPictureBox_Click);
            // 
            // BackEndDeveloperSupplyPictureBox
            // 
            this.BackEndDeveloperSupplyPictureBox.BackColor = System.Drawing.Color.Transparent;
            this.BackEndDeveloperSupplyPictureBox.BackgroundImage = global::ScrumGame.Properties.Resources.BackEndDeveloperNeutral;
            this.BackEndDeveloperSupplyPictureBox.Location = new System.Drawing.Point(97, 72);
            this.BackEndDeveloperSupplyPictureBox.Name = "BackEndDeveloperSupplyPictureBox";
            this.BackEndDeveloperSupplyPictureBox.Size = new System.Drawing.Size(40, 40);
            this.BackEndDeveloperSupplyPictureBox.TabIndex = 49;
            this.BackEndDeveloperSupplyPictureBox.TabStop = false;
            this.BackEndDeveloperSupplyPictureBox.Click += new System.EventHandler(this.BackEndDeveloperSupplyPictureBox_Click);
            // 
            // FrontEndDeveloperSupplyPictureBox
            // 
            this.FrontEndDeveloperSupplyPictureBox.BackColor = System.Drawing.Color.Transparent;
            this.FrontEndDeveloperSupplyPictureBox.BackgroundImage = global::ScrumGame.Properties.Resources.FrontEndDeveloperNeutral;
            this.FrontEndDeveloperSupplyPictureBox.Location = new System.Drawing.Point(51, 72);
            this.FrontEndDeveloperSupplyPictureBox.Name = "FrontEndDeveloperSupplyPictureBox";
            this.FrontEndDeveloperSupplyPictureBox.Size = new System.Drawing.Size(40, 40);
            this.FrontEndDeveloperSupplyPictureBox.TabIndex = 48;
            this.FrontEndDeveloperSupplyPictureBox.TabStop = false;
            this.FrontEndDeveloperSupplyPictureBox.Click += new System.EventHandler(this.FrontEndDeveloperSupplyPictureBox_Click);
            // 
            // PrompLabel
            // 
            this.PrompLabel.AutoSize = true;
            this.PrompLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PrompLabel.Location = new System.Drawing.Point(45, 27);
            this.PrompLabel.Name = "PrompLabel";
            this.PrompLabel.Size = new System.Drawing.Size(143, 24);
            this.PrompLabel.TabIndex = 51;
            this.PrompLabel.Text = "Select a Worker";
            // 
            // JobFairSelectionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(227, 149);
            this.Controls.Add(this.PrompLabel);
            this.Controls.Add(this.FullStackDeveloperSupplyPictureBox);
            this.Controls.Add(this.BackEndDeveloperSupplyPictureBox);
            this.Controls.Add(this.FrontEndDeveloperSupplyPictureBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "JobFairSelectionForm";
            this.Text = "JobFairSelectionForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.JobFairSelectionForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.FullStackDeveloperSupplyPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BackEndDeveloperSupplyPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FrontEndDeveloperSupplyPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox FullStackDeveloperSupplyPictureBox;
        private System.Windows.Forms.PictureBox BackEndDeveloperSupplyPictureBox;
        private System.Windows.Forms.PictureBox FrontEndDeveloperSupplyPictureBox;
        private System.Windows.Forms.Label PrompLabel;
    }
}