using System.Drawing;
using System.Windows.Forms;
using EVEMon.Common;
using EVEMon.Common.Controls;
using EVEMon.Common.Models;
using EVEMon.Common.Notifications;

namespace EVEMon.CharacterMonitoring
{
    /// <summary>
    /// Implements the content of each of the character tabs.
    /// </summary>
    internal sealed partial class CharacterMonitor : EVEMonControl
    {
        #region Constructor

        /// <summary>
        /// Design-time constructor.
        /// </summary>
        private CharacterMonitor()
        {
            InitializeComponent();
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            UpdateStyles();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CharacterMonitor"/> class.
        /// </summary>
        /// <param name="character">The character.</param>
        public CharacterMonitor(Character character)
            : this()
        {
            Header.SetCharacter(character);
            Body.SetCharacter(character);
            Footer.SetCharacter(character);
        }

        #endregion


        /// <summary>
        /// Clears the notifications.
        /// </summary>
        internal void ClearNotifications()
        {
            Body.ClearNotifications();
        }


        #region Screenshot Method

        /// <summary>
        /// Takes a screeenshot of this character's monitor and returns it (used for PNG exportation)
        /// </summary>
        /// <returns>Screenshot of a character.</returns>
        internal Bitmap GetCharacterScreenshot() => Body.GetCharacterScreenshot();

        #endregion


        #region Testing Function

        /// <summary>
        /// Tests character's notification display in the Character Monitor.
        /// </summary>
        internal static void TestCharacterNotification(Character character)
        {
            NotificationEventArgs notification = new NotificationEventArgs(character, NotificationCategory.TestNofitication)
                                                     {
                                                         Priority = NotificationPriority.Warning,
                                                         Behaviour = NotificationBehaviour.Overwrite,
                                                         Description = "Test Character Notification."
                                                     };
            EveMonClient.Notifications.Notify(notification);
        }

        #endregion
    }
}
