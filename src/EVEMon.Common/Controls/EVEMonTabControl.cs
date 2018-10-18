using EVEMon.Common.Extensions;
using EVEMon.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EVEMon.Common.Controls
{
    public class EVEMonTabControl : TabControl, IThemeable
    {
        private Color m_backColor;
        public override Color BackColor { get => m_backColor; set => m_backColor = value; }

        public EVEMonTabControl()
        {
        }

        protected override void OnVisibleChanged(EventArgs e)
        {
            base.OnVisibleChanged(e);

            if (Visible)
                this.FindAndRecolorControls();
        }
    }
}
