using MediatR;

namespace Commands;

public class RegisterCustomerCommand: CommandBase<Customer>, IRequest<Customer>
{
    
}