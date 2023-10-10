using MessageBroker;
using Ninject;

public class SocketBroker
{
    public static void Main(string[] args)
    {
        SocketServer server = new SocketServer();
        server.Start();
    }
}