using Commands;
using MediatR;

namespace CustomerAPI.CommandHandlers;

public class DeleteCustomerCommandHandler: IRequestHandler<DeleteCustomerCommand>
{
    private static Publisher.Publisher.IPublisher<DeleteCustomerCommand> _publisher;

    public DeleteCustomerCommandHandler(
        Publisher.Publisher.IPublisher<DeleteCustomerCommand> publisher
    )
    {
        _publisher = publisher;
    }
    
    public async Task Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
    {
        _publisher.PublishData(request);
    }
}