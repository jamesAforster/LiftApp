namespace LiftApp;

public interface ILiftSystem
{
    void RequestLift(int floor);
}

public class LiftSystem : ILiftSystem
{
    private ILift _lift;
    private Range _floorRange;

    public int GetLiftPosition => _lift.CurrentFloor;

    public void RegisterLift(Lift lift)
    {
        lift.SetLiftSystem(this);
        _lift = lift;
    }
    
    public LiftSystem(Range floorRange)
    {
        _floorRange = floorRange;
    }

    public void RequestLift(int floor)
    {
        if (FloorIsWithinRange(floor))
        {
            SetCurrentFloor(floor);
        }
        else
        {
            throw new ArgumentOutOfRangeException();
        }
    }

    private bool FloorIsWithinRange(int floor)
    {
        return floor >= _floorRange.Start.Value && floor <= _floorRange.End.Value;
    }

    private void SetCurrentFloor(int floor) => _lift.CurrentFloor = floor;
}