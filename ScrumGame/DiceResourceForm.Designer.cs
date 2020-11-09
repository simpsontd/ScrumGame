namespace ScrumGame
{
    partial class DiceResourceForm
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
            this.Resource1Button = new System.Windows.Forms.Button();
            this.Resource2Button = new System.Windows.Forms.Button();
            this.Resource3Button = new System.Windows.Forms.Button();
            this.Resource4Button = new System.Windows.Forms.Button();
            this.PromptLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Resource1Button
            // 
            this.Resource1Button.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Resource1Button.Location = new System.Drawing.Point(12, 12);
            this.Resource1Button.Name = "Resource1Button";
            this.Resource1Button.Size = new System.Drawing.Size(100, 100);
            this.Resource1Button.TabIndex = 0;
            this.Resource1Button.Text = "button1";
            this.Resource1Button.UseVisualStyleBackColor = true;
            this.Resource1Button.Click += new System.EventHandler(this.ResourceButton_Click);
            // 
            // Resource2Button
            // 
            this.Resource2Button.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Resource2Button.Location = new System.Drawing.Point(204, 12);
            this.Resource2Button.Name = "Resource2Button";
            this.Resource2Button.Size = new System.Drawing.Size(100, 100);
            this.Resource2Button.TabIndex = 1;
            this.Resource2Button.Text = "button2";
            this.Resource2Button.UseVisualStyleBackColor = true;
            this.Resource2Button.Click += new System.EventHandler(this.ResourceButton_Click);
            // 
            // Resource3Button
            // 
            this.Resource3Button.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Resource3Button.Location = new System.Drawing.Point(12, 206);
            this.Resource3Button.Name = "Resource3Button";
            this.Resource3Button.Size = new System.Drawing.Size(100, 100);
            this.Resource3Button.TabIndex = 2;
            this.Resource3Button.Text = "button3";
            this.Resource3Button.UseVisualStyleBackColor = true;
            this.Resource3Button.Click += new System.EventHandler(this.ResourceButton_Click);
            // 
            // Resource4Button
            // 
            this.Resource4Button.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Resource4Button.Location = new System.Drawing.Point(204, 206);
            this.Resource4Button.Name = "Resource4Button";
            this.Resource4Button.Size = new System.Drawing.Size(100, 100);
            this.Resource4Button.TabIndex = 3;
            this.Resource4Button.Text = "button4";
            this.Resource4Button.UseVisualStyleBackColor = true;
            this.Resource4Button.Click += new System.EventHandler(this.ResourceButton_Click);
            // 
            // PromptLabel
            // 
            this.PromptLabel.AutoSize = true;
            this.PromptLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PromptLabel.Location = new System.Drawing.Point(40, 143);
            this.PromptLabel.Name = "PromptLabel";
            this.PromptLabel.Size = new System.Drawing.Size(236, 24);
            this.PromptLabel.TabIndex = 4;
            this.PromptLabel.Text = "Player X choose your item!";
            // 
            // DiceResourceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(320, 319);
            this.Controls.Add(this.PromptLabel);
            this.Controls.Add(this.Resource4Button);
            this.Controls.Add(this.Resource3Button);
            this.Controls.Add(this.Resource2Button);
            this.Controls.Add(this.Resource1Button);
            this.Name = "DiceResourceForm";
            this.Text = "DiceResourceForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Resource1Button;
        private System.Windows.Forms.Button Resource2Button;
        private System.Windows.Forms.Button Resource3Button;
        private System.Windows.Forms.Button Resource4Button;
        private System.Windows.Forms.Label PromptLabel;
    }
}