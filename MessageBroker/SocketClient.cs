using System.Net.Sockets;

namespace MessageBroker;

public class SocketClient: SocketBase, ISocketClient
{
    public SocketClient() : base()
    {}

    public void Write(byte[] data)
    {
        byte[] bytes = new byte[1024];

        try
        {
            // Create a TCP/IP  socket.
            Socket sender = new Socket(
                ipAddress.AddressFamily,
                SocketType.Stream, 
                ProtocolType.Tcp
            );

            // Connect the socket to the remote endpoint. Catch any errors.
            try
            {
                // Connect to Remote EndPoint
                sender.Connect(localEndPoint);

                Console.WriteLine(
                    "Socket connected to {0}",
                    sender.RemoteEndPoint.ToString()
                );

                // Send the data through the socket.
                sender.Send(data);

                // Release the socket.
                sender.Shutdown(SocketShutdown.Both);
                sender.Close();

            }
            catch (ArgumentNullException ane)
            {
                Console.WriteLine("ArgumentNullException : {0}", ane.ToString());
            }
            catch (SocketException se)
            {
                Console.WriteLine("SocketException : {0}", se.ToString());
            }
            catch (Exception e)
            {
                Console.WriteLine("Unexpected exception : {0}", e.ToString());
            }

        }
        catch (Exception e)
        {
            Console.WriteLine(e.ToString());
        }
    }
}