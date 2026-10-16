using HomeApplianceRepairSystem.Abstracts;

namespace HomeApplianceRepairSystem.Models;

/// <summary>
/// غسالة.
/// </summary>
public class WashingMachine : Appliance
{
    private bool _isFrontLoad;

    public bool IsFrontLoad
    {
        get => _isFrontLoad;
        set => _isFrontLoad = value;
    }

    public WashingMachine(string serialNumber, string brand, double baseCost, bool isFrontLoad)
        : base(serialNumber, brand, baseCost)
    {
        IsFrontLoad = isFrontLoad;
    }

    public override double CalculateRepairCost()
        => BaseCost + (IsFrontLoad ? 150 : 100);

    public override string GetStatus()
        => $"[WashingMachine] {base.GetStatus()} | FrontLoad: {IsFrontLoad}";
}