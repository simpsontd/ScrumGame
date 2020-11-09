using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Resources;
using System.Windows.Forms;

namespace ScrumGame
{
    /// <summary>
    /// Contains Player data and methods for scoring
    /// </summary>
    public class Player
    {
        public String Name { get; set; }
        public int PlayerNumber { get; set; }
        public int NumProductOwnersOnHome { get; set; }
        public int NumScrumMastersOnHome { get; set; }
        public int NumFrontEndDevelopersOnHome { get; set; }
        public int NumBackEndDevelopersOnHome { get; set; }
        public int NumFullStackDevelopersOnHome { get; set; }
        public int[] Research { get; set; }
        public bool[] ResearchUsed { get; set; }
        private Image[] ResearchImageArray { get; set; }
        public Image[] UsedResearchImageArray { get; set; }
        public Image[] CurrentResearchImages { get; set; }
        public int[] Resources { get; set; }
        public int Money { get; set; }
        public int Points { get; set; }
        public List<ClientCard> ClientCardList { get; set; }
        public List<TechnologyCard> TechnologyCardList { get; set; }
        public List<Worker> WorkerList { get; set; }
        public int Budget { get; set; }
        public Color Color { get; set; }
        public Player(String name, Color color)
        {
            Name = name;
            PlayerNumber = 0;
            NumProductOwnersOnHome = 0;
            NumScrumMastersOnHome = 0;
            NumFrontEndDevelopersOnHome = 0;
            NumBackEndDevelopersOnHome = 0;
            NumFullStackDevelopersOnHome = 0;
            Research = new int[] { 0, 0, 0 };
            ResearchUsed = new bool[] { false, false, false };
            ResearchImageArray = new Image[] { ((System.Drawing.Image)(ScrumGame.Properties.Resources.ResearchLevel1)),
                                               ((System.Drawing.Image)(ScrumGame.Properties.Resources.ResearchLevel2)),
                                               ((System.Drawing.Image)(ScrumGame.Properties.Resources.ResearchLevel3)),
                                               ((System.Drawing.Image)(ScrumGame.Properties.Resources.ResearchLevel4)) };
            UsedResearchImageArray = new Image[] {  ((System.Drawing.Image)(ScrumGame.Properties.Resources.ResearchLevel1Used)),
                                                    ((System.Drawing.Image)(ScrumGame.Properties.Resources.ResearchLevel2Used)),
                                                    ((System.Drawing.Image)(ScrumGame.Properties.Resources.ResearchLevel3Used)),
                                                    ((System.Drawing.Image)(ScrumGame.Properties.Resources.ResearchLevel4Used)) };
            CurrentResearchImages = new Image[] { null, null, null };
            Money = 0;
            Resources = new int[] { 0, 0, 0, 0 };
            ClientCardList = new List<ClientCard>();
            TechnologyCardList = new List<TechnologyCard>();
            WorkerList = new List<Worker>();
            Budget = 0;
            Color = color;

        }
              
        
        /// <summary>
        /// Add research token if empty spot or upgrade if full
        /// </summary>
        public void UpgradeResearch()
        {
            if (Research[1] < Research[0])
            {
                Research[1]++;
                CurrentResearchImages[1] = ResearchImageArray[Research[1] - 1];
            }
            else if (Research[2] < Research[1])
            {
                Research[2]++;
                CurrentResearchImages[2] = ResearchImageArray[Research[2] - 1];
            }
            else if (Research[0] < 4)
            {
                Research[0]++;
                CurrentResearchImages[0] = ResearchImageArray[Research[0] - 1];
            }
        }

        /// <summary>
        /// Switch image to darkened "used" image for indexed research token
        /// </summary>
        /// <param name="index"></param>
        public void UseResearch(int index)
        {
            if (Research[index] > 0)
            {
                ResearchUsed[index] = true;
                CurrentResearchImages[index] = UsedResearchImageArray[Research[index] - 1];
                ((MainForm)Program.Properties).DiceTotal += Research[index];
            }
            
        }
        /// <summary>
        /// reset all research tokens to "unused" images
        /// </summary>
        public void ResetResearchUsed()
        {
            for (int i = 0; i < 3; i++)
            {
                if (Research[i] > 0)
                {
                    ResearchUsed[i] = false;
                    CurrentResearchImages[i] = ResearchImageArray[Research[i] - 1];
                }
            }
        }

        public void UpgradeBudget()
        {
            if (Budget < 10)
            {
                Budget++;
            }
        }

        public void GetEndPoints()
        {
            List<TechnologyCard> greenCards = new List<TechnologyCard>();
            foreach (TechnologyCard t in TechnologyCardList)
            {
                t.GetPoints();
                if (t.IsGreenBackground)
                {
                    greenCards.Add(t);
                }
                List<TechnologyCard> set;
                while (greenCards.Count > 0)
                {
                    set = new List<TechnologyCard>();
                    for (int i = 1; i <= 8; i++)
                    {
                        foreach (TechnologyCard gc in greenCards)
                        {
                            if (gc.CardPoints.Symbol == i)
                            {
                                set.Add(gc);
                                greenCards.Remove(gc);
                                break;
                            }
                        }
                    }
                    Points += set.Count * set.Count;
                }
                
            }
        }

        public void ChangeColor()
        {
            ColorDialog dialog = new ColorDialog();
            if(dialog.ShowDialog() == DialogResult.OK)
            {
                Color = dialog.Color;
            }
        }
    }
}
