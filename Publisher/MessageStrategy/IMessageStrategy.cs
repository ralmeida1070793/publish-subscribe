namespace Publisher.MessageStrategy;

public interface IMessageStrategy<T>
{
    T Transform(T data);
}