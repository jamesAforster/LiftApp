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
        var sut = new LiftSystem(lift, floorRange);
        var floor = 2;
        
        // Act
        sut.RequestLift(floor);
        
        // Assert
        Assert.True(sut.GetLiftPosition == floor);
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
        var sut = new LiftSystem(lift, floorRange);
        
        // Act & Assert
        Assert.Throws<ArgumentOutOfRangeException>(() => sut.RequestLift(requestedFloor));
    }
}