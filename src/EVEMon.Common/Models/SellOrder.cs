using EVEMon.Common.Serialization.Eve;
using EVEMon.Common.Serialization.Settings;

namespace EVEMon.Common.Models
{
    /// <summary>
    /// This class represents a sell order.
    /// </summary>
    public sealed class SellOrder : MarketOrder
    {
        /// <summary>
        /// Constructor from the API.
        /// </summary>
        /// <param name="src"></param>
        internal SellOrder(SerializableOrderListItem src, CCPCharacter character)
            : base(src, character)
        {
        }

        /// <summary>
        /// Constructor from an object deserialized from the settings file.
        /// </summary>
        /// <param name="src"></param>
        internal SellOrder(SerializableOrderBase src, CCPCharacter character)
            : base(src, character)
        {
        }

        /// <summary>
        /// Exports the given object to a serialization object.
        /// </summary>
        /// <returns></returns>
        public override SerializableOrderBase Export() => Export(new SerializableSellOrder());
    }
}
