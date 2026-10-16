namespace HomeApplianceRepairSystem.Events;

/// <summary>
/// بيانات الحدث المرسلة عند تغيّر حالة الجهاز.
/// </summary>
public class RepairEventArgs : EventArgs
{
    public string OldStatus { get; }
    public string NewStatus { get; }
    public DateTime ChangedAt { get; }

    public RepairEventArgs(string oldStatus, string newStatus)
    {
        OldStatus = oldStatus;
        NewStatus = newStatus;
        ChangedAt = DateTime.Now;
    }
}