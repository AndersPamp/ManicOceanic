using System.ComponentModel;

namespace ManicOceanic.DOMAIN.Entities.Sales
{
    public enum EShipping
    {
        [Description("UPS")]
        Ups = 1,

        [Description("Postnord")]
        Postnord = 2,

        [Description("Schenker")]
        Schenker = 3
    }
}
