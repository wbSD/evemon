using System;
using System.ComponentModel;
using EVEMon.Common.Attributes;
using EVEMon.Common.Enumerations.UISettings;

namespace EVEMon.Common.Enumerations.CCPAPI
{
    /// <summary>
    /// Enumeration of the corporation related API methods. Each method has an access mask.
    /// Each method should have an entry in APIMethodsEnum and
    /// an equivalent string entry in NetworkConstants indicating the default path of the method.
    /// </summary>
    [Flags]
    public enum ESIAPICorporationMethods : ulong
    {
        None = 0,

        /// <summary>
        /// The corporation issued market orders.
        /// </summary>
        [Header("Market Orders")]
        [Description("The corporation market orders of a character.")]
        [ESIMethod("/v2/corporations/{0:D}/orders/", Scope = "esi-markets.read_corporation_orders.v1")]
        [Update(UpdatePeriod.Hours1, UpdatePeriod.Hours1)]
        CorporationMarketOrders = 1 << 1,

        /// <summary>
        /// The corporation issued contracts.
        /// </summary>
        [Header("Contracts")]
        [Description("The corporation contracts of a character.")]
        [ESIMethod("/v1/corporations/{0:D}/contracts/", Scope = "esi-contracts.read_corporation_contracts.v1")]
        [Update(UpdatePeriod.Minutes15, UpdatePeriod.Minutes15)]
        CorporationContracts = 1 << 2,

        /// <summary>
        /// The corporation issued industry jobs.
        /// </summary>
        [Header("Industry Jobs")]
        [Description("The corporation industry jobs of a character.")]
        [ESIMethod("/v1/corporations/{0:D}/industry/jobs/", Scope = "esi-industry.read_corporation_jobs.v1")]
        [Update(UpdatePeriod.Minutes15, UpdatePeriod.Minutes15)]
        CorporationIndustryJobs = 1 << 3,

        /// <summary>
        /// A corporation's wallet balances.
        /// </summary>
        [ESIMethod("/v1/corporations/{0:D}/wallets/", Scope = "esi-wallet.read_corporation_wallets.v1")]
        CorporationAccountBalance = 1 << 4,

        /// <summary>
        /// Asset list of a corporation.
        /// </summary>
        [ESIMethod("/v3/corporations/{0:D}/assets/", Scope = "esi-assets.read_corporation_assets.v1")]
        CorporationAssetList = 1 << 5,

        /// <summary>
        /// A list of corporation contacts.
        /// </summary>
        [ESIMethod("/v2/corporations/{0:D}/contacts/", Scope = "esi-corporations.read_contacts.v1")]
        CorporationContactList = 1 << 6,

        /// <summary>
        /// The log of the corporation's containers.
        /// </summary>
        [ESIMethod("/v2/corporations/{0:D}/containers/logs/", Scope = "esi-corporations.read_container_logs.v1")]
        CorporationContainerLog = 1 << 7,

        /// <summary>
        /// Public corporation info.
        /// </summary>
        [ESIMethod("/v4/corporations/{0:D}/")]
        CorporationSheet = 1 << 8,

        /// <summary>
        /// Factional warfare statistics for a corporation.
        /// </summary>
        [ESIMethod("/v1/corporations/{0:D}/fw/stats/", Scope = "esi-corporations.read_fw_stats.v1")]
        CorporationFactionalWarfareStats = 1 << 9,

        /// <summary>
        /// The Kill log for a corporation (Kill mails).
        /// </summary>
        [ESIMethod("/v1/corporations/{0:D}/killmails/recent/", Scope = "esi-killmails.read_corporation_killmails.v1")]
        CorporationKillLog = 1 << 10,

        /// <summary>
        /// List of all medals created by the corporation.
        /// </summary>
        [Header("Medals")]
        [Description("The medals created by a corporation.")]
        [ESIMethod("/v1/corporations/{0:D}/medals/", Scope = "esi-corporations.read_medals.v1")]
        [Update(UpdatePeriod.Hours6, UpdatePeriod.Hours6)]
        CorporationMedals = 1 << 11,

        /// <summary>
        /// List of medals awarded to corporation members.
        /// </summary>
        [ESIMethod("/v1/corporations/{0:D}/medals/issued/", Scope = "esi-corporations.read_medals.v1")]
        CorporationMemberMedals = 1 << 12,

        /// <summary>
        /// Member roles and titles.
        /// </summary>
        CorporationMemberSecurity = 1 << 13,

        /// <summary>
        /// Member role and title change log.
        /// </summary>
        CorporationMemberSecurityLog = 1 << 14,

        /// <summary>
        /// Corporation member information.
        /// </summary>
        [ESIMethod("/v1/corporations/{0:D}/membertracking/", Scope = "esi-corporations.track_members.v1")]
        CorporationMemberTracking = 1 << 15,

        /// <summary>
        /// List of all outposts controlled by the corporation.
        /// </summary>
        [ESIMethod("/v1/corporations/{0:D}/outposts/", Scope = "esi-corporations.read_outposts.v1")]
        CorporationOutpostList = 1 << 16,

        /// <summary>
        /// List of all service settings of corporate outposts.
        /// </summary>
        [ESIMethod("/v1/corporations/{0:D}/outposts/{1:D}/", Scope = "esi-corporations.read_outposts.v1")]
        CorporationOutpostServiceDetail = 1 << 17,

        /// <summary>
        /// Shareholders of the corporation.
        /// </summary>
        [ESIMethod("/v1/corporations/{0:D}/shareholders/", Scope = "esi-wallet.read_corporation_wallets.v1")]
        CorporationShareholders = 1 << 18,

        /// <summary>
        /// NPC Standings towards corporation.
        /// </summary>
        [ESIMethod("/v1/corporations/{0:D}/standings/", Scope = "esi-corporations.read_standings.v1")]
        CorporationStandings = 1 << 19,

        /// <summary>
        /// List of all settings of corporate starbases.
        /// </summary>
        [ESIMethod("/v1/corporations/{0:D}/starbases/{1:D}/", Scope = "esi-corporations.read_starbases.v1")]
        CorporationStarbaseDetails = 1 << 20,

        /// <summary>
        /// List of all corporate starbases.
        /// </summary>
        [ESIMethod("/v1/corporations/{0:D}/starbases/", Scope = "esi-corporations.read_starbases.v1")]
        CorporationStarbaseList = 1 << 21,

        /// <summary>
        /// Titles of corporation and the roles they grant.
        /// </summary>
        [ESIMethod("/v1/corporations/{0:D}/titles/", Scope = "esi-corporations.read_titles.v1")]
        CorporationTitles = 1 << 22,

        /// <summary>
        /// Wallet journal for all corporate accounts.
        /// </summary>
        [ESIMethod("/v3/corporations/{0:D}/wallets/{1:D}/journal/", Scope = "esi-wallet.read_corporation_wallets.v1")]
        CorporationWalletJournal = 1 << 23,

        /// <summary>
        /// Market transactions of all corporate accounts.
        /// </summary>
        [ESIMethod("/v1/corporations/{0:D}/wallets/{1:D}/transactions/", Scope = "esi-wallet.read_corporation_wallets.v1")]
        CorporationWalletTransactions = 1 << 24,

        /// <summary>
        /// List of all corporate bookmarks.
        /// </summary>
        [ESIMethod("/v2/corporations/{0:D}/blueprints/", Scope = "esi-bookmarks.read_corporation_bookmarks.v1")]
        CorporationBookmarks = 1 << 25,

        /// <summary>
        /// List of corporate contract bids.
        /// </summary>
        [ESIMethod("/v1/corporations/{0:D}/contracts/{1:D}/bids/", Scope = "esi-contracts.read_corporation_contracts.v1")]
        CorporationContractBids = 1 << 26,

        /// <summary>
        /// List of corporate contract items.
        /// </summary>
        [ESIMethod("/v1/corporations/{0:D}/contracts/{1:D}/items/", Scope = "esi-contracts.read_corporation_contracts.v1")]
        CorporationContractItems = 1 << 27
    }
}
