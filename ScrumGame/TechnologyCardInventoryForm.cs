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
    public partial class TechnologyCardInventoryForm : Form
    {
        private Player CardOwner { get; set; }
        private List<PictureBox> Boxes { get; set; }
        private List<Point> Points { get; set; }
        public TechnologyCardInventoryForm(Player owner)
        {
            InitializeComponent();
            CardOwner = owner;
            InitializeCustomComponent();
        }
        private void InitializeCustomComponent()
        {
            Points = new List<Point>();
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    Points.Add(new Point(j * 108 + 10, i * 132 + 10));
                }
            }
            Boxes = new List<PictureBox>();
            
            for (int i = 0; i < CardOwner.TechnologyCardList.Count; i++)
            {
                PictureBox tempBox = new PictureBox();
                tempBox.Location = Points[i];
                tempBox.Size = new System.Drawing.Size(80, 120);
                tempBox.Image = CardOwner.TechnologyCardList[i].Image;
                tempBox.MouseClick += (MouseEventHandler)Box_Click;
                tempBox.Tag = i;
                Boxes.Add(tempBox);
                this.Controls.Add(tempBox);
            }
        }
        private void Box_Click (object sender, EventArgs e)
        {
            TechnologyCard card = CardOwner.TechnologyCardList[(int)((PictureBox)sender).Tag];
            if (card.CardEvent is WildResourceEvent && !((WildResourceEvent)card.CardEvent).IsUsed)
            {
                ((WildResourceEvent)card.CardEvent).UseResource();
            }
            ((PictureBox)sender).Image = card.Image;
        }
    }
}
