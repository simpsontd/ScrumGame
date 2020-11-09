namespace ScrumGame
{
    partial class SetupForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SetupForm));
            this.ScrumGame = new System.Windows.Forms.Label();
            this.NumPlayersNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.CloseButton = new System.Windows.Forms.Button();
            this.fourPlayerFour = new System.Windows.Forms.PictureBox();
            this.fourPlayerThree = new System.Windows.Forms.PictureBox();
            this.fourPlayerTwo = new System.Windows.Forms.PictureBox();
            this.fourPlayerOne = new System.Windows.Forms.PictureBox();
            this.threePlayerThree = new System.Windows.Forms.PictureBox();
            this.threePlayerTwo = new System.Windows.Forms.PictureBox();
            this.threePlayerOne = new System.Windows.Forms.PictureBox();
            this.twoPlayerOne = new System.Windows.Forms.PictureBox();
            this.twoPlayerTwo = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.NumPlayersNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fourPlayerFour)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fourPlayerThree)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fourPlayerTwo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fourPlayerOne)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.threePlayerThree)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.threePlayerTwo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.threePlayerOne)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.twoPlayerOne)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.twoPlayerTwo)).BeginInit();
            this.SuspendLayout();
            // 
            // ScrumGame
            // 
            this.ScrumGame.AutoSize = true;
            this.ScrumGame.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ScrumGame.Location = new System.Drawing.Point(84, 21);
            this.ScrumGame.Name = "ScrumGame";
            this.ScrumGame.Size = new System.Drawing.Size(201, 37);
            this.ScrumGame.TabIndex = 0;
            this.ScrumGame.Text = "Player Count";
            // 
            // NumPlayersNumericUpDown
            // 
            this.NumPlayersNumericUpDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NumPlayersNumericUpDown.Location = new System.Drawing.Point(156, 133);
            this.NumPlayersNumericUpDown.Maximum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.NumPlayersNumericUpDown.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.NumPlayersNumericUpDown.Name = "NumPlayersNumericUpDown";
            this.NumPlayersNumericUpDown.Size = new System.Drawing.Size(65, 44);
            this.NumPlayersNumericUpDown.TabIndex = 1;
            this.NumPlayersNumericUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.NumPlayersNumericUpDown.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.NumPlayersNumericUpDown.ValueChanged += new System.EventHandler(this.NumPlayersNumericUpDown_ValueChanged);
            // 
            // CloseButton
            // 
            this.CloseButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.CloseButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CloseButton.Location = new System.Drawing.Point(127, 183);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(122, 39);
            this.CloseButton.TabIndex = 2;
            this.CloseButton.Text = "PLAY";
            this.CloseButton.UseVisualStyleBackColor = true;
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // fourPlayerFour
            // 
            this.fourPlayerFour.Location = new System.Drawing.Point(292, 61);
            this.fourPlayerFour.Name = "fourPlayerFour";
            this.fourPlayerFour.Size = new System.Drawing.Size(72, 66);
            this.fourPlayerFour.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.fourPlayerFour.TabIndex = 11;
            this.fourPlayerFour.TabStop = false;
            // 
            // fourPlayerThree
            // 
            this.fourPlayerThree.Location = new System.Drawing.Point(201, 61);
            this.fourPlayerThree.Name = "fourPlayerThree";
            this.fourPlayerThree.Size = new System.Drawing.Size(72, 66);
            this.fourPlayerThree.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.fourPlayerThree.TabIndex = 10;
            this.fourPlayerThree.TabStop = false;
            // 
            // fourPlayerTwo
            // 
            this.fourPlayerTwo.Image = ((System.Drawing.Image)(resources.GetObject("fourPlayerTwo.Image")));
            this.fourPlayerTwo.Location = new System.Drawing.Point(101, 61);
            this.fourPlayerTwo.Name = "fourPlayerTwo";
            this.fourPlayerTwo.Size = new System.Drawing.Size(72, 66);
            this.fourPlayerTwo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.fourPlayerTwo.TabIndex = 9;
            this.fourPlayerTwo.TabStop = false;
            // 
            // fourPlayerOne
            // 
            this.fourPlayerOne.Image = ((System.Drawing.Image)(resources.GetObject("fourPlayerOne.Image")));
            this.fourPlayerOne.Location = new System.Drawing.Point(12, 61);
            this.fourPlayerOne.Name = "fourPlayerOne";
            this.fourPlayerOne.Size = new System.Drawing.Size(72, 66);
            this.fourPlayerOne.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.fourPlayerOne.TabIndex = 8;
            this.fourPlayerOne.TabStop = false;
            // 
            // threePlayerThree
            // 
            this.threePlayerThree.Location = new System.Drawing.Point(267, 61);
            this.threePlayerThree.Name = "threePlayerThree";
            this.threePlayerThree.Size = new System.Drawing.Size(72, 66);
            this.threePlayerThree.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.threePlayerThree.TabIndex = 7;
            this.threePlayerThree.TabStop = false;
            // 
            // threePlayerTwo
            // 
            this.threePlayerTwo.Location = new System.Drawing.Point(149, 61);
            this.threePlayerTwo.Name = "threePlayerTwo";
            this.threePlayerTwo.Size = new System.Drawing.Size(72, 66);
            this.threePlayerTwo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.threePlayerTwo.TabIndex = 6;
            this.threePlayerTwo.TabStop = false;
            // 
            // threePlayerOne
            // 
            this.threePlayerOne.Location = new System.Drawing.Point(23, 61);
            this.threePlayerOne.Name = "threePlayerOne";
            this.threePlayerOne.Size = new System.Drawing.Size(72, 66);
            this.threePlayerOne.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.threePlayerOne.TabIndex = 5;
            this.threePlayerOne.TabStop = false;
            // 
            // twoPlayerOne
            // 
            this.twoPlayerOne.Image = ((System.Drawing.Image)(resources.GetObject("twoPlayerOne.Image")));
            this.twoPlayerOne.Location = new System.Drawing.Point(101, 61);
            this.twoPlayerOne.Name = "twoPlayerOne";
            this.twoPlayerOne.Size = new System.Drawing.Size(72, 66);
            this.twoPlayerOne.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.twoPlayerOne.TabIndex = 12;
            this.twoPlayerOne.TabStop = false;
            // 
            // twoPlayerTwo
            // 
            this.twoPlayerTwo.Image = ((System.Drawing.Image)(resources.GetObject("twoPlayerTwo.Image")));
            this.twoPlayerTwo.Location = new System.Drawing.Point(201, 61);
            this.twoPlayerTwo.Name = "twoPlayerTwo";
            this.twoPlayerTwo.Size = new System.Drawing.Size(72, 66);
            this.twoPlayerTwo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.twoPlayerTwo.TabIndex = 14;
            this.twoPlayerTwo.TabStop = false;
            // 
            // SetupForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.ForestGreen;
            this.ClientSize = new System.Drawing.Size(376, 234);
            this.Controls.Add(this.twoPlayerTwo);
            this.Controls.Add(this.twoPlayerOne);
            this.Controls.Add(this.fourPlayerFour);
            this.Controls.Add(this.fourPlayerThree);
            this.Controls.Add(this.fourPlayerTwo);
            this.Controls.Add(this.fourPlayerOne);
            this.Controls.Add(this.threePlayerThree);
            this.Controls.Add(this.threePlayerTwo);
            this.Controls.Add(this.threePlayerOne);
            this.Controls.Add(this.CloseButton);
            this.Controls.Add(this.NumPlayersNumericUpDown);
            this.Controls.Add(this.ScrumGame);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SetupForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "How Many Players?";
            this.Load += new System.EventHandler(this.SetupForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.NumPlayersNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fourPlayerFour)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fourPlayerThree)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fourPlayerTwo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fourPlayerOne)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.threePlayerThree)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.threePlayerTwo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.threePlayerOne)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.twoPlayerOne)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.twoPlayerTwo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label ScrumGame;
        public System.Windows.Forms.NumericUpDown NumPlayersNumericUpDown;
        private System.Windows.Forms.Button CloseButton;
        private System.Windows.Forms.PictureBox threePlayerOne;
        private System.Windows.Forms.PictureBox threePlayerTwo;
        private System.Windows.Forms.PictureBox threePlayerThree;
        private System.Windows.Forms.PictureBox fourPlayerOne;
        private System.Windows.Forms.PictureBox fourPlayerTwo;
        private System.Windows.Forms.PictureBox fourPlayerThree;
        private System.Windows.Forms.PictureBox fourPlayerFour;
        private System.Windows.Forms.PictureBox twoPlayerOne;
        private System.Windows.Forms.PictureBox twoPlayerTwo;
    }
}