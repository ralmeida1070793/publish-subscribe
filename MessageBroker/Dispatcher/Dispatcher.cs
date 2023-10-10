using System.Text.Json;
using Commands;
using Microsoft.Extensions.Configuration;
using Subscriber;
using Subscriber.MessagePresenter;

namespace MessageBroker.Dispatcher;

public class Dispatcher
{
    private EventDispatcher<RegisterCustomerCommand> RegisterEventDispacher;
    private EventDispatcher<UpdateCustomerCommand> UpdateEventDispacher;
    private EventDispatcher<DeleteCustomerCommand> DeleteEventDispacher;

    public Dispatcher()
    {
        
        RegisterEventDispacher = new EventDispatcher<RegisterCustomerCommand>();
        UpdateEventDispacher = new EventDispatcher<UpdateCustomerCommand>();
        DeleteEventDispacher = new EventDispatcher<DeleteCustomerCommand>();
        
        IConfigurationRoot config = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .AddEnvironmentVariables()
            .Build();
    
        int registerCustomerCommandConsumers = int.Parse(config.GetSection("Consumers:RegisterCustomerCommand").Value);
        int updateCustomerCommandConsumers = int.Parse(config.GetSection("Consumers:UpdateCustomerCommand").Value);
        int deleteCustomerCommandConsumers = int.Parse(config.GetSection("Consumers:DeleteCustomerCommand").Value);

        for (int i = 0; i < registerCustomerCommandConsumers; i++)
        {
            CreateRegisterChannelSubscriber();
        }
        
        for (int i = 0; i < updateCustomerCommandConsumers; i++)
        {
            CreateUpdateChannelSubscriber();
        }
        
        for (int i = 0; i < deleteCustomerCommandConsumers; i++)
        {
            CreateDeleteChannelSubscriber();
        }
    }
    
    public void Dispatch(string data)
    {
        var eventObject = data.Split("|");
        if (eventObject[0] == "RegisterCustomerCommand")
        {
            RegisterEventDispacher.Dispatch(JsonSerializer.Deserialize<RegisterCustomerCommand>(eventObject[1]));
        }
        else if (eventObject[1] == "UpdateCustomerCommand")
        {
            UpdateEventDispacher.Dispatch(JsonSerializer.Deserialize<UpdateCustomerCommand>(eventObject[1]));
        }
        else
        {
            DeleteEventDispacher.Dispatch(JsonSerializer.Deserialize<DeleteCustomerCommand>(eventObject[1]));
        }
    }

    private void CreateRegisterChannelSubscriber()
    {
        Subscriber<RegisterCustomerCommand> subscriber = new Subscriber<RegisterCustomerCommand>(RegisterEventDispacher, new MessagePresenter<RegisterCustomerCommand>());
        subscriber.Dispatcher.EventPublisher += subscriber.Print; //event method to listen publish data
    }
    
    private void CreateUpdateChannelSubscriber()
    {
        Subscriber<UpdateCustomerCommand> subscriber = new Subscriber<UpdateCustomerCommand>(UpdateEventDispacher, new MessagePresenter<UpdateCustomerCommand>());
        subscriber.Dispatcher.EventPublisher += subscriber.Print; //event method to listen publish data
    }
    
    private void CreateDeleteChannelSubscriber()
    {
        Subscriber<DeleteCustomerCommand> subscriber = new Subscriber<DeleteCustomerCommand>(DeleteEventDispacher, new MessagePresenter<DeleteCustomerCommand>());
        subscriber.Dispatcher.EventPublisher += subscriber.Print; //event method to listen publish data
    }
}