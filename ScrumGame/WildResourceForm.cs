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
    public partial class WildResourceForm : Form
    {
        public TechnologyCard Card { get; set; }
        public WildResourceForm(TechnologyCard card)
        {
            InitializeComponent();
            Card = card;
        }

        private void RetrieveButton_Click(object sender, EventArgs e)
        {
            if ((Task1RadioButton.Checked || Story1RadioButton.Checked || Feature1RadioButton.Checked || Epic1RadioButton.Checked) && (Task2RadioButton.Checked || Story2RadioButton.Checked || Feature2RadioButton.Checked || Epic2RadioButton.Checked))
            {
                if (Task1RadioButton.Checked && ((MainForm)Program.Properties).ResourceSupply[0] > 0) { Card.Owner.Resources[0]++; ((MainForm)Program.Properties).ResourceSupply[0]--; }
                if (Task2RadioButton.Checked && ((MainForm)Program.Properties).ResourceSupply[0] > 0) { Card.Owner.Resources[0]++; ((MainForm)Program.Properties).ResourceSupply[0]--; }
                if (Story1RadioButton.Checked && ((MainForm)Program.Properties).ResourceSupply[1] > 0) { Card.Owner.Resources[1]++; ((MainForm)Program.Properties).ResourceSupply[0]--; }
                if (Story2RadioButton.Checked && ((MainForm)Program.Properties).ResourceSupply[1] > 0) { Card.Owner.Resources[1]++; ((MainForm)Program.Properties).ResourceSupply[0]--; }
                if (Feature1RadioButton.Checked && ((MainForm)Program.Properties).ResourceSupply[2] > 0) { Card.Owner.Resources[2]++; ((MainForm)Program.Properties).ResourceSupply[0]--; }
                if (Feature2RadioButton.Checked && ((MainForm)Program.Properties).ResourceSupply[2] > 0) { Card.Owner.Resources[2]++; ((MainForm)Program.Properties).ResourceSupply[0]--; }
                if (Epic1RadioButton.Checked && ((MainForm)Program.Properties).ResourceSupply[3] > 0) { Card.Owner.Resources[3]++; ((MainForm)Program.Properties).ResourceSupply[0]--; }
                if (Epic2RadioButton.Checked && ((MainForm)Program.Properties).ResourceSupply[3] > 0) { Card.Owner.Resources[3]++; ((MainForm)Program.Properties).ResourceSupply[0]--; }
                ((MainForm)Program.Properties).UpdateLabels();
                ((WildResourceEvent)Card.CardEvent).IsUsed = true;
                this.Close();
            }
            else
            {
                ErrorLabel.Visible = true;
            }
        }
    }
}
