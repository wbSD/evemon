using System;
using System.ComponentModel;
using EVEMon.Common.Attributes;
using EVEMon.Common.Enumerations.UISettings;

namespace EVEMon.Common.Enumerations.CCPAPI
{
    /// <summary>
    /// Enumeration of the character related API methods. Each method has an access mask.
    /// Each method should have an entry in APIMethodsEnum and an equivalent string entry 
    /// in NetworkConstants indicating the default path of the method.
    /// </summary>
    [Flags]
    public enum ESIAPICharacterMethods : ulong
    {
        None = 0,

        /// <summary>
        /// A character's wallet balance.
        /// </summary>
        [Header("Wallet Balance")]
        [Description("The wallet balance of a character.")]
        [Parent(CharacterSheet)]
        [Update(UpdatePeriod.Minutes30, UpdatePeriod.Minutes2)]
        AccountBalance = 1 << 0,

        /// <summary>
        /// The assets of a character.
        /// </summary>
        [Header("Assets")]
        [Description("The assets of a character.")]
        [Update(UpdatePeriod.Hours2, UpdatePeriod.Hours1)]
        AssetList = 1 << 1,

        /// <summary>
        /// The attributes of a character.
        /// </summary>
        [Header("Attributes")]
        [Description("The attributes of a character.")]
        [Update(UpdatePeriod.Hours2, UpdatePeriod.Hours1)]
        Attributes = 1 << 2,

        /// <summary>
        /// Tha attendees to a character's calendar event.
        /// </summary>
        [Header("Calendar Event Attendees")]
        [Description("The attendees and their response status to a calendar event.")]
        [Update(UpdatePeriod.Minutes15, UpdatePeriod.Minutes10)]
        CalendarEventAttendees = 1 << 3,

        /// <summary>
        /// A character sheet with public information.
        /// </summary>
        [Header("Character Sheet")]
        [Description("A character's sheet listing biography, skills, attributes and implants informations.")]
        [Update(UpdatePeriod.Hours1, UpdatePeriod.Hours1)]
        CharacterSheet = 1 << 4,

        /// <summary>
        /// The clones of a character.
        /// </summary>
        [Header("Jump Clones")]
        [Description("The jump clones of a character.")]
        [Parent(CharacterSheet)]
        [Update(UpdatePeriod.Hours1, UpdatePeriod.Minutes2)]
        Clones = 1 << 5,

        /// <summary>
        /// The contact list of a character.
        /// </summary>
        [Header("Contacts")]
        [Description("The contacts of a character.")]
        [Update(UpdatePeriod.Minutes15, UpdatePeriod.Minutes5)]
        ContactList = 1 << 6,

        /// <summary>
        /// Contact notifications for a character.
        /// </summary>
        [Update(UpdatePeriod.Minutes15, UpdatePeriod.Minutes10)]
        ContactNotifications = 1 << 7,

        /// <summary>
        /// The personal issued contracts of a character.
        /// </summary>
        [Header("Contracts")]
        [Description("The contracts of a character.")]
        [Update(UpdatePeriod.Minutes15, UpdatePeriod.Minutes5)]
        Contracts = 1 << 8,

        /// <summary>
        /// The contract items of a character contract.
        /// </summary>
        [Update(UpdatePeriod.Hours1, UpdatePeriod.Hours1)]
        ContractItems = 1 << 9,

        /// <summary>
        /// The bids list of a character contract.
        /// </summary>
        [Update(UpdatePeriod.Minutes10, UpdatePeriod.Minutes5)]
        ContractBids = 1 << 10,

        /// <summary>
        /// The employment history of a character.
        /// </summary>
        [Parent(CharacterSheet)]
        [Update(UpdatePeriod.Hours2, UpdatePeriod.Hours1)]
        EmploymentHistory = 1 << 11,

        /// <summary>
        /// The factional warfare stats of a character.
        /// </summary>
        [Header("Factional Warfare Stats")]
        [Description("The factional warfare stats of a character.")]
        [Update(UpdatePeriod.Day, UpdatePeriod.Day)]
        FactionalWarfareStats = 1 << 12,

        /// <summary>
        /// The active implants of a character.
        /// </summary>
        [Header("Implants")]
        [Description("The current implants of a character.")]
        [Parent(CharacterSheet)]
        [Update(UpdatePeriod.Minutes30, UpdatePeriod.Minutes5)]
        Implants = 1 << 13,

        /// <summary>
        /// The personal issued industry jobs of a character.
        /// </summary>
        [Header("Industry Jobs")]
        [Description("The industry jobs of a character.")]
        [Update(UpdatePeriod.Minutes15, UpdatePeriod.Minutes5)]
        IndustryJobs = 1 << 14,

        /// <summary>
        /// The jump fatigue of a character.
        /// </summary>
        [Header("Jump Fatigue")]
        [Description("The jump fatigue of a character.")]
        [Update(UpdatePeriod.Minutes30, UpdatePeriod.Minutes5)]
        JumpFatigue = 1 << 15,

        /// <summary>
        /// The Kill log for a character (Kill mails).
        /// </summary>
        [Header("Combat Log")]
        [Description("The combat log of a character.")]
        [Update(UpdatePeriod.Minutes30, UpdatePeriod.Minutes5)]
        KillLog = 1 << 16,

        /// <summary>
        /// Allows the fetching of coordinate and name data for items owned by the character.
        /// </summary>
        [Header("Location")]
        [Description("The current location of a character.")]
        [Parent(CharacterSheet)]
        [Update(UpdatePeriod.Minutes30, UpdatePeriod.Seconds5)]
        Location = 1 << 17,

        /// <summary>
        /// Mail messages for a character.
        /// </summary>
        [Header("EVE Mail Messages")]
        [Description("The EVE mails of a character.")]
        [Update(UpdatePeriod.Minutes15, UpdatePeriod.Seconds30)]
        MailMessages = 1 << 18,

        /// <summary>
        /// The body text of an EVE mail message.
        /// </summary>
        MailBodies = 1 << 19,

        /// <summary>
        /// The character mailing lists. Used to convert mailing list IDs to Names.
        /// </summary>
        [Parent(MailMessages)]
        [Update(UpdatePeriod.Minutes15, UpdatePeriod.Minutes2)]
        MailingLists = 1 << 20,

        /// <summary>
        /// The personal issued market orders of a character.
        /// </summary>
        [Header("Market Orders")]
        [Description("The market orders of a character.")]
        [Update(UpdatePeriod.Hours1, UpdatePeriod.Minutes20)]
        MarketOrders = 1 << 21,

        /// <summary>
        /// The medals of a character.
        /// </summary>
        [Header("Medals")]
        [Description("The medals of a character.")]
        [Update(UpdatePeriod.Hours6, UpdatePeriod.Hours1)]
        Medals = 1 << 22,

        /// <summary>
        /// The EVE notifications of a character.
        /// </summary>
        [Header("EVE Notifications")]
        [Description("The EVE notifications of a character.")]
        [Update(UpdatePeriod.Minutes10, UpdatePeriod.Minutes10)]
        Notifications = 1 << 23,

        /// <summary>
        /// The planetary colony list of a character.
        /// </summary>
        [Header("Planetary Colonies")]
        [Description("The planetary colonies owned by a character.")]
        [Update(UpdatePeriod.Minutes30, UpdatePeriod.Minutes10)]
        PlanetaryColonies = 1 << 24,

        /// <summary>
        /// The planetary colony layout of a character.
        /// </summary>
        PlanetaryLayout = 1 << 25,

        /// <summary>
        /// The research points of a character.
        /// </summary>
        [Header("Research Points")]
        [Description("The research points of a character.")]
        [Update(UpdatePeriod.Hours2, UpdatePeriod.Hours1)]
        ResearchPoints = 1 << 26,

        /// <summary>
        /// The current ship of a character.
        /// </summary>
        [Header("Ship")]
        [Description("The current ship of a character.")]
        [Parent(CharacterSheet)]
        [Update(UpdatePeriod.Minutes30, UpdatePeriod.Seconds5)]
        Ship = 1 << 27,

        /// <summary>
        /// The skill queue of a character.
        /// </summary>
        [Header("Skill Queue")]
        [Description("The skill queue of a character.")]
        [Update(UpdatePeriod.Minutes15, UpdatePeriod.Minutes2)]
        SkillQueue = 1 << 28,

        /// <summary>
        /// The skills of a character.
        /// </summary>
        [Header("Skills")]
        [Description("The skills of a character.")]
        [Parent(CharacterSheet)]
        [Update(UpdatePeriod.Minutes15, UpdatePeriod.Minutes2)]
        Skills = 1 << 29,

        /// <summary>
        /// A character's standings towards NPC's.
        /// </summary>
        [Header("NPC Standings")]
        [Description("The NPC standings of a character.")]
        [Update(UpdatePeriod.Hours2, UpdatePeriod.Hours1)]
        Standings = 1 << 30,

        /// <summary>
        /// The upcoming calendar events for a character.
        /// </summary>
        [Header("Calendar Events")]
        [Description("The upcoming calendar events of a character.")]
        [Update(UpdatePeriod.Minutes5, UpdatePeriod.Seconds5)]
        UpcomingCalendarEvents = (long)1 << 31,

        /// <summary>
        /// The upcoming calendar event details for a character.
        /// </summary>
        [Header("Calendar Event Details")]
        [Description("Details on the upcoming calendar events of a character.")]
        [Update(UpdatePeriod.Minutes5, UpdatePeriod.Seconds5)]
        UpcomingCalendarEventDetails = (long)1 << 32,

        /// <summary>
        /// The wallet journal of a character.
        /// </summary>
        [Header("Wallet Journal")]
        [Description("The wallet journal of a character.")]
        [Update(UpdatePeriod.Hours1, UpdatePeriod.Hours1)]
        WalletJournal = (long)1 << 33,

        /// <summary>
        /// The wallet transactions of a character.
        /// </summary>
        [Header("Wallet Transactions")]
        [Description("The wallet transactions of a character.")]
        [Update(UpdatePeriod.Hours1, UpdatePeriod.Hours1)]
        WalletTransactions = (long)1 << 34,
    }
}
