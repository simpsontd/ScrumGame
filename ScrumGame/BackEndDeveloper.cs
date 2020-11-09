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
    class BackEndDeveloper : Worker
    {
        protected override void LoadImage()
        {
            if (Owner == null)
            {
                Control.Image = global::ScrumGame.Properties.Resources.BackEndDeveloperNeutral;
            }
            else
            {
                Control.Image = global::ScrumGame.Properties.Resources.BackEndDeveloperTransparent;
                Control.BackColor = Owner.Color;
            }
        }
    }
}
