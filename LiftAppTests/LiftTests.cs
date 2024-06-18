namespace LiftAppTests;

public class LiftTests : LiftsTestBase
{
    [Fact]
    public void WhenLiftCalledToFloor_LiftAppearsAtFloor()
    {
        // Arrange
        var sut = GetLiftSystem();
        
        CancellationTokenSource source = new CancellationTokenSource();
        CancellationToken token = source.Token;
        
        var floor = 2;
        
        // Act
        sut.Run(token);
        sut.RequestLift(floor);
        Thread.Sleep(1000);
        
        source.Cancel();
        
        // Assert
        Assert.True(sut.GetLiftPosition(1) == floor);
    }
    
    [Theory]
    [InlineData(-20)]
    [InlineData(-1)]
    [InlineData(11)]
    [InlineData(20)]
    public void WhenLiftCalledToFloor_NotWithinLiftRange_ExceptionIsThrown(int requestedFloor)
    {
        // Arrange
        var sut = GetLiftSystem();;
        
        // Act & Assert
        Assert.Throws<ArgumentOutOfRangeException>(() => sut.RequestLift(requestedFloor));
    }
    
    [Fact]
    public void WhenLiftCalledToFloor_NearestLiftAppearsAtFloor()
    {
        // Arrange
        var sut = GetLiftSystem(2);
        
        CancellationTokenSource source = new CancellationTokenSource();
        CancellationToken token = source.Token;
        
        SetLift(1, 1);
        SetLift(2, 10);
        
        // Act
        sut.Run(token);
        sut.RequestLift(2);
        
        Thread.Sleep(1000);
        
        source.Cancel();
        
        // Assert
        Assert.Equal(2, sut.GetLiftPosition(1));
    }
    
    [Fact]
    public void WhenLiftCalledToFloor_AndLiftIsInTransit_RestingLiftAppearsAtFloor()
    {
        // Arrange
        var sut = GetLiftSystem(2);
        
        CancellationTokenSource source = new CancellationTokenSource();
        CancellationToken token = source.Token;
        
        SetLift(1, 1);
        SetLift(2, 1);

        // Act
        sut.Run(token);
        sut.RequestLift(10);
        sut.RequestLift(5);
        
        Thread.Sleep(1000);
        
        source.Cancel();
        
        // Assert
        Assert.Equal(10, sut.GetLiftPosition(1));
        Assert.Equal(5, sut.GetLiftPosition(2));
    }
}