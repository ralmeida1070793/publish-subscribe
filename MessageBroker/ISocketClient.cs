namespace MessageBroker;

public interface ISocketClient
{
    void Write(byte[] data);
}