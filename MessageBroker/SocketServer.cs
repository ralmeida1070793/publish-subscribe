using System.Net.Sockets;
using System.Text;

namespace MessageBroker;

public class SocketServer: SocketBase
{
    private Dispatcher.Dispatcher _dispatcher;

    public SocketServer() : base()
    {
        _dispatcher = new Dispatcher.Dispatcher();
    }

    public void Start()
    {
        try {

            // Create a Socket that will use Tcp protocol
            Socket listener = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            // A Socket must be associated with an endpoint using the Bind method
            listener.Bind(localEndPoint);
            // Specify how many requests a Socket can listen before it gives Server busy response.
            listener.Listen(1);

            Console.WriteLine("Waiting for a connection...");
            
            while (true)
            {
                Socket handler = listener.Accept();

                // Incoming data from the client.
                string data = null;
                byte[] bytes = null;
                
                bytes = new byte[1024];
                int bytesRec = handler.Receive(bytes);
                data += Encoding.ASCII.GetString(bytes, 0, bytesRec);
                
                Console.WriteLine("Message received : {0}", data);
                _dispatcher.Dispatch(data);
                Console.WriteLine("Message dispatched : {0}", data);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.ToString());
        }

        Console.WriteLine("\n Press any key to continue...");
        Console.ReadKey();
    }
}