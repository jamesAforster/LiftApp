namespace LiftApp;

public interface ILiftSystem
{
    void RequestLift(int floor);
}

public class LiftSystem : ILiftSystem
{
    private List<ILift> _lifts = new List<ILift>();
    private Range _floorRange;
    
    public LiftSystem(Range floorRange)
    {
        _floorRange = floorRange;
    }

    public void RegisterLift(Lift lift)
    {
        lift.SetLiftSystem(this);
        lift.CurrentFloor = 0;
        _lifts.Add(lift);
    }
    
    public int GetLiftPosition(int id)
    { 
        return _lifts.FirstOrDefault(l => l.Id == id).CurrentFloor;
    }

    public void RequestLift(int floor)
    {
        if (FloorIsWithinRange(floor))
        {
            SendLiftToFloor(floor);
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

    private void SendLiftToFloor(int floor)
    {
        ILift lift = FindNearestLift(floor);

        lift.CurrentFloor = floor;
    }
    private ILift FindNearestLift(int floor)
    {
        return _lifts
            .OrderBy(l => Math.Abs(floor - l.CurrentFloor))
            .First();
    }
}