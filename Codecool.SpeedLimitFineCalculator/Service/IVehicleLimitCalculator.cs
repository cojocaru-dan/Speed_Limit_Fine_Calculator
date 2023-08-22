using Codecool.SpeedLimitFineCalculator.Model;

namespace Codecool.SpeedLimitFineCalculator.Service;

public interface IVehicleLimitCalculator
{
    int GetVehicleLimitByRoadType(VehicleType vehicleType, RoadType roadType);
}

public class VehicleLimitCalculator : IVehicleLimitCalculator
{
    public int GetVehicleLimitByRoadType(VehicleType vehicleType, RoadType roadType)
    {
        Dictionary<string, Dictionary<string, int>> vehicleLimits = new Dictionary<string, Dictionary<string, int>>()
            {
                {"Car", new Dictionary<string, int>{{"Urban", 50}, {"MainRoad", 90}, {"Highway", 130}}},
                {"Bus", new Dictionary<string, int>{{"Urban", 50}, {"MainRoad", 70}, {"Highway", 100}}},
                {"Truck", new Dictionary<string, int>{{"Urban", 50}, {"MainRoad", 70}, {"Highway", 80}}} 
            };

        return vehicleLimits[vehicleType.ToString()][roadType.ToString()];
    }
}