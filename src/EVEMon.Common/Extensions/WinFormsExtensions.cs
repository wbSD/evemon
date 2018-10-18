using EVEMon.Common.Interfaces;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace EVEMon.Common.Extensions
{
    public static class WinFormsExtensions
    {
        /// <summary>
        /// Selects every item in a <c>List</c>.
        /// </summary>
        /// <remarks>
        /// Not recommended for use on a <c>ListView</c> that contains thousands of items.
        /// </remarks>
        /// <param name="lv"><c>ListView</c> to select all items in</param>
        public static void SelectAll(this ListView lv)
        {
            if (lv == null)
                return;

            if (lv.Items.Count == 0)
                return;

            foreach (ListViewItem item in lv.Items)
            {
                item.Selected = true;
            }
        }

        public static void FindAndRecolorControls(this Control control)
        {
            foreach (var c in control.Controls.Cast<Control>())
            {
                if (typeof(IThemeable).IsAssignableFrom(c.GetType()))
                    ((IThemeable)c).BackColor = Color.DarkGray;
                if (c.HasChildren)
                    FindAndRecolorControls(c);
            }
        }
    }
}
