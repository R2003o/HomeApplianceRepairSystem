using HomeApplianceRepairSystem.Management;
using HomeApplianceRepairSystem.Models;

namespace HomeApplianceRepairSystem;

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        var center = new RepairCenter();

        var fridge = new Refrigerator("RF001", "Samsung", 300, 500);
        var washer = new WashingMachine("WM001", "LG", 200, true);
        var ac = new AirConditioner("AC001", "Midea", 250, 12000);

        center.AddAppliance(fridge);
        center.AddAppliance(washer);
        center.AddAppliance(ac);

        Console.WriteLine("=== Before Repair ===");
        center.ShowAllStatuses();

        Console.WriteLine("\n=== Changing Statuses ===");
        fridge.Status = "Repairing";
        washer.Status = "Completed";
        ac.Status = "Delayed";

        Console.WriteLine("\n=== After Repair ===");
        center.ShowAllStatuses();

        Console.WriteLine($"\nTotal Repair Cost: {center.GetTotalRepairCost()}");
        Console.WriteLine($"Total Devices: {RepairCenter.TotalDevices}");
        Console.WriteLine($"Total Revenue: {RepairCenter.TotalRevenue}");

        Console.ReadKey();
    }
}