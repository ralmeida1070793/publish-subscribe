using Publisher.MessageStrategy;

namespace Publisher;

public class MessageTransform<T>
{
    private readonly IMessageStrategy<T> _strategy;

    public MessageTransform(
        IMessageStrategy<T> strategy
    )
    {
        _strategy = strategy;
    }
    
    public T Transform(T data)
    {
        return _strategy.Transform(data);
    }
}