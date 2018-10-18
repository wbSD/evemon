﻿using System;
using System.Collections;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using EVEMon.Common.Constants;
using EVEMon.Common.Controls;
using EVEMon.Common.Data;
using EVEMon.Common.Enumerations;
using EVEMon.Common.Models;
using EVEMon.Common.Serialization.Eve;
using EVEMon.Common.Service;
using EVEMon.SkillPlanner;

namespace EVEMon.Controls
{
    public partial class KillReportAttacker : EVEMonControl
    {
        private SerializableKillLogAttackersListItem m_attacker;
        private Item m_selectedItem;


        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="KillReportAttacker"/> class.
        /// </summary>
        public KillReportAttacker()
        {
            InitializeComponent();

            // Set the mouse click event for each control to handle the parent panel scrolling
            SetControlMouseEvents(Controls);
        }


        #endregion


        #region Properties

        /// <summary>
        /// Gets or sets the attacker.
        /// </summary>
        /// <value>
        /// The attacker.
        /// </value>
        internal SerializableKillLogAttackersListItem Attacker
        {
            get { return m_attacker; }
            set
            {
                m_attacker = value;
                UpdateContent();
            }
        }

        /// <summary>
        /// Gets or sets the kill log.
        /// </summary>
        /// <value>
        /// The kill log.
        /// </value>
        internal KillLog KillLog { private get; set; }

        #endregion


        #region Content Management Methods

        /// <summary>
        /// Updates the content.
        /// </summary>
        private void UpdateContent()
        {
            CharacterNameLabel.Text = String.IsNullOrEmpty(m_attacker.Name) ? m_attacker.ShipTypeName : m_attacker.Name;
            CorpNameLabel.Text = m_attacker.CorporationName;
            AllianceNameLabel.Text = m_attacker.AllianceID == 0 ? String.Empty : m_attacker.AllianceName;

            DamageDoneLabel.Text = String.Format(CultureConstants.DefaultCulture, DamageDoneLabel.Text, m_attacker.DamageDone,
                m_attacker.DamageDone / (double)KillLog.Victim.DamageTaken);

            Task.WhenAll(
                GetImageForAsync(CharacterPictureBox),
                GetImageForAsync(ShipPictureBox),
                GetImageForAsync(WeaponPictureBox));
        }

        /// <summary>
        /// Gets the image for the specified picture box.
        /// </summary>
        /// <param name="pictureBox">The picture box.</param>
        /// <param name="useFallbackUri">if set to <c>true</c> [use fallback URI].</param>
        private async Task GetImageForAsync(PictureBox pictureBox, bool useFallbackUri = false)
        {
            while (true)
            {
                Image img = await ImageService.GetImageAsync(GetImageUrl(pictureBox, useFallbackUri));

                if (img == null && !useFallbackUri)
                {
                    useFallbackUri = true;
                    continue;
                }

                pictureBox.Image = img;
                break;
            }
        }

        /// <summary>
        /// Gets the image URL.
        /// </summary>
        /// <param name="pictureBox">The picture box.</param>
        /// <param name="useFallbackUri">if set to <c>true</c> [use fallback URI].</param>
        /// <returns></returns>
        private Uri GetImageUrl(PictureBox pictureBox, bool useFallbackUri)
        {
            string path;

            if (pictureBox == CharacterPictureBox)
            {
                path = String.Format(CultureConstants.InvariantCulture,
                    NetworkConstants.CCPPortraits, m_attacker.ID, (int)EveImageSize.x64);

                return useFallbackUri
                    ? ImageService.GetImageServerBaseUri(path)
                    : ImageService.GetImageServerCdnUri(path);
            }

            int typeId = pictureBox.Equals(ShipPictureBox)
                ? m_attacker.ShipTypeID
                : m_attacker.WeaponTypeID;

            path = String.Format(CultureConstants.InvariantCulture,
                NetworkConstants.CCPIconsFromImageServer, "type", typeId, (int)EveImageSize.x32);

            return useFallbackUri
                ? ImageService.GetImageServerBaseUri(path)
                : ImageService.GetImageServerCdnUri(path);
        }

        #endregion


        #region Helper Methods

        /// <summary>
        /// Sets the control mouse events.
        /// </summary>
        /// <param name="controls">The controls.</param>
        private void SetControlMouseEvents(IEnumerable controls)
        {
            // Give focus to parent panel for mouse wheel scrolling
            foreach (Control control in controls)
            {
                control.MouseClick += control_MouseClick;

                if (control.Controls.Count > 0)
                    SetControlMouseEvents(control.Controls);
            }
        }

        #endregion


        #region Local Events

        /// <summary>
        /// Handles the MouseEnter event of the control control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void control_MouseClick(object sender, MouseEventArgs e)
        {
            Parent.Focus();
        }

        /// <summary>
        /// Handles the MouseDown event of the pictureBox control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="MouseEventArgs" /> instance containing the event data.</param>
        private void pictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right)
                return;

            PictureBox pictureBox = sender as PictureBox;

            if (pictureBox == null)
                return;

            // Right click reset the cursor
            pictureBox.Cursor = Cursors.Default;

            int typeId =
                pictureBox == ShipPictureBox
                    ? m_attacker.ShipTypeID
                    : pictureBox == WeaponPictureBox
                        ? m_attacker.WeaponTypeID
                        : Item.UnknownItem.ID;

            // Set the selected item
            m_selectedItem = StaticItems.GetItemByID(typeId);

            // Display the context menu
            contextMenuStrip.Show(pictureBox, e.Location);
        }

        /// <summary>
        /// Handles the MouseMove event of the pictureBox control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="MouseEventArgs"/> instance containing the event data.</param>
        private void pictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            PictureBox pictureBox = sender as PictureBox;
            m_selectedItem = null;

            if (pictureBox == null)
                return;

            if (((pictureBox == ShipPictureBox) && (m_attacker.ShipTypeID == 0)) ||
                ((pictureBox == WeaponPictureBox) && (m_attacker.WeaponTypeID == 0)))
            {
                pictureBox.Cursor = Cursors.Default;
                return;
            }

            pictureBox.Cursor = CustomCursors.ContextMenu;
        }

        /// <summary>
        /// Handles the Opening event of the contextMenuStrip control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.ComponentModel.CancelEventArgs"/> instance containing the event data.</param>
        private void contextMenuStrip_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            PictureBox pictureBox = contextMenuStrip.SourceControl as PictureBox;

            e.Cancel = pictureBox == null ||
                       ((pictureBox == ShipPictureBox) && (m_attacker.ShipTypeID == 0)) ||
                       ((pictureBox == WeaponPictureBox) && (m_attacker.WeaponTypeID == 0));

            if (e.Cancel)
                return;

            string text = m_selectedItem is Ship ? "Ship" : m_selectedItem != null ? "Item" : String.Empty;

            if (!String.IsNullOrWhiteSpace(text))
                showInBrowserMenuItem.Text = $"Show In {text} Browser...";

            showInBrowserMenuItem.Visible = !String.IsNullOrWhiteSpace(text);
        }

        /// <summary>
        /// Handles the Click event of the showInBrowserMenuItem control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void showInBrowserMenuItem_Click(object sender, EventArgs e)
        {
            if (m_selectedItem == null)
                return;

            PlanWindow planWindow = PlanWindow.ShowPlanWindow(KillLog.Character);

            if (m_selectedItem is Ship)
                planWindow.ShowShipInBrowser(m_selectedItem);
            else
                planWindow.ShowItemInBrowser(m_selectedItem);
        }

        #endregion
    }
}
