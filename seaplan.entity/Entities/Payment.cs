using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using seaplan.entity.Entities.Common;
using seaplan.entity.Entities.Enum;
using seaplan.entity.Entities.Identity;

namespace seaplan.entity.Entities;

public class Payment : BaseEntity
{
    [Required]
    [Column(TypeName = "decimal(18,2)")]
    public decimal Amount { get; set; }

    [Required] [MaxLength(3)] public string Currency { get; set; } = "AZN";

    [Required] public PaymentStatus Status { get; set; }

    [Required] public PaymentMethod Method { get; set; }

    public AppUser User { get; set; }


    public string UserId { get; set; }

    [Required] public Guid PayerId { get; set; }

    [Required] public Guid PayeeId { get; set; }

    [MaxLength(100)] public string PayerName { get; set; }

    [MaxLength(100)] public string PayeeName { get; set; }

    [MaxLength(50)] public string ReferenceNumber { get; set; }

    public string Description { get; set; }

    public PaymentDetails PaymentDetails { get; set; }
}