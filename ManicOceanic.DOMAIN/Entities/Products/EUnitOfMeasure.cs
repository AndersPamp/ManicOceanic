using System.ComponentModel;

namespace ManicOceanic.DOMAIN.Entities
{
    public enum EUnitOfMeasure
    {
        [Description ("pcs")]
        Quantity = 1,

        [Description("l")]
        Liter = 2,

        [Description("g")]
        Gram = 3,

        [Description("m")]
        Meter = 4
    }
}
