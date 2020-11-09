using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScrumGame
{
    public partial class VotingForm : Form
    {
        /// <summary>
        /// used to iterate over indexes
        /// </summary>
        private Queue<int> Indexes { get; set; }

        public VotingForm()
        {
            InitializeComponent();
            PromptLabel.Text = ((MainForm)Program.Properties).ActivePlayer.Name + " vote on a task!";
            string[] defaultText = new String[] { "Front End", "Back End", "Full Stack" };
            Random rand = new Random();
            int max = ((MainForm)Program.Properties).frm2.listBox1.Items.Count;
            if (max > 0)
            {
                for (int i = 0; i < ((MainForm)Program.Properties).NumPlayers; i++)
                {
                    TaskListBox.Items.Add(((MainForm)Program.Properties).frm2.listBox1.Items[rand.Next(1, max)]);
                }
            }
            else
            {
                for (int i = 0; i < ((MainForm)Program.Properties).NumPlayers; i++)
                {
                    TaskListBox.Items.Add(defaultText[rand.Next(0, 3)]);
                }
            }
            Indexes = new Queue<int>(); //set up a queue of indexes 
            for (int i = ((MainForm)Program.Properties).ActivePlayer.PlayerNumber; i < ((MainForm)Program.Properties).NumPlayers; i++)
            {
                Indexes.Enqueue(i);
            }
            int count = Indexes.Count;
            for (int i = 0; i < ((MainForm)Program.Properties).NumPlayers - count; i++)
            {
                Indexes.Enqueue(i);
            }
            for (int i = 0; i < 4; i++)
            {
                ((MainForm)Program.Properties).ResourceTypes[i] = rand.Next(1, 4);
            }
            
        }

        private void VotingForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            ((MainForm)Program.Properties).UpdateLabels();
            ((MainForm)Program.Properties).BeginPhase(1);
        }

        private void VoteButton_Click(object sender, EventArgs e)
        {
            bool goodInput = true;
            if (!TaskRadioButton.Checked && !StoryRadioButton.Checked && !FeatureRadioButton.Checked && !EpicRadioButton.Checked )
            { //none are selected
                ResourceErrorLabel.Visible = true;
                goodInput = false;
            }
            else
            {
                ResourceErrorLabel.Visible = false;
            }
            if (TaskListBox.SelectedIndex == -1)
            {
                TaskErrorLabel.Visible = true;
                goodInput = false;
            }
            else
            {
                TaskErrorLabel.Visible = false;
            }
            if (goodInput)
            {
                //assign types and remove selections
                if (TaskListBox.SelectedItem.ToString().Contains( "Front End"))
                {
                    if (TaskRadioButton.Checked) { ((MainForm)Program.Properties).ResourceTypes[0] = 1; }
                    if (StoryRadioButton.Checked) { ((MainForm)Program.Properties).ResourceTypes[1] = 1; }
                    if (FeatureRadioButton.Checked) { ((MainForm)Program.Properties).ResourceTypes[2] = 1; }
                    if (EpicRadioButton.Checked) { ((MainForm)Program.Properties).ResourceTypes[3] = 1; }

                }
                else if (TaskListBox.SelectedItem.ToString().Contains("Back End"))
                {
                    if (TaskRadioButton.Checked) { ((MainForm)Program.Properties).ResourceTypes[0] = 2; }
                    if (StoryRadioButton.Checked) { ((MainForm)Program.Properties).ResourceTypes[1] = 2; }
                    if (FeatureRadioButton.Checked) { ((MainForm)Program.Properties).ResourceTypes[2] = 2; }
                    if (EpicRadioButton.Checked) { ((MainForm)Program.Properties).ResourceTypes[3] = 2; }
                }
                else if (TaskListBox.SelectedItem.ToString().Contains("Full Stack"))
                {
                    if (TaskRadioButton.Checked) { ((MainForm)Program.Properties).ResourceTypes[0] = 3; }
                    if (StoryRadioButton.Checked) { ((MainForm)Program.Properties).ResourceTypes[1] = 3; }
                    if (FeatureRadioButton.Checked) { ((MainForm)Program.Properties).ResourceTypes[2] = 3; }
                    if (EpicRadioButton.Checked) { ((MainForm)Program.Properties).ResourceTypes[3] = 3; }
                }

                TaskListBox.Items.RemoveAt(TaskListBox.SelectedIndex);
                if (TaskRadioButton.Checked)
                {
                    TaskRadioButton.Checked = false;
                    TaskRadioButton.Visible = false;
                }
                if (StoryRadioButton.Checked)
                {
                    StoryRadioButton.Checked = false;
                    StoryRadioButton.Visible = false;
                }
                if (FeatureRadioButton.Checked)
                {
                    FeatureRadioButton.Checked = false;
                    FeatureRadioButton.Visible = false;
                }
                if (EpicRadioButton.Checked)
                {
                    EpicRadioButton.Checked = false;
                    EpicRadioButton.Visible = false;
                }
                String playerName = ((MainForm)Program.Properties).Players[Indexes.Dequeue()].Name;
                PromptLabel.Text =  playerName + " vote on a task!";
                if (Indexes.Count < 1) //this was the last player to vote
                {
                    this.Close();
                }
            }
            
        }

    }
}
