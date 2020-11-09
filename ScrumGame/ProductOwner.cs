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
    class ProductOwner : Worker
    {
        protected override void LoadImage()
        {
            if (Owner == null)
            {
                Control.BackgroundImage = global::ScrumGame.Properties.Resources.ProductOwnerNeutral;
            }
            else
            {
                Control.BackgroundImage = global::ScrumGame.Properties.Resources.ProductOwnerTransparent;
                Control.BackColor = Owner.Color;
            }
        }
    }
}
