using LiftApp;

namespace LiftAppTests;

public class UnitTest1
{
    [Fact]
    public void Test1()
    {
        // Arrange
        var lift = new Lift();
        var sut = new LiftSystem(lift);
        var floor = 2;
        
        // Act
        sut.CallLift(floor);
        
        // Assert
        Assert.True(sut.Lift.Floor == floor);
    }
}