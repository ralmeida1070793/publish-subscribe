using Commands;
using CustomerAPI.CommandHandlers;
using CustomerAPI.Controllers;
using MediatR;
using Moq;

namespace Tests.APITests;

public class CommandHandlerTests
{
    private Mock<Publisher.Publisher.IPublisher<RegisterCustomerCommand>> _registerPublisherMock;
    private Mock<Publisher.Publisher.IPublisher<UpdateCustomerCommand>> _updatePublisherMock;
    private Mock<Publisher.Publisher.IPublisher<DeleteCustomerCommand>> _deletePublisherMock;
    
    [SetUp]
    public void Setup()
    {
        _registerPublisherMock = new Mock<Publisher.Publisher.IPublisher<RegisterCustomerCommand>>();
        _registerPublisherMock
            .Setup(e => e.PublishData(It.IsAny<RegisterCustomerCommand>()))
            .Verifiable("Publish triggered.");
        
        _updatePublisherMock = new Mock<Publisher.Publisher.IPublisher<UpdateCustomerCommand>>();
        _updatePublisherMock
            .Setup(e => e.PublishData(It.IsAny<UpdateCustomerCommand>()))
            .Verifiable("Publish triggered.");
        
        _deletePublisherMock = new Mock<Publisher.Publisher.IPublisher<DeleteCustomerCommand>>();
        _deletePublisherMock
            .Setup(e => e.PublishData(It.IsAny<DeleteCustomerCommand>()))
            .Verifiable("Publish triggered.");
    }
    
    [Test]
    public void PublishCreateCustomer_Success()
    {
        var handler = new RegisterCustomerCommandHandler(_registerPublisherMock.Object);
            
        handler.Handle(new RegisterCustomerCommand()
        {
            Entity = new Customer()
            {
                Name = "Test",
                Address = "Test Addr",
                PhoneNumber = "Test Phone"
            }
        }, CancellationToken.None);
        
        _registerPublisherMock.Verify(x => x.PublishData(It.IsAny<RegisterCustomerCommand>()), Times.Once());
    }
    
    [Test]
    public void PublishUpdateCustomer_Success()
    {
        var handler = new UpdateCustomerCommandHandler(_updatePublisherMock.Object);
            
        handler.Handle(new UpdateCustomerCommand()
        {
            Entity = new Customer()
            {
                Name = "Test",
                Address = "Test Addr",
                PhoneNumber = "Test Phone"
            }
        }, CancellationToken.None);
        
        _updatePublisherMock.Verify(x => x.PublishData(It.IsAny<UpdateCustomerCommand>()), Times.Once());
    }
    
    [Test]
    public void PublishDeleteCustomer_Success()
    {
        var handler = new DeleteCustomerCommandHandler(_deletePublisherMock.Object);
            
        handler.Handle(new DeleteCustomerCommand()
        {
            Entity = new Customer()
            {
                Name = "Test",
                Address = "Test Addr",
                PhoneNumber = "Test Phone"
            }
        }, CancellationToken.None);
        
        _deletePublisherMock.Verify(x => x.PublishData(It.IsAny<DeleteCustomerCommand>()), Times.Once());
    }
    
}