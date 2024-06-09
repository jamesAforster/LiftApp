using LiftApp;

namespace LiftAppTests;

public class LiftTests
{
    [Fact]
    public void WhenLiftCalledToFloor_LiftAppearsAtFloor()
    {
        // Arrange
        var lift = new Lift();
        var floorRange = new Range(0, 10);
        var system = new LiftSystem(floorRange);
        system.RegisterLift(lift);
        
        var floor = 2;
        
        // Act
        system.RequestLift(floor);
        
        // Assert
        Assert.True(system.GetLiftPosition == floor);
    }
    
    [Theory]
    [InlineData(-20)]
    [InlineData(-1)]
    [InlineData(11)]
    [InlineData(20)]
    public void WhenLiftCalledToFloor_NotWithinLiftRange_ExceptionIsThrown(int requestedFloor)
    {
        // Arrange
        var lift = new Lift();
        var floorRange = new Range(0, 10);
        var system = new LiftSystem(floorRange);
        system.RegisterLift(lift);

        // Act
        system.RequestLift(requestedFloor);
        
        // Act & Assert
        Assert.Throws<ArgumentOutOfRangeException>(() => system.RequestLift(requestedFloor));
    }
}