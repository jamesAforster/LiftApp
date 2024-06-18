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
        
        CancellationTokenSource source = new CancellationTokenSource();
        CancellationToken token = source.Token;
        
        var floor = 2;
        
        // Act
        system.Run(token);
        system.RequestLift(floor);
        Thread.Sleep(1000);
        
        source.Cancel();
        
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
    public void WhenLiftCalledToFloor_NearestLiftAppearsAtFloor()
    {
        // Arrange
        var lift1 = new Lift(1);
        var lift2 = new Lift(2);
        var floorRange = new Range(0, 10);
        var system = new LiftSystem(floorRange);
        CancellationTokenSource source = new CancellationTokenSource();
        CancellationToken token = source.Token;
        
        system.RegisterLift(lift1);
        lift1.CurrentFloor = 1;
        
        system.RegisterLift(lift2);
        lift2.CurrentFloor = 9;
        
        // Act
        system.Run(token);
        system.RequestLift(2);
        
        Thread.Sleep(1000);
        
        source.Cancel();
        
        // Assert
        Assert.Equal(2, system.GetLiftPosition(1));
    }
    
    [Fact]
    public void WhenLiftCalledToFloor_AndLiftIsInTransit_RestingLiftAppearsAtFloor()
    {
        // Arrange
        var lift1 = new Lift(1);
        var lift2 = new Lift(2);
        var floorRange = new Range(0, 10);
        var system = new LiftSystem(floorRange);
        CancellationTokenSource source = new CancellationTokenSource();
        CancellationToken token = source.Token;
        
        system.RegisterLift(lift1);
        lift1.CurrentFloor = 1;
        
        system.RegisterLift(lift2);
        lift2.CurrentFloor = 1;
        
        // Act
        system.Run(token);
        system.RequestLift(10);
        system.RequestLift(5);
        
        Thread.Sleep(1000);
        
        source.Cancel();
        
        // Assert
        Assert.Equal(10, system.GetLiftPosition(1));
        Assert.Equal(5, system.GetLiftPosition(2));
    }
}