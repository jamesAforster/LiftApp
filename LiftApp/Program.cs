﻿namespace LiftApp;

class Program
{
    static void Main(string[] args)
    {
        var lift = new Lift();
        var floorRange = new Range(0, 10);
        var liftSystem = new LiftSystem(floorRange);
        
        lift.RequestLift(2);

        Console.WriteLine("Lift at floor: " + liftSystem.GetLiftPosition);
    }
}
