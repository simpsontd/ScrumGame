namespace ScrumGame
{
    partial class VotingForm
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
            this.TaskListBox = new System.Windows.Forms.ListBox();
            this.PromptLabel = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.EpicRadioButton = new System.Windows.Forms.RadioButton();
            this.FeatureRadioButton = new System.Windows.Forms.RadioButton();
            this.StoryRadioButton = new System.Windows.Forms.RadioButton();
            this.TaskRadioButton = new System.Windows.Forms.RadioButton();
            this.VoteButton = new System.Windows.Forms.Button();
            this.ResourceErrorLabel = new System.Windows.Forms.Label();
            this.TaskErrorLabel = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // TaskListBox
            // 
            this.TaskListBox.BackColor = System.Drawing.SystemColors.Info;
            this.TaskListBox.FormattingEnabled = true;
            this.TaskListBox.Location = new System.Drawing.Point(30, 72);
            this.TaskListBox.Name = "TaskListBox";
            this.TaskListBox.Size = new System.Drawing.Size(449, 108);
            this.TaskListBox.TabIndex = 0;
            // 
            // PromptLabel
            // 
            this.PromptLabel.AutoSize = true;
            this.PromptLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PromptLabel.Location = new System.Drawing.Point(327, 28);
            this.PromptLabel.Name = "PromptLabel";
            this.PromptLabel.Size = new System.Drawing.Size(178, 20);
            this.PromptLabel.TabIndex = 1;
            this.PromptLabel.Text = "Player X Vote on a task!";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.LightYellow;
            this.groupBox1.Controls.Add(this.EpicRadioButton);
            this.groupBox1.Controls.Add(this.FeatureRadioButton);
            this.groupBox1.Controls.Add(this.StoryRadioButton);
            this.groupBox1.Controls.Add(this.TaskRadioButton);
            this.groupBox1.Location = new System.Drawing.Point(552, 72);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(102, 108);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            // 
            // EpicRadioButton
            // 
            this.EpicRadioButton.AutoSize = true;
            this.EpicRadioButton.Location = new System.Drawing.Point(13, 83);
            this.EpicRadioButton.Name = "EpicRadioButton";
            this.EpicRadioButton.Size = new System.Drawing.Size(66, 17);
            this.EpicRadioButton.TabIndex = 3;
            this.EpicRadioButton.TabStop = true;
            this.EpicRadioButton.Text = "Epicland";
            this.EpicRadioButton.UseVisualStyleBackColor = true;
            // 
            // FeatureRadioButton
            // 
            this.FeatureRadioButton.AutoSize = true;
            this.FeatureRadioButton.Location = new System.Drawing.Point(13, 60);
            this.FeatureRadioButton.Name = "FeatureRadioButton";
            this.FeatureRadioButton.Size = new System.Drawing.Size(81, 17);
            this.FeatureRadioButton.TabIndex = 2;
            this.FeatureRadioButton.TabStop = true;
            this.FeatureRadioButton.Text = "Featureland";
            this.FeatureRadioButton.UseVisualStyleBackColor = true;
            // 
            // StoryRadioButton
            // 
            this.StoryRadioButton.AutoSize = true;
            this.StoryRadioButton.Location = new System.Drawing.Point(13, 37);
            this.StoryRadioButton.Name = "StoryRadioButton";
            this.StoryRadioButton.Size = new System.Drawing.Size(69, 17);
            this.StoryRadioButton.TabIndex = 1;
            this.StoryRadioButton.TabStop = true;
            this.StoryRadioButton.Text = "Storyland";
            this.StoryRadioButton.UseVisualStyleBackColor = true;
            // 
            // TaskRadioButton
            // 
            this.TaskRadioButton.AutoSize = true;
            this.TaskRadioButton.Location = new System.Drawing.Point(13, 14);
            this.TaskRadioButton.Name = "TaskRadioButton";
            this.TaskRadioButton.Size = new System.Drawing.Size(69, 17);
            this.TaskRadioButton.TabIndex = 0;
            this.TaskRadioButton.TabStop = true;
            this.TaskRadioButton.Text = "Taskland";
            this.TaskRadioButton.UseVisualStyleBackColor = true;
            // 
            // VoteButton
            // 
            this.VoteButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.VoteButton.Location = new System.Drawing.Point(690, 113);
            this.VoteButton.Name = "VoteButton";
            this.VoteButton.Size = new System.Drawing.Size(83, 36);
            this.VoteButton.TabIndex = 3;
            this.VoteButton.Text = "Vote";
            this.VoteButton.UseVisualStyleBackColor = true;
            this.VoteButton.Click += new System.EventHandler(this.VoteButton_Click);
            // 
            // ResourceErrorLabel
            // 
            this.ResourceErrorLabel.AutoSize = true;
            this.ResourceErrorLabel.ForeColor = System.Drawing.Color.Red;
            this.ResourceErrorLabel.Location = new System.Drawing.Point(556, 191);
            this.ResourceErrorLabel.Name = "ResourceErrorLabel";
            this.ResourceErrorLabel.Size = new System.Drawing.Size(93, 13);
            this.ResourceErrorLabel.TabIndex = 4;
            this.ResourceErrorLabel.Text = "Select a resource.";
            this.ResourceErrorLabel.Visible = false;
            // 
            // TaskErrorLabel
            // 
            this.TaskErrorLabel.AutoSize = true;
            this.TaskErrorLabel.ForeColor = System.Drawing.Color.Red;
            this.TaskErrorLabel.Location = new System.Drawing.Point(206, 191);
            this.TaskErrorLabel.Name = "TaskErrorLabel";
            this.TaskErrorLabel.Size = new System.Drawing.Size(72, 13);
            this.TaskErrorLabel.TabIndex = 5;
            this.TaskErrorLabel.Text = "Select a task.";
            this.TaskErrorLabel.Visible = false;
            // 
            // VotingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 240);
            this.Controls.Add(this.ResourceErrorLabel);
            this.Controls.Add(this.TaskErrorLabel);
            this.Controls.Add(this.VoteButton);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.PromptLabel);
            this.Controls.Add(this.TaskListBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "VotingForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "VotingForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.VotingForm_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox TaskListBox;
        private System.Windows.Forms.Label PromptLabel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton EpicRadioButton;
        private System.Windows.Forms.RadioButton FeatureRadioButton;
        private System.Windows.Forms.RadioButton StoryRadioButton;
        private System.Windows.Forms.RadioButton TaskRadioButton;
        private System.Windows.Forms.Button VoteButton;
        private System.Windows.Forms.Label ResourceErrorLabel;
        private System.Windows.Forms.Label TaskErrorLabel;
    }
}