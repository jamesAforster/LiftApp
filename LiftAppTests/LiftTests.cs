using LiftApp;

namespace LiftAppTests;

public class LiftTests
{
    [Fact]
    public void WhenLiftCalledToFloor_LiftAppearsAtFloor()
    {
        // Arrange
        var lift = new Lift();
        var floorRange = new Range(0, 5);
        var sut = new LiftSystem(lift, floorRange);
        var floor = 2;
        
        // Act
        sut.CallLift(floor);
        
        // Assert
        Assert.True(sut.GetLiftPosition == floor);
    }
    
    [Fact]
    public void WhenLiftCalledToFloor_NotWithinLiftRange_ExceptionIsThrown()
    {
        // Arrange
        var lift = new Lift();
        var floorRange = new Range(0, 5);
        var sut = new LiftSystem(lift, floorRange);
        var floor = 10;
        
        // Act & Assert
        Assert.Throws<ArgumentOutOfRangeException>(() => sut.GetLiftPosition == floor);
    }
}