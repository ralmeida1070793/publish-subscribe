using Publisher;

namespace PublisherService;

public interface IPublishService
{
    void Publish(int value);
    void Publish(string value);
    void CreateNumberChannelSubscriber();
    void CreateTextChannelSubscriber();
    void NumberChannel(object sender, EventArguments<int> e);
    void TextChannel(object sender, EventArguments<string> e);
}