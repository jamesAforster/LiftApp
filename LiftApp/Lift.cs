namespace LiftApp;

public class Lift(int id) : ILift
{
    public int Id { get; set; } = id;
    public bool InTransit { get; set; }

    public async Task GoToFloor(int floor)
    {
        if (CurrentFloor != floor)
        {
            Console.WriteLine($"I am at floor {CurrentFloor}");
            InTransit = true;
            // var timeToTravel = Math.Abs(CurrentFloor - floor) * 1000;
            Thread.Sleep(1000);
            CurrentFloor = floor;
            InTransit = false;
            Console.WriteLine($"I am at floor {CurrentFloor}");
        }
    }

    public int CurrentFloor { get; set; }
    public ILiftSystem? LiftSystem { get; set; }

    public void SetLiftSystem(ILiftSystem liftSystem)
    {
        LiftSystem = liftSystem;
    }
}

public interface ILift
{
    public int Id { get; set; }
    public Task GoToFloor(int floor);
    public int CurrentFloor { get; set; }
    public ILiftSystem LiftSystem { get; set; }
    public bool InTransit { get; set; }
}