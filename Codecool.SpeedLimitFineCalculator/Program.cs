using Codecool.SpeedLimitFineCalculator.Service;
using Codecool.SpeedLimitFineCalculator.UI;

namespace Codecool.SpeedLimitFineCalculator;

internal static class Program
{
    public static void Main(string[] args)
    {
        IVehicleLimitCalculator vehicleLimitCalculator = null;
        ISpeedLimitFineCalculator speedLimitFineCalculator = null;
        var fineCalculatorUi = new FineCalculatorUi(speedLimitFineCalculator);
        fineCalculatorUi.Run();
    }
}