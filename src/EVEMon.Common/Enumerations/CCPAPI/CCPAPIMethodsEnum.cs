using System;

namespace EVEMon.Common.Enumerations.CCPAPI
{
    /// <summary>
    /// Enumerations to support APIMethodsEnum.
    /// </summary>
    [Flags]
    public enum CCPAPIMethodsEnum : ulong
    {
        None = 0,

        /// <summary>
        /// The basic character features of ESIAPICharacterMethods.
        /// </summary>
        BasicCharacterFeatures = ESIAPICharacterMethods.AccountBalance |
            ESIAPICharacterMethods.Attributes | ESIAPICharacterMethods.CharacterSheet |
            ESIAPICharacterMethods.Clones | ESIAPICharacterMethods.EmploymentHistory |
            ESIAPICharacterMethods.Location | ESIAPICharacterMethods.Implants |
            ESIAPICharacterMethods.Ship | ESIAPICharacterMethods.SkillQueue |
            ESIAPICharacterMethods.Skills,

        /// <summary>
        /// The character asset features of ESIAPICharacterMethods
        /// </summary>
        AssetCharacterFeatures = ESIAPICharacterMethods.AssetList,

        /// <summary>
        /// The character contract & market features of ESIAPICharacterMethods
        /// </summary>
        ContractMarketCharacterFeatures = ESIAPICharacterMethods.Contracts | ESIAPICharacterMethods.MarketOrders,

        /// <summary>
        /// The advanced character features of ESIAPICharacterMethods.
        /// </summary>
        AdvancedCharacterFeatures = ESIAPICharacterMethods.AssetList |
            ESIAPICharacterMethods.CalendarEventAttendees | ESIAPICharacterMethods.ContactList |
            ESIAPICharacterMethods.Contracts | ESIAPICharacterMethods.ContractBids |
            ESIAPICharacterMethods.ContractItems | ESIAPICharacterMethods.FactionalWarfareStats |
            ESIAPICharacterMethods.IndustryJobs | ESIAPICharacterMethods.JumpFatigue |
            ESIAPICharacterMethods.KillLog | ESIAPICharacterMethods.MailMessages |
            ESIAPICharacterMethods.MailBodies | ESIAPICharacterMethods.MailingLists |
            ESIAPICharacterMethods.MarketOrders | ESIAPICharacterMethods.Medals |
            ESIAPICharacterMethods.Notifications | ESIAPICharacterMethods.PlanetaryColonies |
            ESIAPICharacterMethods.PlanetaryLayout | ESIAPICharacterMethods.ResearchPoints |
            ESIAPICharacterMethods.Standings | ESIAPICharacterMethods.UpcomingCalendarEvents |
            ESIAPICharacterMethods.UpcomingCalendarEventDetails |
            ESIAPICharacterMethods.WalletJournal | ESIAPICharacterMethods.WalletTransactions,

        /// <summary>
        /// The advanced corporation features of ESIAPICorporationMethods.
        /// </summary>
        AdvancedCorporationFeatures = ESIAPICorporationMethods.CorporationContracts |
            ESIAPICorporationMethods.CorporationMedals |
            ESIAPICorporationMethods.CorporationMarketOrders |
            ESIAPICorporationMethods.CorporationIndustryJobs,

        /// <summary>
        /// All character features of ESIAPICharacterMethods
        /// </summary>
        AllCharacterFeatures = BasicCharacterFeatures | AdvancedCharacterFeatures,
    }
}
