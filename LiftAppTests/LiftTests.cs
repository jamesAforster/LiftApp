using LiftApp;

namespace LiftAppTests;

public class LiftTests
{
    [Fact]
    public void WhenLiftCalledToFloor_LiftAppearsAtFloor()
    {
        // Arrange
        var lift = new Lift(1);
        var floorRange = new Range(0, 10);
        var system = new LiftSystem(floorRange);
        system.RegisterLift(lift);
        
        var floor = 2;
        
        // Act
        system.RequestLift(floor);
        
        // Assert
        Assert.True(system.GetLiftPosition(1) == floor);
    }
    
    [Theory]
    [InlineData(-20)]
    [InlineData(-1)]
    [InlineData(11)]
    [InlineData(20)]
    public void WhenLiftCalledToFloor_NotWithinLiftRange_ExceptionIsThrown(int requestedFloor)
    {
        // Arrange
        var lift = new Lift(1);
        var floorRange = new Range(0, 10);
        var system = new LiftSystem(floorRange);
        system.RegisterLift(lift);
        
        // Act & Assert
        Assert.Throws<ArgumentOutOfRangeException>(() => system.RequestLift(requestedFloor));
    }
    
    [Fact]
    public void WhenLiftCalledToFloor_NearestLiftIsCalledToFloor()
    {
        // Arrange
        var lift1 = new Lift(1);
        var lift2 = new Lift(2);
        
        var floorRange = new Range(0, 10);
        var system = new LiftSystem(floorRange);
        
        system.RegisterLift(lift1);
        system.RegisterLift(lift2);

        lift1.CurrentFloor = 1;
        lift2.CurrentFloor = 4;

        // Act
        system.RequestLift(5);
        
        // Act & Assert
        Assert.True(system.GetLiftPosition(2) == 5);
    }
}