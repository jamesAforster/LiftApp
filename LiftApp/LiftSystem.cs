namespace LiftApp;

public class LiftSystem
{
    private Lift _lift;

    public int GetLiftPosition => _lift.Floor;
    
    public LiftSystem(Lift lift)
    {
        _lift = lift;
    }

    public void CallLift(int floor)
    {
        _lift.Floor = floor;
    }
}