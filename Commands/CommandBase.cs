using MediatR;

namespace Commands;

public abstract class CommandBase<T>
{
    public T Entity { get; set; }
}