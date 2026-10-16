namespace HomeApplianceRepairSystem.Interfaces;

/// <summary>
/// واجهة تحدد العمليات المشتركة بين جميع الأجهزة القابلة للإصلاح.
/// أي جهاز يدخل مركز الصيانة لازم ينفذ هذه الواجهة.
/// </summary>
public interface IRepairable
{
    /// <summary>
    /// حساب تكلفة إصلاح الجهاز.
    /// كل جهاز يحدد طريقته الخاصة لحساب التكلفة.
    /// </summary>
    double CalculateRepairCost();

    /// <summary>
    /// إرجاع وصف نصي لحالة الجهاز الحالية.
    /// </summary>
    string GetStatus();
}