using System.Text.Json;
using Commands;

namespace Subscriber.MessagePresenter;

public class MessagePresenter<T> : IMessagePresenter<T> where T: CommandBase<Customer>
{
    public void Present(object sender, EventArguments<T> e)
    {
        Console.WriteLine(sender.ToString());
        Console.WriteLine("\t" + e.Message.Entity.Name);
        Console.WriteLine("\t" + e.Message.Entity.Address);
        Console.WriteLine("\t" + e.Message.Entity.PhoneNumber);
    }
}