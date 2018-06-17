using EVEMon.Common.Enumerations.CCPAPI;
using EVEMon.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EVEMon.Common.Extensions
{
    public static class ESIKeyExtensions
    {
        /// <summary>
        /// Translates an ESI Key into a list of ESI scopes that it provides access to.
        /// </summary>
        /// <param name="esiKey">The key to translate. Can be null.</param>
        /// <param name="defaultToBasicCharacterFeatures">If key is null, default to basic character features? <see cref="CCPAPIMethodsEnum.BasicCharacterFeatures"/></param>
        /// <returns></returns>
        public static HashSet<string> ConvertToScopes(this ESIKey esiKey, bool defaultToBasicCharacterFeatures = false)
        {
            ulong characterAccessMask = 0UL;
            if (defaultToBasicCharacterFeatures)
                characterAccessMask = (ulong)CCPAPIMethodsEnum.BasicCharacterFeatures;

            characterAccessMask = esiKey?.CharacterAccessMask ?? characterAccessMask;
            ulong corporationAccessMask = esiKey?.CorporationAccessMask ?? 0UL;

            var characterScopes = ConvertMaskToScopes<ESIAPICharacterMethods>(characterAccessMask);
            var corporationScopes = ConvertMaskToScopes<ESIAPICorporationMethods>(corporationAccessMask);

            return new HashSet<string>(characterScopes.Concat(corporationScopes));
        }

        /// <summary>
        /// Returns a list of scopes that input access mask translates to.
        /// </summary>
        /// <typeparam name="T"><see cref="ESIAPICharacterMethods"/> or <see cref="ESIAPICorporationMethods"/></typeparam>
        /// <param name="mask">Access mask to translate</param>
        /// <returns></returns>
        private static IEnumerable<string> ConvertMaskToScopes<T>(ulong mask) where T : struct, IConvertible
        {
            List<string> scopes = new List<string>();

            mask.MatchMaskToScopes((T m) =>
            {
                scopes.Add((m as Enum).GetESIMethodScope());
            });

            return scopes;
        }

        /// <summary>
        /// Loop through ESI API method enum and invoke callback for methods that require an ESI scope
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="mask"></param>
        /// <param name="callback"></param>
        public static void MatchMaskToScopes<T>(this ulong mask, Action<T> callback) where T : struct, IConvertible
        {
            foreach (var m in Enum.GetValues(typeof(T))
               .OfType<T>()
               .Where(x => (x as Enum).RequiresESIMethodScope()))
            {
                var u = Convert.ToUInt64(m);
                if ((u & mask) == u)
                    callback(m);
            }
        }

        /// <summary>
        /// Invoke callback for all <see cref="ESIAPICharacterMethods"/> values that match input flags and require an ESI scope
        /// </summary>
        /// <param name="flags"></param>
        /// <param name="callback"></param>
        public static void MatchFlagsToScopes(this ESIAPICharacterMethods flags, Action<ESIAPICharacterMethods> callback)
        {
            ((ulong)flags).MatchMaskToScopes(callback);
        }

        /// <summary>
        /// Invoke callback for all <see cref="ESIAPICorporationMethods"/> values that match input flags and require an ESI scope
        /// </summary>
        /// <param name="flags"></param>
        /// <param name="callback"></param>
        public static void MatchFlagsToScopes(this ESIAPICorporationMethods flags, Action<ESIAPICorporationMethods> callback)
        {
            ((ulong)flags).MatchMaskToScopes(callback);
        }
    }
}
