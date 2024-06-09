namespace LiftApp;

class Program
{
    static void Main(string[] args)
    {
        var lift = new Lift(1);
        var floorRange = new Range(0, 10);
        var liftSystem = new LiftSystem(floorRange);
        
        liftSystem.RegisterLift(lift);
        
        liftSystem.RequestLift(2);

        Console.WriteLine("Lift at floor: " + liftSystem.GetLiftPosition(1));
    }
}
