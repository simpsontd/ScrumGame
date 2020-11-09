namespace ScrumGame
{
    partial class AudioController
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.musicVolumeImage = new System.Windows.Forms.PictureBox();
            this.musicVolumeBar = new System.Windows.Forms.TrackBar();
            this.VolumeConfirmButton = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.musicVolumeImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.musicVolumeBar)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.musicVolumeImage);
            this.panel1.Controls.Add(this.musicVolumeBar);
            this.panel1.Location = new System.Drawing.Point(20, 13);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(288, 310);
            this.panel1.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(87, 70);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "Game Volume";
            // 
            // musicVolumeImage
            // 
            this.musicVolumeImage.BackColor = System.Drawing.Color.Transparent;
            this.musicVolumeImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.musicVolumeImage.Cursor = System.Windows.Forms.Cursors.Default;
            this.musicVolumeImage.Image = global::ScrumGame.Properties.Resources.full;
            this.musicVolumeImage.Location = new System.Drawing.Point(108, 4);
            this.musicVolumeImage.Margin = new System.Windows.Forms.Padding(4);
            this.musicVolumeImage.Name = "musicVolumeImage";
            this.musicVolumeImage.Size = new System.Drawing.Size(74, 60);
            this.musicVolumeImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.musicVolumeImage.TabIndex = 3;
            this.musicVolumeImage.TabStop = false;
            this.musicVolumeImage.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // musicVolumeBar
            // 
            this.musicVolumeBar.Location = new System.Drawing.Point(118, 92);
            this.musicVolumeBar.Margin = new System.Windows.Forms.Padding(4);
            this.musicVolumeBar.Name = "musicVolumeBar";
            this.musicVolumeBar.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.musicVolumeBar.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.musicVolumeBar.Size = new System.Drawing.Size(45, 215);
            this.musicVolumeBar.TabIndex = 1;
            this.musicVolumeBar.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.musicVolumeBar.Value = 10;
            this.musicVolumeBar.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // VolumeConfirmButton
            // 
            this.VolumeConfirmButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.VolumeConfirmButton.Location = new System.Drawing.Point(20, 331);
            this.VolumeConfirmButton.Margin = new System.Windows.Forms.Padding(4);
            this.VolumeConfirmButton.Name = "VolumeConfirmButton";
            this.VolumeConfirmButton.Size = new System.Drawing.Size(288, 36);
            this.VolumeConfirmButton.TabIndex = 2;
            this.VolumeConfirmButton.Text = "CONFIRM VOLUME";
            this.VolumeConfirmButton.UseVisualStyleBackColor = true;
            this.VolumeConfirmButton.Click += new System.EventHandler(this.VolumeConfirmButton_Click);
            // 
            // AudioController
            // 
            this.AcceptButton = this.VolumeConfirmButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(324, 370);
            this.Controls.Add(this.VolumeConfirmButton);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "AudioController";
            this.Opacity = 0.9D;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Volume Mixer";
            this.Load += new System.EventHandler(this.AudioController_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.musicVolumeImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.musicVolumeBar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox musicVolumeImage;
        private System.Windows.Forms.TrackBar musicVolumeBar;
        private System.Windows.Forms.Button VolumeConfirmButton;
    }
}