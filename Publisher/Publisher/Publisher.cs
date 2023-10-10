using System.Text.Json;
using MessageBroker;

namespace Publisher.Publisher;

public class Publisher<T> : IPublisher<T>
{
    private ISocketClient _socketClient;

    public Publisher(
        ISocketClient socketClient
    )
    {
        _socketClient = socketClient;
    }
    
    public void PublishData(T message)
    {
        _socketClient.Write(System.Text.Encoding.ASCII.GetBytes(typeof(T).Name + "|" + JsonSerializer.Serialize(message)));
    }
}