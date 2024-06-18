namespace LiftApp;

class Program
{
    static void Main(string[] args)
    {
        var lift = new Lift(1);
        var floorRange = new Range(0, 10);
        var liftSystem = new LiftSystem(floorRange);
        var token = new CancellationToken();
        
        liftSystem.RegisterLift(lift);
        
        var task = liftSystem.Run(token);
        
        liftSystem.RequestLift(2);
        
        Console.WriteLine("Program finished");

        //
        // var queue = new Queue<int>();
        //
        // for (int i = 0; i < 100; i++)
        // {
        //     queue.Enqueue(i);
        // }
        //
        // var thing = queue.ToList();
        // Console.WriteLine(thing.Count);
    }
}
