using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScrumGame
{
    class FullStackDeveloper : Worker
    {
        /// <summary>
        /// Load image based on this class type and the owner (player color)
        /// </summary>
        protected override void LoadImage()
        {
            if (Owner == null)
            {
                Control.Image = global::ScrumGame.Properties.Resources.FullStackDeveloperNeutral;
            }
            else
            {
                Control.Image = global::ScrumGame.Properties.Resources.FullStackDeveloperTransparent;
                Control.BackColor = Owner.Color;
            }
        }
    }
}
