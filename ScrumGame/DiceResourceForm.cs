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
    public partial class DiceResourceForm : Form
    {
        private Player CurrentPlayer { get; set; }
        private int NumPlayers { get; set; }
        public DiceResourceForm(Player owner)
        {
            InitializeComponent();
            CurrentPlayer = owner;
            InitializeCustomComponent();
            
        }
        private void InitializeCustomComponent()
        {
            PromptLabel.Text = CurrentPlayer.Name + " choose your item!";
            Random rand = new Random();
            Button[] buttons = new Button[] { Resource1Button, Resource2Button, Resource3Button, Resource4Button };
            NumPlayers = 0;
            for (int i = 0; i < 4; i++)
            {
                if (((MainForm)Program.Properties).Players[i] != null) { NumPlayers++; }
                buttons[i].Visible = false;
            }
            for (int i = 0; i < NumPlayers; i++)
            {
                
                switch (rand.Next(1, 7))
                {
                    case 1:
                        buttons[i].Text = "Task";
                        break;
                    case 2:
                        buttons[i].Text = "Story";
                        break;
                    case 3:
                        buttons[i].Text = "Feature";
                        break;
                    case 4:
                        buttons[i].Text = "Epic";
                        break;
                    case 5:
                        buttons[i].Text = "Research";
                        break;
                    case 6:
                        buttons[i].Text = "Budget";
                        break;
                }
                buttons[i].Visible = true;
            }
            
        }

        private void ResourceButton_Click(object sender, EventArgs e)
        {
            GivePlayerItem(((Button)sender).Text);
            ((Button)sender).Visible = false;
            if (!Resource1Button.Visible && !Resource2Button.Visible && !Resource3Button.Visible && !Resource4Button.Visible)
            {
                this.Close();
            }
            else
            {
                PromptLabel.Text = CurrentPlayer.Name + " choose your item!";
            }
        }


        private void GivePlayerItem(string item)
        {
            switch(item)
            {
                case "Task":
                    CurrentPlayer.Resources[0]++;
                    ((MainForm)Program.Properties).ResourceSupply[0]--;
                    break;
                case "Story":
                    CurrentPlayer.Resources[1]++;
                    ((MainForm)Program.Properties).ResourceSupply[1]--;
                    break;
                case "Feature":
                    CurrentPlayer.Resources[2]++;
                    ((MainForm)Program.Properties).ResourceSupply[2]--;
                    break;
                case "Epic":
                    CurrentPlayer.Resources[3]++;
                    ((MainForm)Program.Properties).ResourceSupply[3]--;
                    break;
                case "Research":
                    CurrentPlayer.UpgradeResearch();
                    ((MainForm)Program.Properties).UpdateLabels();
                    break;
                case "Budget":
                    CurrentPlayer.UpgradeBudget();
                    ((MainForm)Program.Properties).UpdateLabels();
                    break;
            }
            ((MainForm)Program.Properties).UpdateLabels();
            if (CurrentPlayer.PlayerNumber < NumPlayers)
            {
                CurrentPlayer = ((MainForm)Program.Properties).Players[CurrentPlayer.PlayerNumber];
            }
            else
            {
                CurrentPlayer = ((MainForm)Program.Properties).Players[0];
            }
            
            
        }
    }
}
