using System.ComponentModel;
using EVEMon.Common.Attributes;
using EVEMon.Common.Enumerations.UISettings;

namespace EVEMon.Common.Enumerations.CCPAPI
{
    /// <summary>
    /// Enumeration of the ESI API methods. Those methods do not require a token.
    /// Each method should have an entry in APIMethodsEnum and
    /// an equivalent string entry in NetworkConstants indicating the default path of the method.
    /// </summary>
    public enum ESIAPIGenericMethods
    {
        /// <summary>
        /// The EVE server status.
        /// </summary>
        [Header("EVE Server Status")]
        [Description("The status of the EVE server.")]
        [ESIMethod("/v1/status/")]
        [Update(UpdatePeriod.Minutes5, UpdatePeriod.Seconds30, UpdatePeriod.Hours1)]
        ServerStatus,

        /// <summary>
        /// Used to convert IDs to Names.
        /// </summary>
        [ESIMethod("/v2/universe/names/")]
        CharacterName,

        /// <summary>
        /// Used to convert Names to IDs.
        /// </summary>
        CharacterID,

        /// <summary>
        /// Retrieves information about a conquerable station.
        /// </summary>
        [ESIMethod("/v2/universe/stations/{0}/")]
        StationInfo,

        /// <summary>
        /// Retrieves information about a citadel.
        /// </summary>
        [ESIMethod("/v1/universe/structures/{0}/", Scope = "esi-universe.read_structures.v1")]
        CitadelInfo,

        /// <summary>
        /// Retrieves information about a planet.
        /// </summary>
        [ESIMethod("/v1/universe/planets/{0:D}/")]
        PlanetInfo,

        /// <summary>
        /// List of alliances in EVE.
        /// </summary>
        [ESIMethod("/v1/alliances/")]
        AllianceList,

        /// <summary>
        /// Factional warfare statistics for all EVE.
        /// </summary>
        [ESIMethod("/v1/fw/stats/")]
        EVEFactionalWarfareStats,

        /// <summary>
        /// Factional warfare top 100 statistics for all EVE.
        /// </summary>
        [ESIMethod("/v1/fw/leaderboards/")]
        EVEFactionalWarfareTopStats,

        /// <summary>
        /// List of factions at war.
        /// </summary>
        [ESIMethod("/v1/fw/wars/")]
        FactionWars,

        /// <summary>
        /// List of references of typeIDs.
        /// </summary>
        RefTypes,

        /// <summary>
        /// Used to convert typeIDs to typeNames.
        /// </summary>
        [ESIMethod("/v2/universe/names/")]
        TypeName,

        /// <summary>
        /// List of solar systems taking part in Factional Warfare and their occupancy.
        /// </summary>
        [ESIMethod("/v2/fw/systems/")]
        FactionalWarfareSystems,

        /// <summary>
        /// List of solar sytems with jump gates.
        /// </summary>
        [ESIMethod("/v1/universe/system_jumps/")]
        Jumps,

        /// <summary>
        /// List of solar systems with kills within the last hour.
        /// </summary>
        [ESIMethod("/v2/universe/system_kills/")]
        Kills,

        /// <summary>
        /// List of solar systems that are controlled by a faction or alliance.
        /// </summary>
        [ESIMethod("/v1/sovereignty/structures/")]
        Sovereignty,

        /// <summary>
        /// An individual killmail by hash.
        /// </summary>
        [ESIMethod("/v1/killmails/{0}/{1}/")]
        KillMail
    }
}
