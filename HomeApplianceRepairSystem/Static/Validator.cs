namespace HomeApplianceRepairSystem.Static;

/// <summary>
/// فئة ثابتة للتحقق من صحة البيانات المدخلة.
/// </summary>
public static class Validator
{
    public static bool IsValidSerial(string serial)
        => !string.IsNullOrWhiteSpace(serial) && serial.Length >= 5;

    public static bool IsValidBrand(string brand)
        => !string.IsNullOrWhiteSpace(brand);

    public static bool IsValidCost(double cost)
        => cost >= 0;
}