namespace LiftApp;

public class LiftSystem
{
    private Lift _lift;
    public LiftSystem(Lift lift)
    {
        _lift = lift;
    }
        
    public Lift Lift { get; set; }

    public void CallLift(int floor)
    {
        _lift.Floor = floor;
    }
}