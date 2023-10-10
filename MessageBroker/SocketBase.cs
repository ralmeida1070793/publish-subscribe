using System.Net;
using Microsoft.Extensions.Configuration;

namespace MessageBroker;

public abstract class SocketBase
{
    protected IPHostEntry host;
    protected IPAddress ipAddress;
    protected IPEndPoint localEndPoint;

    public SocketBase()
    {
        IConfigurationRoot config = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .AddEnvironmentVariables()
            .Build();
    
        string hostAddress = config.GetSection("Settings:HostName").Value;
        int port = int.Parse(config.GetSection("Settings:Port").Value);
    
        host = Dns.GetHostEntry(hostAddress);
        ipAddress = host.AddressList[0];
        localEndPoint = new IPEndPoint(ipAddress, port);
    }

}
