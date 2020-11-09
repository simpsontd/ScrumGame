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
    public partial class JobFairSelectionForm : Form
    {
        private bool ClosedWithXButton { get; set; }
        public JobFairSelectionForm()
        {
            InitializeComponent();
            if (((MainForm)Program.Properties).FrontEndDeveloperSupplyList.Count == 0)
            {
                FrontEndDeveloperSupplyPictureBox.Visible = false;
            }
            if (((MainForm)Program.Properties).BackEndDeveloperSupplyList.Count == 0)
            {
                BackEndDeveloperSupplyPictureBox.Visible = false;
            }
            if (((MainForm)Program.Properties).FullStackDeveloperSupplyList.Count == 0)
            {
                FullStackDeveloperSupplyPictureBox.Visible = false;
            }
            ClosedWithXButton = true;

        }

        private void FrontEndDeveloperSupplyPictureBox_Click(object sender, EventArgs e)
        {
            Worker w = ((MainForm)Program.Properties).FrontEndDeveloperSupplyList[0];
            ((MainForm)Program.Properties).FrontEndDeveloperSupplyList.RemoveAt(0);
            w.Owner = ((MainForm)Program.Properties).ActivePlayer;
            ((MainForm)Program.Properties).ActivePlayer.WorkerList.Add(w);
            ((MainForm)Program.Properties).ReturnWorker(w);
            ClosedWithXButton = false;
            this.Close();
        }

        private void BackEndDeveloperSupplyPictureBox_Click(object sender, EventArgs e)
        {
            Worker w = ((MainForm)Program.Properties).BackEndDeveloperSupplyList[0];
            ((MainForm)Program.Properties).BackEndDeveloperSupplyList.RemoveAt(0);
            w.Owner = ((MainForm)Program.Properties).ActivePlayer;
            ((MainForm)Program.Properties).ActivePlayer.WorkerList.Add(w);
            ((MainForm)Program.Properties).ReturnWorker(w);
            ClosedWithXButton = false;
            this.Close();
        }

        private void FullStackDeveloperSupplyPictureBox_Click(object sender, EventArgs e)
        {
            Worker w = ((MainForm)Program.Properties).FullStackDeveloperSupplyList[0];
            ((MainForm)Program.Properties).FullStackDeveloperSupplyList.RemoveAt(0);
            w.Owner = ((MainForm)Program.Properties).ActivePlayer;
            ((MainForm)Program.Properties).ActivePlayer.WorkerList.Add(w);
            ((MainForm)Program.Properties).ReturnWorker(w);
            ClosedWithXButton = false;
            this.Close();
        }

        private void JobFairSelectionForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (ClosedWithXButton)
            {
                List<Worker> indexes = new List<Worker>();
                if (FrontEndDeveloperSupplyPictureBox.Visible)
                {
                    indexes.Add(((MainForm)Program.Properties).FrontEndDeveloperSupplyList[0]);
                }
                if (BackEndDeveloperSupplyPictureBox.Visible)
                {
                    indexes.Add(((MainForm)Program.Properties).BackEndDeveloperSupplyList[0]);
                }
                if (FullStackDeveloperSupplyPictureBox.Visible)
                {
                    indexes.Add(((MainForm)Program.Properties).FullStackDeveloperSupplyList[0]);
                }
                Random rand = new Random();
                Worker w = indexes[rand.Next(0, indexes.Count)];
                w.Owner = ((MainForm)Program.Properties).ActivePlayer;
                ((MainForm)Program.Properties).ActivePlayer.WorkerList.Add(w);
                ((MainForm)Program.Properties).ReturnWorker(w);

            }
        }
    }
}
