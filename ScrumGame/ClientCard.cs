using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace ScrumGame
{
    public class ClientCard
    {
        /// <summary>
        /// Player that ows this card
        /// </summary>
        public Player Owner { get; set; }
        /// <summary>
        /// Points given by this card
        /// </summary>
        public int Points { get; set; }
        /// <summary>
        /// Resources required to obtain this card
        /// </summary>
        public int[] RequiredResources { get; set; }
        /// <summary>
        /// Keep track of resources payed
        /// </summary>
        public int[] PayedResources { get; set; }
        /// <summary>
        /// Image associated with this card
        /// </summary>
        public Image Image { get; set; }
        /// <summary>
        /// Default Constructor
        /// </summary>
        public ClientCard()
        {

        }
        /// <summary>
        /// Add points to the owner of this card depending on inherited type
        /// </summary>
        public virtual void GetPoints()
        {

        }

        /// <summary>
        /// Buy card using required resources
        /// </summary>
        /// <param name="player"></param>
        public virtual void BuyCard(Player player) { }
    }
    /// <summary>
    /// Client card with three resource reqirements and set point reward
    /// </summary>
    public class NormalClientCard : ClientCard
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="resource1"></param>
        /// <param name="resource2"></param>
        /// <param name="resource3"></param>
        /// <param name="points"></param>
        public NormalClientCard(int resource1, int resource2, int resource3, int points)
        {
            Points = points;
            RequiredResources = new int[4];
            RequiredResources[resource1]++;
            RequiredResources[resource2]++;
            RequiredResources[resource3]++;
            PayedResources = new int[4];
        }
        /// <summary>
        /// give owner of this card the points
        /// </summary>
        public override void GetPoints()
        {
            this.Owner.Points += Points;
            ((MainForm)Program.Properties).UpdateLabels();
        }


        public override void BuyCard(Player player)
        {
            BuyCardForm form = new BuyCardForm(player, RequiredResources[0], RequiredResources[1], RequiredResources[2], RequiredResources[3], 0, 0, 0);
            form.ShowDialog();
            if (form.Bought == true)
            {
                Owner = player;
                GetPoints();
            }
        }
    }
    /// <summary>
    /// Client card that accepts different combinations of resources based on some restrictions
    /// </summary>
    public class VarietyClientCard : ClientCard
    {
        /// <summary>
        /// Number of total resources required to obtain card
        /// </summary>
        private int NumRequiredResources { get; set; }
        /// <summary>
        /// Number of types of resources required to obtain card
        /// </summary>
        private int NumTypesResources { get; set; }
        /// <summary>
        /// Default Constructor
        /// </summary>
        /// <param name="numResources"></param>
        /// <param name="numKinds"></param>
        public VarietyClientCard(int numResources, int numKinds)
        {
            NumRequiredResources = numResources;
            NumTypesResources = numKinds;
            PayedResources = new int[4];
        }
        /// <summary>
        /// Give owner points based on resources payed
        /// </summary>
        public override void GetPoints()
        {
            for (int i = 0; i < 4; i++)
            {
                Owner.Points += PayedResources[i] * (3 + i);
                ((MainForm)Program.Properties).UpdateLabels();
            }
        }


        public override void BuyCard(Player player)
        {
            BuyCardForm form = new BuyCardForm(player, 0, 0, 0, 0, NumRequiredResources, NumRequiredResources, NumTypesResources);
            form.ShowDialog();
            if (form.Bought == true)
            {
                PayedResources = form.PayedResources;
                Owner = player;
                GetPoints();
            }
        }
    }
    /// <summary>
    /// Client card which requires up to seven resources of any combination
    /// </summary>
    public class WildSevenClientCard : ClientCard
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public WildSevenClientCard()
        {
            PayedResources = new int[4];
        }
        /// <summary>
        /// Give points to owner based on resources payed
        /// </summary>
        public override void GetPoints()
        {
            for (int i = 0; i < 4; i++)
            {
                Owner.Points += PayedResources[i] * (3 + i);
                ((MainForm)Program.Properties).UpdateLabels();
            }
        }


        public override void BuyCard(Player player)
        {
            BuyCardForm form = new BuyCardForm(player, 0, 0, 0, 0, 1, 7, 0, 4);
            form.ShowDialog();
            if (form.Bought == true)
            {
                PayedResources = form.PayedResources;
                Owner = player;
                GetPoints();
            }
        }

    }

}
