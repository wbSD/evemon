﻿using System;
using System.Windows.Forms;
using EVEMon.Common.CustomEventArgs;
using EVEMon.Common.Extensions;

namespace EVEMon.Common.Controls
{
    public partial class ApiErrorTroubleshooter : EVEMonControl
    {
        /// <summary>
        /// Occurs when a resolution has been completed.
        /// </summary>
        public event EventHandler<ApiErrorTroubleshooterEventArgs> ErrorResolved;

        /// <summary>
        /// Initializes a new instance of the <see cref="ApiErrorTroubleshooter"/> class.
        /// </summary>
        protected ApiErrorTroubleshooter()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Called when the error is unresolved.
        /// </summary>
        protected void OnErrorUnresolved()
        {
            ErrorResolved?.ThreadSafeInvoke(null, new ApiErrorTroubleshooterEventArgs());
        }

        /// <summary>
        /// Called when the error is resolved.
        /// </summary>
        /// <param name="action">The action.</param>
        protected void OnErrorResolved(ResolutionAction action)
        {
            ErrorResolved?.ThreadSafeInvoke(null, new ApiErrorTroubleshooterEventArgs(action));
        }
    }
}