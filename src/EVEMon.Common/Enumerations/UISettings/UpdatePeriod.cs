using System.Xml.Serialization;
using EVEMon.Common.Attributes;

namespace EVEMon.Common.Enumerations.UISettings
{
    [XmlRoot("period")]
    public enum UpdatePeriod
    {
        [Header("Never")]
        Never,

        [Header("5 Seconds")]
        Seconds5,

        [Header("10 Seconds")]
        Seconds10,

        [Header("15 Seconds")]
        Seconds15,

        [Header("30 Seconds")]
        Seconds30,

        [Header("1 Minute")]
        Minutes1,

        [Header("2 Minutes")]
        Minutes2,

        [Header("5 Minutes")]
        Minutes5,

        [Header("10 Minutes")]
        Minutes10,

        [Header("15 Minutes")]
        Minutes15,

        [Header("20 Minutes")]
        Minutes20,

        [Header("30 Minutes")]
        Minutes30,

        [Header("1 Hour")]
        Hours1,

        [Header("2 Hours")]
        Hours2,

        [Header("3 Hours")]
        Hours3,

        [Header("6 Hours")]
        Hours6,

        [Header("12 Hours")]
        Hours12,

        [Header("Day")]
        Day,

        [Header("Week")]
        Week
    }
}