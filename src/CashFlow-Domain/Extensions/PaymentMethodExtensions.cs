
using CashFlow_Domain.Enums;
using CashFlow_Domain.Reports;

namespace CashFlow_Domain.Extensions;
public static class PaymentMethodExtensions
{
    public static string PaymentMethodToString(this PaymentMethod paymentMethod)
    {
        return paymentMethod switch
        {
            PaymentMethod.Cash => ResourceReportPaymentMethods.CASH,
            PaymentMethod.CreditCard => ResourceReportPaymentMethods.CREDIT_CARD,
            PaymentMethod.DebitCard => ResourceReportPaymentMethods.DEBIT_CARD,
            PaymentMethod.EletronicTransfer => ResourceReportPaymentMethods.ELETRONIC_TRANSFER,
            _ => string.Empty
        };
    }
}