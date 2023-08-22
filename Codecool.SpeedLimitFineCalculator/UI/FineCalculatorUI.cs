
using Codecool.SpeedLimitFineCalculator.Model;
using Codecool.SpeedLimitFineCalculator.Service;
using Codecool.SpeedLimitFineCalculator.Service.Logger;

namespace Codecool.SpeedLimitFineCalculator.UI;

public class FineCalculatorUi
{
    private readonly ISpeedLimitFineCalculator _speedLimitFineCalculator;
    private static ILogger _logger = new ConsoleLogger();

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
        Console.WriteLine($"You drove with {speed} km/h.");

        double fine = _speedLimitFineCalculator.CalculateSpeedLimitFine(vehicleTypeEnum, roadTypeEnum, speed); // calculate fine
        _logger.LogInfo($"For vehicle type {vehicleTypeEnum} on the {roadTypeEnum} with {speed} km/h the fine is {fine} RON.");

        if (fine == 0)
        {
            Console.WriteLine("You are within speed limits! No fine applies.");
        }
        else
        {
            Console.WriteLine("Your fine is {0:N2} CodeCoins :(", fine);
        }
    }

    private static VehicleType SelectVehicleType()
    {
        Console.Write("Vehicle Type: ");
        string vehicleType = Console.ReadLine() ?? "ii";

        if (vehicleType == "") _logger.LogError("Your Vehicle Type shouldn't be empty");

        vehicleType = vehicleType == "" ? "ii" : char.ToUpper(vehicleType[0]) + vehicleType[1..].ToLower();
        while (!Enum.IsDefined(typeof(VehicleType), vehicleType)) 
        {
            Console.WriteLine("You must choose between Car, Bus and Truck! Try again!");
            Console.Write("Vehicle Type: ");
            vehicleType = Console.ReadLine() ?? "ii";

            if (vehicleType == "") _logger.LogError("Your Vehicle Type shouldn't be empty");

            vehicleType = vehicleType == "" ? "ii" : char.ToUpper(vehicleType[0]) + vehicleType[1..].ToLower();
        }
        return (VehicleType) Enum.Parse(typeof(VehicleType), vehicleType);  
    }
    
    private static RoadType SelectRoadType()
    {
        Console.Write("Road Type: ");
        string roadType = Console.ReadLine() ?? "ii";

        if (roadType == "") _logger.LogError("Your Road Type shouldn't be empty");

        roadType = roadType == "" ? "ii" : char.ToUpper(roadType[0]) + roadType[1..].ToLower();
        roadType = roadType == "Mainroad" ? "MainRoad" : roadType;
        while (!Enum.IsDefined(typeof(RoadType), roadType))
        {
            Console.WriteLine("You must choose between Urban, MainRoad and Highway! Try again!");
            Console.Write("Road Type: ");
            roadType = Console.ReadLine() ?? "ii";

            if (roadType == "") _logger.LogError("Your Road Type shouldn't be empty");
            
            roadType = roadType == "" ? "ii" : char.ToUpper(roadType[0]) + roadType[1..].ToLower();
            roadType = roadType == "Mainroad" ? "MainRoad" : roadType;
        }
        return (RoadType) Enum.Parse(typeof(RoadType), roadType);
    }

    private static int GetSpeed()
    {
        Random rand = new Random();
        return rand.Next(0, 201);
    }
    

    private static void GreetUser()
    {
        Console.WriteLine(
            "Hi! You were on the road again, but you were a bit too fast, weren't you? No worries, let's see how much it will cost you!");
    }
}
