using Commands;
using MediatR;

namespace CustomerAPI.CommandHandlers;

public class RegisterCustomerCommandHandler: IRequestHandler<RegisterCustomerCommand, Customer>
{
    private static Publisher.Publisher.IPublisher<RegisterCustomerCommand> _publisher;

    public RegisterCustomerCommandHandler(
        Publisher.Publisher.IPublisher<RegisterCustomerCommand> publisher
    )
    {
        _publisher = publisher;
    }
    
    public async Task<Customer> Handle(RegisterCustomerCommand request, CancellationToken cancellationToken)
    {
        _publisher.PublishData(request);
        return request.Entity;
    }
}