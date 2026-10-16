using HomeApplianceRepairSystem.Abstracts;

namespace HomeApplianceRepairSystem.Models;

/// <summary>
/// مكيف هواء.
/// </summary>
public class AirConditioner : Appliance
{
    private int _btu;

    public int BTU
    {
        get => _btu;
        set
        {
            if (value <= 0) throw new ArgumentException("BTU must be > 0");
            _btu = value;
        }
    }

    public AirConditioner(string serialNumber, string brand, double baseCost, int btu)
        : base(serialNumber, brand, baseCost)
    {
        BTU = btu;
    }

    public override double CalculateRepairCost()
        => BaseCost + (BTU / 100.0);

    public override string GetStatus()
        => $"[AirConditioner] {base.GetStatus()} | BTU: {BTU}";
}
