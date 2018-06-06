using EVEMon.Common.Collections;
using EVEMon.Common.Controls;
using EVEMon.Common.Enumerations.CCPAPI;
using EVEMon.Common.Extensions;
using EVEMon.Common.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EVEMon.ApiCredentialsManagement
{
    public partial class ESIScopesWindow : EVEMonForm
    {
        #region Fields
        private readonly List<ESIAPICharacterMethods> m_character_methods = new List<ESIAPICharacterMethods>();
        private readonly List<ESIAPICorporationMethods> m_corporation_methods = new List<ESIAPICorporationMethods>();

        private readonly Dictionary<ESIAPICharacterMethods, CheckBox> m_character_method_checkboxes = new Dictionary<ESIAPICharacterMethods, CheckBox>();
        private readonly Dictionary<ESIAPICorporationMethods, CheckBox> m_corporation_method_checkboxes = new Dictionary<ESIAPICorporationMethods, CheckBox>();

        private readonly Dictionary<string, CheckBox> m_character_scope_checkboxes = new Dictionary<string, CheckBox>();
        private readonly Dictionary<string, CheckBox> m_corporation_scope_checkboxes = new Dictionary<string, CheckBox>();

        private readonly HashSet<string> m_selected_scopes = new HashSet<string>();

        private readonly Dictionary<string, List<ESIAPICharacterMethods>> m_scope_to_character_methods = new Dictionary<string, List<ESIAPICharacterMethods>>();
        private readonly Dictionary<string, List<ESIAPICorporationMethods>> m_scope_to_corporation_methods = new Dictionary<string, List<ESIAPICorporationMethods>>();

        private readonly ToolTip m_tooltip;

        private readonly ESIKey m_esiKey;
        #endregion

        public delegate void ESIScopesDelegate(string scopes);

        public event ESIScopesDelegate ESIScopesEvent;

        /// <summary>
        /// Constructor.
        /// </summary>
        private ESIScopesWindow()
        {
            InitializeComponent();

            m_tooltip = new ToolTip
            {
                AutoPopDelay = 5000,
                InitialDelay = 1000,
                ReshowDelay = 500
            };

            LoadESIMethods();
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="key">ESI Key to copy scope setup from</param>
        public ESIScopesWindow(ESIKey key) : this()
        {
            m_esiKey = key;
        }

        /// <summary>
        /// Load all of the ESI methods that require a scope
        /// </summary>
        private void LoadESIMethods()
        {
            // Character
            foreach (var m in EnumExtensions.GetValues<ESIAPICharacterMethods>().Where(x => x.RequiresESIMethodScope()))
            {
#if RELEASE
                if ((m & (ESIAPICharacterMethods)CCPAPIMethodsEnum.AllCharacterFeatures) != m)
                    continue;
#endif
                var scope = m.GetESIMethodScope();

                if (m_scope_to_character_methods.ContainsKey(scope))
                    m_scope_to_character_methods[scope].Add(m);
                else
                    m_scope_to_character_methods.Add(scope, new List<ESIAPICharacterMethods>() { m });

                m_character_methods.Add(m);
            }

            // Corporation
            foreach (var m in EnumExtensions.GetValues<ESIAPICorporationMethods>().Where(x => x.RequiresESIMethodScope()))
            {
#if RELEASE
                if ((m & (ESIAPICorporationMethods)CCPAPIMethodsEnum.AdvancedCorporationFeatures) != m)
                    continue;
#endif
                var scope = m.GetESIMethodScope();

                if (m_scope_to_corporation_methods.ContainsKey(scope))
                    m_scope_to_corporation_methods[scope].Add(m);
                else
                    m_scope_to_corporation_methods.Add(scope, new List<ESIAPICorporationMethods>() { m });

                m_corporation_methods.Add(m);
            }
        }

        /// <summary>
        /// On loading, intialize the controls and subscribe events.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            if (DesignMode)
                return;

            ConfigureBasicCheckBoxes();
            CreateMethodCheckBoxes();
            CreateScopeCheckBoxes();

            CheckCheckBoxes();
        }

        #region Create/configure checkboxes
        private void ConfigureBasicCheckBoxes()
        {
            // Character
            var coreFeatures = ESIAPICharacterMethods.None;
            var assetFeatures = ESIAPICharacterMethods.None;
            var contractMarketFeatures = ESIAPICharacterMethods.None;
            var basicCharacterFeatures = (ESIAPICharacterMethods)CCPAPIMethodsEnum.BasicCharacterFeatures;
            var assetCharacterFeatures = (ESIAPICharacterMethods)CCPAPIMethodsEnum.AssetCharacterFeatures;
            var contractMarketCharacterFeatures = (ESIAPICharacterMethods)CCPAPIMethodsEnum.ContractMarketCharacterFeatures;
            var coreFeaturesDescription = new List<string>();
            var assetFeaturesDescription = new List<string>();
            var contractMarketFeaturesDescription = new List<string>();

            // Get flags for the core/asset/contract+market features that require scopes
            foreach (var m in m_character_methods)
            {
                if ((m & basicCharacterFeatures) == m)
                {
                    coreFeatures = coreFeatures | m;
                    coreFeaturesDescription.Add((m.HasHeader() ? m.GetHeader() : m.ToString()));
                }
                if ((m & assetCharacterFeatures) == m)
                {
                    assetFeatures = assetFeatures | m;
                    assetFeaturesDescription.Add((m.HasHeader() ? m.GetHeader() : m.ToString()));
                }
                if ((m & contractMarketCharacterFeatures) == m)
                {
                    contractMarketFeatures = contractMarketFeatures | m;
                    contractMarketFeaturesDescription.Add((m.HasHeader() ? m.GetHeader() : m.ToString()));
                }
            }

            // Set flags and hook up event
            coreFeaturesCheckBox.Tag = coreFeatures;
            coreFeaturesCheckBox.CheckedChanged += SimpleCheckBox_CheckedChanged;
            coreFeaturesLabel.Text = string.Join(", ", coreFeaturesDescription);

            assetsCheckBox.Tag = assetFeatures;
            assetsCheckBox.CheckedChanged += SimpleCheckBox_CheckedChanged;
            assetsLabel.Text = string.Join(", ", assetFeaturesDescription);

            contractMarketCheckBox.Tag = contractMarketFeatures;
            contractMarketCheckBox.CheckedChanged += SimpleCheckBox_CheckedChanged;
            contractMarketLabel.Text = string.Join(", ", contractMarketFeaturesDescription);

            // Corporation
            var corporationFeatures = ESIAPICorporationMethods.None;
            var advancedCorpFeatures = (ESIAPICorporationMethods)CCPAPIMethodsEnum.AdvancedCorporationFeatures;
            var advancedCorpFeaturesDescription = new List<string>();

            // Get flags for the corporation features that requrie scopes
            foreach (var m in m_corporation_methods)
                if ((m & advancedCorpFeatures) == m)
                {
                    corporationFeatures = corporationFeatures | m;
                    advancedCorpFeaturesDescription.Add((m.HasHeader() ? m.GetHeader() : m.ToString()));
                }

            // Set flags and hook up event
            corporationCheckBox.Tag = corporationFeatures;
            corporationCheckBox.CheckedChanged += SimpleCheckBox_CheckedChanged;
            corporationLabel.Text = string.Join(", ", advancedCorpFeaturesDescription);
        }

        /// <summary>
        /// Creates checkboxes in the Advanced tab for all the ESIAPICharacterMethods and ESIAPICorporationMethods that require scopes
        /// </summary>
        private void CreateMethodCheckBoxes()
        {
            // Character
            foreach (var method in m_character_methods
                .OrderByDescending(x => x.HasHeader())
                .ThenBy(x => x.HasHeader() ? x.GetHeader() : x.ToString()))
            {
                var cb = GenerateMethodCheckBox(method);
                characterMethodsFlowLayoutPanel.Controls.Add(cb);
                m_character_method_checkboxes.Add(method, cb);
            }

            // Corporation
            foreach (var method in m_corporation_methods
                .OrderByDescending(x => x.HasHeader())
                .ThenBy(x => x.HasHeader() ? x.GetHeader() : x.ToString()))
            {
                var cb = GenerateMethodCheckBox(method);
                corporationMethodsFlowLayoutPanel.Controls.Add(cb);
                m_corporation_method_checkboxes.Add(method, cb);
            }
        }

        /// <summary>
        /// Creates checkboxes in the ESI Scopes tab for all the scopes required by either ESIAPICharacterMethods or ESIAPICorporationMethods
        /// </summary>
        private void CreateScopeCheckBoxes()
        {
            // Character
            foreach(var scope in m_character_methods
                .Select(x => x.GetESIMethodScope())
                .Distinct()
                .OrderBy(x => x))
            {
                var cb = GenerateScopeCheckBox(scope);
                characterScopesFlowLayoutPanel.Controls.Add(cb);
                m_character_scope_checkboxes.Add(scope, cb);
            }

            // Corporation
            foreach (var scope in m_corporation_methods
                .Select(x => x.GetESIMethodScope())
                .Distinct()
                .OrderBy(x => x))
            {
                var cb = GenerateScopeCheckBox(scope);
                corporationScopesFlowLayoutPanel.Controls.Add(cb);
                m_corporation_scope_checkboxes.Add(scope, cb);
            }
        }

        /// <summary>
        /// Check all the checkboxes that match the ESI key, or default to core features
        /// </summary>
        private void CheckCheckBoxes()
        {
            if (m_esiKey == null)
            {
                // Default to just core features
                coreFeaturesCheckBox.Checked = true;
            }
            else
            {
                // Check all character methods where flags match access mask
                foreach (var m in m_character_methods)
                    if (((ulong)m & m_esiKey.CharacterAccessMask) == (ulong)m)
                        CharacterMethodChecked(m, true);

                // Check all corporation methods where flags match access mask
                foreach (var m in m_corporation_methods)
                    if (((ulong)m & m_esiKey.CorporationAccessMask) == (ulong)m)
                        CorporationMethodChecked(m, true);
            }
        }

        /// <summary>
        /// Creates a newline separated string of the enum values, using its header attribute where applicable
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="methods"></param>
        /// <returns></returns>
        private string MethodsToString<T>(List<T> methods) where T : struct, IConvertible
        {
            if (!typeof(T).IsEnum) throw new ArgumentException("T must be an enumerated type");

            string text = string.Empty;

            foreach(var m in methods)
            {
                text += Environment.NewLine;

                var e = m as Enum;
                text += e.HasHeader() ? e.GetHeader() : e.ToString();
            }

            return text;
        }

        /// <summary>
        /// Generates a checkbox with tooltip for an ESI scopes
        /// </summary>
        /// <param name="scope"></param>
        /// <returns></returns>
        private CheckBox GenerateScopeCheckBox(string scope)
        {
            string tooltip = string.Empty;

            if (m_scope_to_character_methods.ContainsKey(scope))
                tooltip += "Character Methods:" + MethodsToString(m_scope_to_character_methods[scope]);

            if (m_scope_to_corporation_methods.ContainsKey(scope))
                tooltip += "Corporation Methods:" + MethodsToString(m_scope_to_corporation_methods[scope]);

            return GenerateCheckBox(scope, scope, tooltip);
        }

        /// <summary>
        /// Generates a checkbox with tooltip for an ESI method
        /// </summary>
        /// <param name="method"></param>
        /// <returns></returns>
        private CheckBox GenerateMethodCheckBox(Enum method)
        {
            string text = method.ToString();
            string tooltip = string.Empty;

            if (method.HasHeader())
            {
                text = method.GetHeader();
                tooltip = method.GetDescription() + Environment.NewLine;
            }

            tooltip += "Requires scope: " + method.GetESIMethodScope();

            return GenerateCheckBox(text, method, tooltip);
        }

        /// <summary>
        /// Generates a checkbox and hooks up its event
        /// </summary>
        /// <param name="text"></param>
        /// <param name="tag"></param>
        /// <param name="tooltip"></param>
        /// <returns></returns>
        private CheckBox GenerateCheckBox(string text, object tag, string tooltip)
        {
            var cb = new CheckBox
            {
                Text = text,
                Tag = tag,
                MinimumSize = new Size(250, 20)
            };

            cb.CheckedChanged += CheckBox_CheckedChanged;

            if (!string.IsNullOrEmpty(tooltip))
                m_tooltip.SetToolTip(cb, tooltip);

            return cb;
        }
        #endregion

        #region Handle check/uncheck of checkboxes
        /// <summary>
        /// Event handler for checkboxes on Simple tab
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SimpleCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (sender is CheckBox cb)
                if (cb.Tag is ESIAPICharacterMethods method)
                    CheckCharacterMethods(method, cb.CheckState);
                else if (cb.Tag is ESIAPICorporationMethods corpmethod)
                    CheckCorporationMethods(corpmethod, cb.CheckState);
        }

        /// <summary>
        /// Check all character methods that match flags
        /// </summary>
        /// <param name="flags"></param>
        /// <param name="checkedState"></param>
        private void CheckCharacterMethods(ESIAPICharacterMethods flags, CheckState checkedState)
        {
            bool isChecked = checkedState == CheckState.Checked;

            if (isChecked || checkedState == CheckState.Unchecked)
                foreach (var m in m_character_methods)
                {
                    // Check character method checkboxes where flag matches and the scope isn't already selected
                    if ((m & flags) == m && m_selected_scopes.Contains(m.GetESIMethodScope()) != isChecked)
                        CharacterMethodChecked(m, isChecked);
                }
        }

        /// <summary>
        /// Check all corporation methods that match flags
        /// </summary>
        /// <param name="flags"></param>
        /// <param name="checkedState"></param>
        private void CheckCorporationMethods(ESIAPICorporationMethods flags, CheckState checkedState)
        {
            bool isChecked = checkedState == CheckState.Checked;

            if (isChecked || checkedState == CheckState.Unchecked)
                foreach (var m in m_corporation_methods)
                {
                    // Check corporation method checkboxes where flag matches and the scope isn't already selected
                    if ((m & flags) == m && m_selected_scopes.Contains(m.GetESIMethodScope()) != isChecked)
                        CorporationMethodChecked(m, isChecked);
                }
        }

        /// <summary>
        /// Set the correct ThreeState for the character feature checkboxes in the Simple tab
        /// </summary>
        private void SetSimpleCharacterCheckStates()
        {
            SetSimpleCharacterCheckState(coreFeaturesCheckBox);
            SetSimpleCharacterCheckState(assetsCheckBox);
            SetSimpleCharacterCheckState(contractMarketCheckBox);
        }

        /// <summary>
        /// Set ThreeState for a character feature checkbox
        /// </summary>
        /// <param name="cb"></param>
        private void SetSimpleCharacterCheckState(CheckBox cb)
        {
            // Figure out what flags are currently set
            ESIAPICharacterMethods selected = ESIAPICharacterMethods.None;
            foreach(var m in m_character_methods)
            {
                if (m_selected_scopes.Contains(m.GetESIMethodScope()))
                    selected = selected | m;
            }

            var compare = (ESIAPICharacterMethods)cb.Tag;

            // Set checked state based on full, none or partial match
            if ((selected & compare) == compare)
                cb.CheckState = CheckState.Checked;
            else if ((selected & compare) == ESIAPICharacterMethods.None)
                cb.CheckState = CheckState.Unchecked;
            else
                cb.CheckState = CheckState.Indeterminate;
        }

        /// <summary>
        /// Set the CheckedState of the the corporation features checkbox
        /// </summary>
        /// <param name="cb"></param>
        private void SetSimpleCorporationCheckState()
        {
            // Figure out what flags are currently set         
            ESIAPICorporationMethods selected = ESIAPICorporationMethods.None;
            foreach (var m in m_corporation_methods)
            {
                if (m_selected_scopes.Contains(m.GetESIMethodScope()))
                    selected = selected | m;
            }

            var compare = (ESIAPICorporationMethods)corporationCheckBox.Tag;

            // Set checked state based on full, none or partial match
            if ((selected & compare) == compare)
                corporationCheckBox.CheckState = CheckState.Checked;
            else if ((selected & compare) == ESIAPICorporationMethods.None)
                corporationCheckBox.CheckState = CheckState.Unchecked;
            else
                corporationCheckBox.CheckState = CheckState.Indeterminate;
        }

        /// <summary>
        /// Event handler for all the generated checkboxes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (sender is CheckBox cb)
            {
                if (cb.Tag is string scope)
                    ScopeChecked(scope, cb.Checked);
                else if (cb.Tag is ESIAPICharacterMethods method_char)
                    CharacterMethodChecked(method_char, cb.Checked);
                else if (cb.Tag is ESIAPICorporationMethods method_corp)
                    CorporationMethodChecked(method_corp, cb.Checked);
            }
        }

        /// <summary>
        /// Propagate changes to Scope checkboxes to the other checkboxes
        /// </summary>
        /// <param name="scope"></param>
        /// <param name="isChecked"></param>
        private void ScopeChecked(string scope, bool isChecked)
        {
            AddOrRemoveScope(scope, isChecked);

            // Update all related character method checkboxes
            if (m_scope_to_character_methods.ContainsKey(scope))
                foreach (var method in m_scope_to_character_methods[scope])
                    m_character_method_checkboxes[method].Checked = isChecked;

            // Update all related corporation method checkboxes
            if (m_scope_to_corporation_methods.ContainsKey(scope))
                foreach (var method in m_scope_to_corporation_methods[scope])
                    m_corporation_method_checkboxes[method].Checked = isChecked;
        }

        /// <summary>
        /// Propagate changes to Character Method checkboxes to the other checkboxes
        /// </summary>
        /// <param name="method"></param>
        /// <param name="isChecked"></param>
        private void CharacterMethodChecked(ESIAPICharacterMethods method, bool isChecked)
        {
            var methodscope = method.GetESIMethodScope();

            AddOrRemoveScope(methodscope, isChecked);

            // Update the related scope checkbox
            m_character_scope_checkboxes[methodscope].Checked = isChecked;

            // Update simple tab checkboxes
            SetSimpleCharacterCheckStates();
        }

        /// <summary>
        /// Propagate changes to Corporation Method checkboxes to the other checkboxes
        /// </summary>
        /// <param name="method"></param>
        /// <param name="isChecked"></param>
        private void CorporationMethodChecked(ESIAPICorporationMethods method, bool isChecked)
        {
            var methodscope = method.GetESIMethodScope();

            AddOrRemoveScope(methodscope, isChecked);;

            // Update the related scope checkbox
            m_corporation_scope_checkboxes[methodscope].Checked = isChecked;

            // Update simple tab checkboxes
            SetSimpleCorporationCheckState();
        }

        /// <summary>
        /// Adds or removes a scope from the internal list of selected scopes
        /// </summary>
        /// <param name="scope"></param>
        /// <param name="add"></param>
        private void AddOrRemoveScope(string scope, bool add)
        {
            if (add)
                m_selected_scopes.Add(scope);
            else
                m_selected_scopes.Remove(scope);
        }
        #endregion

        /// <summary>
        /// Event handler for closing the window and saving selection
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void saveButton_Click(object sender, EventArgs e)
        {
            var scopes = string.Join(" ", m_selected_scopes);

            if (string.IsNullOrEmpty(scopes))
            {
                MessageBox.Show("Please check at least one checkbox", "No scopes selected", MessageBoxButtons.OK);
            }
            else
            {
                ESIScopesEvent?.Invoke(scopes);
                Close();
            }
        }

        /// <summary>
        /// Event handler for closing the window without saving
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
