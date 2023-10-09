using Ninject.Modules;
using Publisher;
using Publisher.MessageStrategy;

namespace PublisherService;

public class NinjectModuleOverrides: NinjectModule
{
    /// <summary>
    /// Overrding Load method and adding baindings for DI to take into account
    /// </summary>
    public override void Load()
    {
        Bind<IPublisher<int>>().To<Publisher<int>>();
        Bind<IPublisher<string>>().To<Publisher<string>>();
        Bind<IMessageStrategy<int>>().To<IntStrategy>();
        Bind<IMessageStrategy<string>>().To<StringStrategy>();
        Bind<MessageTransform<string>>().ToSelf().InSingletonScope();
        Bind<MessageTransform<int>>().ToSelf().InSingletonScope();
    }
}