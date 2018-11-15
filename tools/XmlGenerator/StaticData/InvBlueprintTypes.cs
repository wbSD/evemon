using System.Xml.Serialization;
using EVEMon.XmlGenerator.Interfaces;

namespace EVEMon.XmlGenerator.StaticData
{
    public sealed class InvBlueprintTypes : IHasID
    {
        [XmlElement("blueprintTypeID")]
        public int ID { get; set; }

        [XmlElement("productTypeID")]
        public int ProductTypeID { get; set; }

        [XmlElement("productionTime")]
        public int ProductionTime { get; set; }

        [XmlElement("researchProductivityTime")]
        public int ResearchProductivityTime { get; set; }

        [XmlElement("researchMaterialTime")]
        public int ResearchMaterialTime { get; set; }

        [XmlElement("researchCopyTime")]
        public int ResearchCopyTime { get; set; }

        [XmlAttribute("reverseEngineeringTime")]
        public int ReverseEngineeringTime { get; set; }

        [XmlAttribute("inventionTime")]
        public int InventionTime { get; set; }

        [XmlElement("maxProductionLimit")]
        public int MaxProductionLimit { get; set; }
    }
}
