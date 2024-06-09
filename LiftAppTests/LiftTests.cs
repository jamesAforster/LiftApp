using LiftApp;

namespace LiftAppTests;

public class LiftTests
{
    [Fact]
    public void WhenLiftCalledToFloor_LiftAppearsAtFloor()
    {
        // Arrange
        var lift = new Lift();
        var sut = new LiftSystem(lift);
        var floor = 2;
        
        // Act
        sut.CallLift(floor);
        
        // Assert
        Assert.True(sut.GetLiftPosition == floor);
    }
}