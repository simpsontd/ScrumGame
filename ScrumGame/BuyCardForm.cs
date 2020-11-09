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
    public partial class BuyCardForm : Form
    {
        private int[] Requirements { get; set; }
        private Player Buyer { get; set; }
        public bool Bought { get; set; }
        public int[] PayedResources { get; set; }
        
        public BuyCardForm(Player player, int tasks, int stories, int features, int epics, int anyMin, int anyMax, int minTypes, int maxTypes = -1)
        {
            InitializeComponent();
            if (tasks > 0) { RequiredTasksLabel.Text = tasks.ToString(); }
            if (stories > 0) { RequiredStoriesLabel.Text = stories.ToString(); }
            if (features > 0) { RequiredFeaturesLabel.Text = features.ToString(); }
            if (epics > 0) { RequiredEpicsLabel.Text = epics.ToString(); }
            if (anyMin > 0) { RequiredAnyLabel.Text = anyMin.ToString(); }
            if (anyMax > anyMin && anyMax > 0) { RequiredAnyLabel.Text += " - " + anyMax; }
            if (minTypes > 0) { RequiredTypesLabel.Text = minTypes.ToString(); }
            if (maxTypes == -1) { maxTypes = minTypes; }
            Requirements = new int[] { tasks, stories, features, epics, anyMin, anyMax, minTypes, maxTypes};
            Bought = false;
            Buyer = player;
            AvailableTasksLabel.Text = Buyer.Resources[0].ToString();
            AvailableStoriesLabel.Text = Buyer.Resources[1].ToString();
            AvailableFeaturesLabel.Text = Buyer.Resources[2].ToString();
            AvailableEpicsLabel.Text = Buyer.Resources[3].ToString();
            TaskNumericUpDown.Maximum = Buyer.Resources[0];
            StoryNumericUpDown.Maximum = Buyer.Resources[1];
            FeatureNumericUpDown.Maximum = Buyer.Resources[2];
            EpicNumericUpDown.Maximum = Buyer.Resources[3];

        }

        private void BuyButton_Click(object sender, EventArgs e)
        {
            bool EnoughResources = true;
            int[] Submitted = new int[] { (int)TaskNumericUpDown.Value, (int)StoryNumericUpDown.Value, (int)FeatureNumericUpDown.Value, (int)EpicNumericUpDown.Value };
            for (int i = 0; i < 4; i++)
            {
                if (Submitted[i] >= Requirements[i] && EnoughResources)
                {
                    Submitted[i] -= Requirements[i];
                }
                else
                {
                    EnoughResources = false;
                }
            }
            int TypesAvailable = 0;
            for (int i = 0; i < 4; i++)
            {
                if (Submitted[i] > 0) { TypesAvailable++; }
            }
            if (TypesAvailable >= Requirements[6] && TypesAvailable <= Requirements[7])
            {
                if (Submitted.Sum() >= Requirements[4] && Submitted.Sum() <= Requirements[5] && EnoughResources)
                {
                    Bought = true;
                    Submitted = new int[] { (int)TaskNumericUpDown.Value, (int)StoryNumericUpDown.Value, (int)FeatureNumericUpDown.Value, (int)EpicNumericUpDown.Value };
                    for (int i = 0; i < 4; i++)
                    {
                        Buyer.Resources[i] -= Submitted[i];
                        ((MainForm)Program.Properties).ResourceSupply[i] += Submitted[i];
                        ((MainForm)Program.Properties).UpdateLabels();
                    }
                    PayedResources = Submitted;
                    this.Close();
                }
            }
            ErrorLabel.Visible = true;
        }
    }
}
