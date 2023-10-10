using Commands;
using MessageBroker;
using Moq;

namespace Tests.APITests;

public class PublisherTests
{
    private Mock<ISocketClient> _socketClientMoq;
    
    [SetUp]
    public void Setup()
    {
        _socketClientMoq = new Mock<ISocketClient>();
        _socketClientMoq
            .Setup(e => e.Write(It.IsAny<byte[]>()))
            .Verifiable("Notification was not sent.");
    }
    
    
    [Test]
    public void PublishRegisterCustomer_Success()
    {
        var publisher = new Publisher.Publisher.Publisher<RegisterCustomerCommand>(_socketClientMoq.Object);
            
        publisher.PublishData(new RegisterCustomerCommand()
        {
            Entity = new Customer()
            {
                Name = "Test",
                Address = "Test Addr",
                PhoneNumber = "Test Phone"
            }
        });
        
        _socketClientMoq.Verify(x => x.Write(It.IsAny<byte[]>()), Times.Once());
    }
    
    [Test]
    public void PublishUpdateCustomer_Success()
    {
        var publisher = new Publisher.Publisher.Publisher<UpdateCustomerCommand>(_socketClientMoq.Object);
            
        publisher.PublishData(new UpdateCustomerCommand()
        {
            Entity = new Customer()
            {
                Name = "Test",
                Address = "Test Addr",
                PhoneNumber = "Test Phone"
            }
        });
        
        _socketClientMoq.Verify(x => x.Write(It.IsAny<byte[]>()), Times.Once());
    }
    
    [Test]
    public void PublishDeleteCustomer_Success()
    {
        var publisher = new Publisher.Publisher.Publisher<DeleteCustomerCommand>(_socketClientMoq.Object);
            
        publisher.PublishData(new DeleteCustomerCommand()
        {
            Entity = new Customer()
            {
                Name = "Test",
                Address = "Test Addr",
                PhoneNumber = "Test Phone"
            }
        });
        
        _socketClientMoq.Verify(x => x.Write(It.IsAny<byte[]>()), Times.Once());
    }
}