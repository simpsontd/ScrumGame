using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace ScrumGame
{
    public class Worker
    {
        public bool IsAssigned { get; set; }
        /// <summary>
        /// PictureBox associated with this worker
        /// </summary>
        public PictureBox Control { get; set; }

        /// <summary>
        /// Player who owns this worker
        /// </summary>
        private Player _owner { get; set; }

        /// <summary>
        /// Property with setter to set _owner
        /// </summary>
        public Player Owner
        {
            get
            {
                return _owner;
            }
            set
            {
                _owner = value;
                this.LoadImage();
            }
        }

        
        /// <summary>
        /// Default Constructor
        /// </summary>
        public Worker()
        {
            Control = new PictureBox();
            Control.BackColor = System.Drawing.Color.Transparent;
            Control.Location = new Point(0, 0);
            Control.Margin = new System.Windows.Forms.Padding(4);
            Control.Size = new System.Drawing.Size(40, 40);
            LoadImage();
            IsAssigned = false;

        }

        /// <summary>
        /// Parameterized Constructor
        /// </summary>
        /// <param name="owner"></param>
        public Worker(Player owner = null)
        {
            Owner = owner;
            Control = new PictureBox();
            Control.BackColor = System.Drawing.Color.Transparent;
            Control.Image = global::ScrumGame.Properties.Resources.FrontEndDeveloperNeutral;
            Control.Location = new Point(0, 0);
            Control.Margin = new System.Windows.Forms.Padding(4);
            Control.Size = new System.Drawing.Size(40, 40);
            LoadImage();
            IsAssigned = false;
        }

        /// <summary>
        /// Virtual method to load the image associated with the worker type
        /// </summary>
        protected virtual void LoadImage()
        {

        }

    }
}
