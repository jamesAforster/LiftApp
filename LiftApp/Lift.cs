namespace LiftApp;

public class Lift(int id) : ILift
{
    public int Id { get; set; } = id;
    public int CurrentFloor { get; set; }
    public ILiftSystem? LiftSystem { get; set; }

    public void SetLiftSystem(ILiftSystem liftSystem)
    {
        LiftSystem = liftSystem;
    }

    public void RequestLift(int floor)
    {
        LiftSystem?.RequestLift(floor);
    }
}

public interface ILift
{
    public int Id { get; set; }
    public int CurrentFloor { get; set; }
    public ILiftSystem LiftSystem { get; set; }
}