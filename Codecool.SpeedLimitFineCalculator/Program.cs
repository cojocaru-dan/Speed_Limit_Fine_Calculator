using Codecool.SpeedLimitFineCalculator.Service;
using Codecool.SpeedLimitFineCalculator.Service.Logger;
using Codecool.SpeedLimitFineCalculator.UI;

namespace Codecool.SpeedLimitFineCalculator;

internal static class Program
{
    public static void Main(string[] args)
    {
        IVehicleLimitCalculator vehicleLimitCalculator = new VehicleLimitCalculator();
        ISpeedLimitFineCalculator speedFineCalculator = new SpeedFineCalculator(vehicleLimitCalculator);
        var fineCalculatorUi = new FineCalculatorUi(speedFineCalculator);
        fineCalculatorUi.Run();
    }
}