using System.Collections.Concurrent;

namespace LiftApp;

public interface ILiftSystem
{
    void RequestLift(int floor);
}

public class LiftSystem : ILiftSystem
{
    private List<ILift> _lifts = new List<ILift>();
    private Range _floorRange;
    private Queue<int> _commandQueue;
    
    public LiftSystem(Range floorRange)
    {
        _floorRange = floorRange;
        _commandQueue = new Queue<int>();
    }

    public Queue<int> CommandQueue => _commandQueue;

    public Task Run(CancellationToken token)
    {
        Task.Run(() =>
        {
            while (!token.IsCancellationRequested)
            {
                foreach (int i in _commandQueue.ToList())
                {
                    if (!LiftsAreInTransit())
                    {
                        ILift lift = FindNearestLift(i);
                        lift.GoToFloor(i);
                        _commandQueue.Dequeue();
                    }
                    else
                    {
                        Run(token);
                    }
                }
            }
        });

        return Task.CompletedTask;
    }

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

    private IEnumerable<int> InitiateCommand(int i)
    {
        ILift lift = FindNearestLift(i);
        lift.GoToFloor(i);
        yield break;
    }

    private bool LiftsAreInTransit()
    {
        return _lifts.Any(l => l.InTransit);
    }
    
    private ILift FindNearestLift(int floor)
    {
        return _lifts
            .OrderBy(l => Math.Abs(floor - l.CurrentFloor))
            .First();
    }
}