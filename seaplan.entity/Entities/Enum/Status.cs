namespace seaplan.entity.Entities.Enum;

public enum Status
{
    Pending, // Gözləmədədir, təsdiq olunmayıb
    Approved, // Manager tərəfindən təsdiq olunub
    Rejected, // Manager tərəfindən rədd edilib
    Canceled // İstifadəçi tərəfindən ləğv edilib
}