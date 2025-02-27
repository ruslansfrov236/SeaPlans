using System.ComponentModel.DataAnnotations;
using seaplan.entity.Entities.Common;

namespace seaplan.entity.Entities;

public class PaymentDetails : BaseEntity
{
    [MaxLength(19)] public string CardNumberMasked { get; set; }

    [MaxLength(50)] public string BankAccountNumber { get; set; }

    [MaxLength(100)] public string BankName { get; set; }
}