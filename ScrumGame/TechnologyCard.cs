using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace ScrumGame
{
    
    public class TechnologyCard
    {
        /// <summary>
        /// Image of the card
        /// </summary>
        public Image Image { get; set; }
        public Player Owner { get; set; }
        public TechnologyCardEvent CardEvent { get; set; }
        public TechnologyCardGetPoints CardPoints { get; set; }
        public bool IsGreenBackground { get; set; }
        public TechnologyCard(Image image)
        {
            IsGreenBackground = false;
            Image = image;
        }

        public void GetPoints()
        {
            CardPoints.GetPoints();
        }

        public void GetEvent()
        {
            CardEvent.GetEvent();
        }

    }

    public class TechnologyCardEvent
    {
        public TechnologyCard Card { get; set; }
        public virtual void GetEvent()
        {

        }
    }

    public class DiceEvent : TechnologyCardEvent
    {
        public DiceEvent(ref TechnologyCard card)
        {
            Card = card;
        }
        public override void GetEvent()
        {
            DiceResourceForm form = new DiceResourceForm(Card.Owner);
            form.ShowDialog();
            ((MainForm)Program.Properties).UpdateLabels();
        }
    }
    public class MoneyEvent : TechnologyCardEvent
    {
        private int Money { get; set; }
        public MoneyEvent(ref TechnologyCard card, int money)
        {
            Card = card;
            Money = money;
        }
        public override void GetEvent()
        {
            Card.Owner.Money += Money;
            ((MainForm)Program.Properties).UpdateLabels();
        }
    }
    public class ResourceEvent : TechnologyCardEvent
    {
        private int[] Resources { get; set; }
        public ResourceEvent(ref TechnologyCard card, int Task, int Story, int Feature, int Epic)
        {
            Card = card;
            Resources = new int[] { Task, Story, Feature, Epic };
        }
        public override void GetEvent()
        {
            for (int i = 0; i < 4; i++)
            {
                if (((MainForm)Program.Properties).ResourceSupply[i] < Resources[i])
                {
                    Resources[i] = ((MainForm)Program.Properties).ResourceSupply[i];
                }
                Card.Owner.Resources[i] += Resources[i];
                ((MainForm)Program.Properties).ResourceSupply[i] -= Resources[i];
            }
            ((MainForm)Program.Properties).UpdateLabels();
        }
    }
    public class PointsEvent : TechnologyCardEvent
    {
        private int Points { get; set; }
        public PointsEvent(ref TechnologyCard card, int points)
        {
            Card = card;
            Points = points;
        }
        public override void GetEvent()
        {
            Card.Owner.Points += Points;
            ((MainForm)Program.Properties).UpdateLabels();
        }
    }
    public class ResearchEvent : TechnologyCardEvent
    {
        public ResearchEvent(ref TechnologyCard card)
        {
            Card = card;
        }
        public override void GetEvent()
        {
            Card.Owner.UpgradeResearch();
            ((MainForm)Program.Properties).UpdateLabels();
        }
    }
    public class DrawCardEvent : TechnologyCardEvent
    {
        public DrawCardEvent(ref TechnologyCard card)
        {
            Card = card;
        }
        public override void GetEvent()
        {
            if (((MainForm)Program.Properties).TechnologyCardStack.Count > 0)
            {
                Card.Owner.TechnologyCardList.Add(((MainForm)Program.Properties).TechnologyCardStack.Pop());
            }
            
            if (((MainForm)Program.Properties).TechnologyCardStack.Count <= 0)
            {
                ((MainForm)Program.Properties).TechnologyCardSupplyPictureBox.Image = null;
            }
        }
    }
    public class TempResearchEvent : TechnologyCardEvent
    {
        public int ResearchLevel { get; set; }
        public bool IsUsed { get; set; }
        public TempResearchEvent(ref TechnologyCard card, int researchLevel)
        {
            Card = card;
            ResearchLevel = researchLevel;
            IsUsed = false;
        }
        public override void GetEvent()
        {
            MessageBox.Show("Player may play this card as they would a research token by clicking this card from their Technology Card Inventory. This action may only be used once.");
        }
        public void UseResearch()
        {
            switch (ResearchLevel)
            {
                case 4:
                    Card.Image = ((System.Drawing.Image)(ScrumGame.Properties.Resources.TechnologyCard33Used));
                    break;
                case 3:
                    Card.Image = ((System.Drawing.Image)(ScrumGame.Properties.Resources.TechnologyCard34Used));
                    break;
                case 2:
                    Card.Image = ((System.Drawing.Image)(ScrumGame.Properties.Resources.TechnologyCard35Used));
                    break;
                    
            }
            ((MainForm)Program.Properties).DiceTotal += ResearchLevel;
            IsUsed = true;
            
        }
    }
    public class WildResourceEvent : TechnologyCardEvent
    {
        public bool IsUsed { get; set; }
        public WildResourceEvent(ref TechnologyCard card)
        {
            Card = card;
            IsUsed = false;
        }
        public override void GetEvent()
        {
            MessageBox.Show("Player may use this card to receive two resources of their choice by clicking it in their Technology card Inventory. This action may only be used once.");
        }
        public void UseResource()
        {
            if (!IsUsed)
            {
                WildResourceForm form = new WildResourceForm(Card);
                form.ShowDialog();
                if (IsUsed)
                {
                    Card.Image = ((System.Drawing.Image)(ScrumGame.Properties.Resources.TechnologyCard36Used));
                    ((MainForm)Program.Properties).UpdateLabels();
                }

            }
        }
    }
    public class DiceResourceEvent : TechnologyCardEvent
    {
        public int ResourceType { get; set; }
        public DiceResourceEvent(ref TechnologyCard card, int resourceIndex)
        {
            Card = card;
            ResourceType = resourceIndex;
        }
        public override void GetEvent()
        {
            int resources = 0;
            ((MainForm)Program.Properties).DiceAmount.Text = "2";
            ((MainForm)Program.Properties).RollDice();
            resources = ((MainForm)Program.Properties).DiceTotal / (ResourceType + 3);
            if (resources > ((MainForm)Program.Properties).ResourceSupply[ResourceType])
            {
                resources = ((MainForm)Program.Properties).ResourceSupply[ResourceType];
            }
            Card.Owner.Resources[ResourceType] += resources;
            ((MainForm)Program.Properties).ResourceSupply[ResourceType] -= resources;
            ((MainForm)Program.Properties).UpdateLabels();
        }
    }

    public class BudgetEvent : TechnologyCardEvent
    {
        public BudgetEvent(ref TechnologyCard card)
        {
            Card = card;
        }
        public override void GetEvent()
        {
            if (Card.Owner.Budget < 10)
            {
                Card.Owner.Budget++;
                ((MainForm)Program.Properties).UpdateLabels();
            }
        }
    }
    public class TechnologyCardGetPoints
    {
        public TechnologyCard Card { get; set; }
        protected int Multiplier { get; set; }

        public int Symbol { get; set; }
       
        public virtual void GetPoints()
        {

        }
    }
    public class GreenCardPoints : TechnologyCardGetPoints
    {
        public GreenCardPoints(ref TechnologyCard card, int SymbolNum)
        {
            Card = card;
            Card.IsGreenBackground = true;
            Symbol = SymbolNum;
        }
    }
    public class ClientCardPoints : TechnologyCardGetPoints
    {
        
        public ClientCardPoints(ref TechnologyCard card, int multiplier)
        {
            Card = card;
            Multiplier = multiplier;
        }
        public override void GetPoints()
        {
            Card.Owner.Points += (Multiplier * Card.Owner.ClientCardList.Count);
            ((MainForm)Program.Properties).UpdateLabels();
        }
    }
    public class ResearchTokenPoints : TechnologyCardGetPoints
    {

        public ResearchTokenPoints(ref TechnologyCard card, int multiplier)
        {
            Card = card;
            Multiplier = Multiplier;
        }
        public override void GetPoints()
        {
            Card.Owner.Points += (Multiplier * Card.Owner.Research.Sum());
            ((MainForm)Program.Properties).UpdateLabels();
        }
    }
    public class WorkerPoints : TechnologyCardGetPoints
    {

        public WorkerPoints(ref TechnologyCard card, int multiplier)
        {
            Card = card;
            Multiplier = multiplier;
        }
        public override void GetPoints()
        {
            Card.Owner.Points += (Multiplier * Card.Owner.WorkerList.Count);
            ((MainForm)Program.Properties).UpdateLabels();
        }
    }
    public class BudgetPoints : TechnologyCardGetPoints
    {
        public BudgetPoints(ref TechnologyCard card, int multiplier)
        {
            Card = card;
            Multiplier = multiplier;
        }
        public override void GetPoints()
        {
            Card.Owner.Points += (Multiplier * Card.Owner.Budget);
            ((MainForm)Program.Properties).UpdateLabels();
        }
    }

}
