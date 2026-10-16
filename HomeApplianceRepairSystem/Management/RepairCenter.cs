using HomeApplianceRepairSystem.Abstracts;
using HomeApplianceRepairSystem.Events;

namespace HomeApplianceRepairSystem.Management;

/// <summary>
/// فئة إدارة مركز الصيانة.
/// </summary>
public class RepairCenter
{
    private readonly List<Appliance> _appliances = new();

    public static int TotalDevices => _appliancesCount;
    private static int _appliancesCount = 0;

    public static double TotalRevenue { get; private set; } = 0;

    public void AddAppliance(Appliance appliance)
    {
        appliance.StatusChanged += OnStatusChanged;
        _appliances.Add(appliance);
        _appliancesCount++;
    }

    private void OnStatusChanged(Appliance sender, RepairEventArgs e)
    {
        Console.WriteLine($"[Notification] {sender.SerialNumber}: {e.OldStatus} -> {e.NewStatus} @ {e.ChangedAt:HH:mm:ss}");

        if (e.NewStatus == "Completed")
            TotalRevenue += sender.CalculateRepairCost();
    }

    public double GetTotalRepairCost()
        => _appliances.Sum(a => a.CalculateRepairCost());

    public void ShowAllStatuses()
    {
        foreach (var a in _appliances)
            Console.WriteLine(a.GetStatus());
    }
}
