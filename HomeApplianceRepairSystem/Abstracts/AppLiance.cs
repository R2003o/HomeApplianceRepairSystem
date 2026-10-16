using HomeApplianceRepairSystem.Events;
using HomeApplianceRepairSystem.Interfaces;
using HomeApplianceRepairSystem.Static;

namespace HomeApplianceRepairSystem.Abstracts;

/// <summary>
/// التفويض المستخدم للإشعار بتغير حالة الجهاز.
/// </summary>
public delegate void RepairStatusHandler(Appliance sender, RepairEventArgs e);

/// <summary>
/// الفئة المجردة الأساسية لكل الأجهزة المنزلية.
/// </summary>
public abstract class Appliance : IRepairable
{
    private readonly string _serialNumber;
    private string _brand;
    private double _baseCost;
    private string _status;

    public event RepairStatusHandler? StatusChanged;

    public string SerialNumber => _serialNumber;

    public string Brand
    {
        get => _brand;
        private set => _brand = value;
    }

    public double BaseCost
    {
        get => _baseCost;
        set
        {
            if (!Validator.IsValidCost(value))
                throw new ArgumentException("Base cost must be >= 0");
            _baseCost = value;
        }
    }

    public string Status
    {
        get => _status;
        set
        {
            if (_status == value) return;
            string old = _status;
            _status = value;
            OnStatusChanged(new RepairEventArgs(old, value));
        }
    }

    protected Appliance(string serialNumber, string brand, double baseCost)
    {
        if (!Validator.IsValidSerial(serialNumber))
            throw new ArgumentException("Invalid serial number");
        if (!Validator.IsValidBrand(brand))
            throw new ArgumentException("Invalid brand");

        _serialNumber = serialNumber;
        _brand = brand;
        _baseCost = baseCost;
        _status = "Pending";
    }

    public abstract double CalculateRepairCost();

    public virtual string GetStatus()
        => $"{Brand} ({SerialNumber}) - Status: {Status}";

    protected virtual void OnStatusChanged(RepairEventArgs e)
        => StatusChanged?.Invoke(this, e);
}