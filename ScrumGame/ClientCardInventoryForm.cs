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
    /// <summary>
    /// Display the Client Crads in a player's inventory
    /// </summary>
    public partial class ClientCardInventoryForm : Form
    {
        /// <summary>
        /// The player that owns the Client Cards
        /// </summary>
        private Player CardOwner { get; set; }
        /// <summary>
        /// Hold picture boxes to access via index
        /// </summary>
        private List<PictureBox> Boxes { get; set; }
        /// <summary>
        /// Hold points for each pictureBox
        /// </summary>
        private List<Point> Points { get; set; }
        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="owner"></param>
        public ClientCardInventoryForm(Player owner)
        {
            InitializeComponent();
            CardOwner = owner;
            InitializeCustomComponent();
        }
        /// <summary>
        /// Create pictureboxes and load images
        /// </summary>
        private void InitializeCustomComponent()
        {
            Points = new List<Point>();
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    Points.Add(new Point(j * 80 + 10, i * 110 + 10));
                }
            }
            Boxes = new List<PictureBox>();
            for (int i = 0; i < CardOwner.ClientCardList.Count; i++)
            {
                PictureBox tempBox = new PictureBox();
                tempBox.Location = Points[i];
                tempBox.Size = new System.Drawing.Size(60, 90);
                tempBox.Image = CardOwner.ClientCardList[i].Image;
                tempBox.Tag = i;
                Boxes.Add(tempBox);
                this.Controls.Add(tempBox);
            }
        }
    }
}
