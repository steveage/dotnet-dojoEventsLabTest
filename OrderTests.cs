namespace DojoEventsLabTest;

public class OrderTests {
    [Fact]
    public void Create_RaisesEvent() {
        // Arrange
        Order order = new Order();
        
        // Act
        Assert.RaisedEvent<OrderEventArgs> receivedEvent = Assert.Raises<OrderEventArgs>(
            a => order.OnCreated += a,
            a => order.OnCreated -= a,
            () => order.Create()
        );

        // Assert
        Assert.NotNull(receivedEvent);
        Assert.Equal(1, receivedEvent.Arguments.Id);
    }
}