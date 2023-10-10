using Commands;
using CustomerAPI.Controllers;
using MediatR;
using Moq;

namespace Tests.APITests;

public class CustomerTests
{
    private Mock<IMediator> _mediatorMock;
    private CustomerController _customerController;
    [SetUp]
    public void Setup()
    {
        _mediatorMock = new Mock<IMediator>();
        _mediatorMock
            .Setup(e => e.Send(It.IsAny<CommandBase<Customer>>(), It.IsAny<CancellationToken>()))
            .Verifiable("Notification was not sent.");
        _customerController = new CustomerController(_mediatorMock.Object);
    }

    [Test]
    public void CreateCustomer_Success()
    {
        _customerController.CreateCustomer(new RegisterCustomerCommand()
        {
            Entity = new Customer()
            {
                Name = "Test",
                Address = "Test Addr",
                PhoneNumber = "Test Phone"
            }
        });
        
        _mediatorMock.Verify(x => x.Send(It.IsAny<RegisterCustomerCommand>(), default(CancellationToken)), Times.Once());
    }
    
    [Test]
    public void UpdateCustomer_Success()
    {
        _customerController.UpdateCustomer(Guid.NewGuid(), new UpdateCustomerCommand()
        {
            Entity = new Customer()
            {
                Name = "Test",
                Address = "Test Addr",
                PhoneNumber = "Test Phone"
            }
        });
        
        _mediatorMock.Verify(x => x.Send(It.IsAny<UpdateCustomerCommand>(), default(CancellationToken)), Times.Once());
    }
    
    [Test]
    public void DeleteCustomer_Success()
    {
        _customerController.DeleteCustomer(Guid.NewGuid(), new DeleteCustomerCommand()
        {
            Entity = new Customer()
            {
                Name = "Test",
                Address = "Test Addr",
                PhoneNumber = "Test Phone"
            }
        });
        
        _mediatorMock.Verify(x => x.Send(It.IsAny<DeleteCustomerCommand>(), default(CancellationToken)), Times.Once());
    }
}