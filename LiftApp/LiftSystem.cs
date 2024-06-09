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
        _lift.Floor = floor;
    }
}