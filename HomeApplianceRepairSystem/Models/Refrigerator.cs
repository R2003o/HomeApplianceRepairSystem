using HomeApplianceRepairSystem.Abstracts;

namespace HomeApplianceRepairSystem.Models;

/// <summary>
/// ثلاجة.
/// </summary>
public class Refrigerator : Appliance
{
    private int _capacity;

    public int Capacity
    {
        get => _capacity;
        set
        {
            if (value <= 0) throw new ArgumentException("Capacity must be > 0");
            _capacity = value;
        }
    }

    public Refrigerator(string serialNumber, string brand, double baseCost, int capacity)
        : base(serialNumber, brand, baseCost)
    {
        Capacity = capacity;
    }

    public override double CalculateRepairCost()
        => BaseCost + (Capacity * 2);

    public override string GetStatus()
        => $"[Refrigerator] {base.GetStatus()} | Capacity: {Capacity}L";
}