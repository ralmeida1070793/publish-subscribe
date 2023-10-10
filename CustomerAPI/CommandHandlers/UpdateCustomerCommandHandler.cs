using Commands;
using MediatR;

namespace CustomerAPI.CommandHandlers;

public class UpdateCustomerCommandHandler: IRequestHandler<UpdateCustomerCommand>
{
    private static Publisher.Publisher.IPublisher<UpdateCustomerCommand> _publisher;

    public UpdateCustomerCommandHandler(
        Publisher.Publisher.IPublisher<UpdateCustomerCommand> publisher
    )
    {
        _publisher = publisher;
    }
    
    public async Task Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
    {
        _publisher.PublishData(request);
    }
}