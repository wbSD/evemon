using EVEMon.Common.Attributes;

namespace EVEMon.Common.Enumerations.UISettings
{
    // TODO: This should be phased out, as ESI relies on cached results instead of rate limiting
    public enum CacheStyle
    {
        /// <summary>
        /// Short cache style, data will always be returned from CCP,
        /// however it will only be updated once the cache timer
        /// expires.
        /// </summary>
        [Header("Short")]
        Short,

        /// <summary>
        /// Long cache style, data will only be returned from CCP after
        /// the cahce timer has expired.
        /// </summary>
        [Header("Long")]
        Long
    }
}