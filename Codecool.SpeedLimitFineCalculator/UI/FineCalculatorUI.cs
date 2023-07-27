
using Codecool.SpeedLimitFineCalculator.Model;
using Codecool.SpeedLimitFineCalculator.Service;

namespace Codecool.SpeedLimitFineCalculator.UI;

public class FineCalculatorUi
{
    private readonly ISpeedLimitFineCalculator _speedLimitFineCalculator;

    public FineCalculatorUi(ISpeedLimitFineCalculator speedLimitFineCalculator)
    {
        _speedLimitFineCalculator = speedLimitFineCalculator;
    }

    public void Run()
    {
        GreetUser();

        var vehicleTypeEnum = SelectVehicleType();
        var roadTypeEnum = SelectRoadType();
        var speed = GetSpeed();

        double fine = 0; // calculate fine

        if (fine == 0)
        {
            Console.WriteLine("You are within speed limits! No fine applies.");
        }
        else
        {
            Console.WriteLine($"Your fine is {fine} CodeCoins :(");
        }
    }

    private static VehicleType SelectVehicleType()
    {
    }
    
    private static RoadType SelectRoadType()
    {
    }

    private int GetSpeed()
    {
    }
    

    private static void GreetUser()
    {
        Console.WriteLine(
            "Hi! You were on the road again, but you were a bit too fast, weren't you? No worries, let's see how much it will cost you!");
    }
}
