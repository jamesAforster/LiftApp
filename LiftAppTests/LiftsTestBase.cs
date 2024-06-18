using LiftApp;

namespace LiftAppTests;

public class LiftsTestBase
{
    private LiftSystem LiftSystem;
    public LiftSystem GetLiftSystem(int lifts = 1)
    {
        var floorRange = new Range(0, 10);
        var system = new LiftSystem(floorRange);
        
        for (int i = 1; i <= lifts; i++)
        {
            var lift = new Lift(i);
            system.RegisterLift(lift);

        }

        LiftSystem = system;
        
        return system;
    }

    public void SetLift( int id, int floor)
    {
        LiftSystem.Lifts().FirstOrDefault(l => l.Id == id).CurrentFloor = floor; // todo: Nasty, just here for test purposes
    }
}