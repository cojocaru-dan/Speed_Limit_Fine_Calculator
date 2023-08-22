using Codecool.SpeedLimitFineCalculator.Model;

namespace Codecool.SpeedLimitFineCalculator.Service;

public interface ISpeedLimitFineCalculator
{
    double CalculateSpeedLimitFine(VehicleType vehicleType, RoadType roadType, double actualSpeed);
}

public class SpeedFineCalculator : ISpeedLimitFineCalculator
{
    private readonly IVehicleLimitCalculator _vehicleLimitCalculator;

    public SpeedFineCalculator(IVehicleLimitCalculator vehicleLimitCalculator)
    {
        _vehicleLimitCalculator = vehicleLimitCalculator;
    }

    public double CalculateSpeedLimitFine(VehicleType vehicleType, RoadType roadType, double actualSpeed)
    {
        int point = 145;
        int vehicleLimit = _vehicleLimitCalculator.GetVehicleLimitByRoadType(vehicleType, roadType);
        if (actualSpeed <= vehicleLimit) return 0;
        else if (actualSpeed - vehicleLimit <= 10) return 0;
        else if (actualSpeed - vehicleLimit <= 20) return 2 * point;
        else if (actualSpeed - vehicleLimit <= 30) return 3 * point;
        else if (actualSpeed - vehicleLimit <= 40) return 4 * point;
        else return 8 * point;
    }
}