namespace LiftApp;

public class Lift(int id) : ILift
{
    public int Id { get; set; } = id;
    public void GoToFloor(int floor)
    {
        if (CurrentFloor != floor)
        {
            Console.WriteLine($"I am at floor {CurrentFloor}");
            Thread.Sleep(5000);
            CurrentFloor = floor;
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
    public void GoToFloor(int floor);
    public int CurrentFloor { get; set; }
    public ILiftSystem LiftSystem { get; set; }
}