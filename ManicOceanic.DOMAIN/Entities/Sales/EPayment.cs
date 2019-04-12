using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace ManicOceanic.DOMAIN.Entities.Sales
{
  public enum EPayment
  {
    [Description("Klarna")]
    Klarna = 1,

    [Description("Credit Card")]
    CreditCard = 2,

    [Description("PayPal")]
    PayPal = 3,

    [Description("Invoice")]
    Invoice = 4,
  }
}
