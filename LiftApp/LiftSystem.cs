using System.Collections;

namespace LiftApp;

public interface ILiftSystem
{
    void RequestLift(int floor);
}

public class LiftSystem : ILiftSystem
{
    private List<ILift> _lifts = new List<ILift>();
    private Range _floorRange;
    private Queue _commandQueue;
    
    public LiftSystem(Range floorRange)
    {
        _floorRange = floorRange;
        _commandQueue = new Queue();
    }

    public Queue CommandQueue => _commandQueue;

    public void RegisterLift(Lift lift)
    {
        lift.SetLiftSystem(this);
        lift.CurrentFloor = 0; // Todo: field should not be publicly accessible in future
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
            _commandQueue.Enqueue(floor);
            ProcessQueue();
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

    private void ProcessQueue()
    {
        foreach (int i in _commandQueue)
        {
            ILift lift = FindNearestLift(i);
            lift.GoToFloor(i);
        }
    }
    private ILift FindNearestLift(int floor)
    {
        return _lifts
            .OrderBy(l => Math.Abs(floor - l.CurrentFloor))
            .First();
    }
}