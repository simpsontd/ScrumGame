using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScrumGame
{
    /// <summary>
    /// Load image based on this class type and the owner (player color)
    /// </summary>
    class ScrumMaster : Worker
    {
        protected override void LoadImage()
        {
            if (Owner == null)
            {
                Control.Image = global::ScrumGame.Properties.Resources.ScrumMasterNeutral;
            }
            else
            {
                Control.Image = global::ScrumGame.Properties.Resources.ScrumMasterTransparent;
                Control.BackColor = Owner.Color;
            }
        }
    }
}
