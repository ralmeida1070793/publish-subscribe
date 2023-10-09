using Ninject.Modules;
using PublisherService;

namespace Client;

/// <summary>
/// Binding. In an API context, this would be done through a factory and dependency injection
/// </summary>
public class ConsoleNinjectModule : NinjectModule
{
    public override void Load()
    {
        Bind<IPublishService>().To<PublishService>();
    }
}