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
    public partial class UseResearchForm : Form
    {
        public bool IsEmpty { get; set; }
        public Player CurrentPlayer { get; set; }

        public UseResearchForm(Player player)
        {
            CurrentPlayer = player;
            IsEmpty = true;
            InitializeComponent();
            InitializeCustomComponent();
            

        }
        private void InitializeCustomComponent()
        {
            if (CurrentPlayer.CurrentResearchImages[0] != null)
            {
                Research1PictureBox.Image = CurrentPlayer.CurrentResearchImages[0];
                if (!CurrentPlayer.UsedResearchImageArray.Contains(CurrentPlayer.CurrentResearchImages[0]))
                {
                    IsEmpty = false;
                }
            }
            if (CurrentPlayer.CurrentResearchImages[1] != null)
            {
                Research2PictureBox.Image = CurrentPlayer.CurrentResearchImages[1];
                if (!CurrentPlayer.UsedResearchImageArray.Contains(CurrentPlayer.CurrentResearchImages[1]))
                {
                    IsEmpty = false;
                }
            }
            if (CurrentPlayer.CurrentResearchImages[2] != null)
            {
                Research3PictureBox.Image = CurrentPlayer.CurrentResearchImages[2];
                if (!CurrentPlayer.UsedResearchImageArray.Contains(CurrentPlayer.CurrentResearchImages[2]))
                {
                    IsEmpty = false;
                }
            }
            if (CurrentPlayer.TechnologyCardList.Contains(((MainForm)Program.Properties).TechnologyCardMasterArray[32]))
            {
                TechnologyCard1PictureBox.Image = ((MainForm)Program.Properties).TechnologyCardMasterArray[32].Image;
                if (TechnologyCard1PictureBox.Image != ((System.Drawing.Image)(ScrumGame.Properties.Resources.TechnologyCard33Used)))
                {
                    IsEmpty = false;
                }
            }
            if (CurrentPlayer.TechnologyCardList.Contains(((MainForm)Program.Properties).TechnologyCardMasterArray[33]))
            {
                TechnologyCard2PictureBox.Image = ((MainForm)Program.Properties).TechnologyCardMasterArray[33].Image;
                if (TechnologyCard2PictureBox.Image != ((System.Drawing.Image)(ScrumGame.Properties.Resources.TechnologyCard34Used)))
                {
                    IsEmpty = false;
                }
            }
            if (CurrentPlayer.TechnologyCardList.Contains(((MainForm)Program.Properties).TechnologyCardMasterArray[34]))
            {
                TechnologyCard3PictureBox.Image = ((MainForm)Program.Properties).TechnologyCardMasterArray[34].Image;
                if (TechnologyCard3PictureBox.Image != ((System.Drawing.Image)(ScrumGame.Properties.Resources.TechnologyCard35Used)))
                {
                    IsEmpty = false;
                }
            }

        }

        private void Research1PictureBox_Click(object sender, EventArgs e)
        {
            CurrentPlayer.UseResearch(0);
            Research1PictureBox.Image = CurrentPlayer.CurrentResearchImages[0];
        }

        private void Research2PictureBox_Click(object sender, EventArgs e)
        {
            CurrentPlayer.UseResearch(1);
            Research2PictureBox.Image = CurrentPlayer.CurrentResearchImages[1];
        }

        private void Research3PictureBox_Click(object sender, EventArgs e)
        {
            CurrentPlayer.UseResearch(2);
            Research3PictureBox.Image = CurrentPlayer.CurrentResearchImages[2];
        }

        private void TechnologyCard1PictureBox_Click(object sender, EventArgs e)
        {
            if (CurrentPlayer.TechnologyCardList.Contains(((MainForm)Program.Properties).TechnologyCardMasterArray[32]))
            {
                ((TempResearchEvent)(((MainForm)Program.Properties).TechnologyCardMasterArray[32].CardEvent)).UseResearch();
                TechnologyCard1PictureBox.Image = ((MainForm)Program.Properties).TechnologyCardMasterArray[32].Image;
            }
                
        }

        private void TechnologyCard2PictureBox_Click(object sender, EventArgs e)
        {
            if (CurrentPlayer.TechnologyCardList.Contains(((MainForm)Program.Properties).TechnologyCardMasterArray[33]))
            {
                ((TempResearchEvent)(((MainForm)Program.Properties).TechnologyCardMasterArray[33].CardEvent)).UseResearch();
                TechnologyCard2PictureBox.Image = ((MainForm)Program.Properties).TechnologyCardMasterArray[33].Image;
            }
                
        }

        private void TechnologyCard3PictureBox_Click(object sender, EventArgs e)
        {
            if (CurrentPlayer.TechnologyCardList.Contains(((MainForm)Program.Properties).TechnologyCardMasterArray[34]))
            {
                ((TempResearchEvent)(((MainForm)Program.Properties).TechnologyCardMasterArray[34].CardEvent)).UseResearch();
                TechnologyCard3PictureBox.Image = ((MainForm)Program.Properties).TechnologyCardMasterArray[34].Image;
            }
                
        }

        private void DoneButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void UseResearch_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }
    }
}
