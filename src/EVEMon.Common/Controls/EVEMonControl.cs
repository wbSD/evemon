using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EVEMon.Common.Interfaces;
using EVEMon.Common.Extensions;

namespace EVEMon.Common.Controls
{
    public partial class EVEMonControl : UserControl, IThemeable
    {
        public EVEMonControl()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.FindAndRecolorControls();
        }
    }
}
