namespace LiftApp;

public class LiftSystem
{
    private Lift _lift;
    private Range _floorRange;

    public int GetLiftPosition => _lift.Floor;
    
    public LiftSystem(Lift lift, Range floorRange)
    {
        _lift = lift;
        _floorRange = floorRange;
    }

    public void CallLift(int floor)
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

    private void SetCurrentFloor(int floor) => _lift.Floor = floor;
}