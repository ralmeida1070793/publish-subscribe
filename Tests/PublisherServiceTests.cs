using Moq;
using Publisher;
using PublisherService;

namespace Tests;

public class PublisherServiceTests
{
    private Mock<IPublisher<int>> _intPublisher;
    private Mock<IPublisher<string>> _stringPublisher;
    private IPublishService _publishLogic; 

    [SetUp]
    public void Initialize()
    {
        _intPublisher = new Mock<IPublisher<int>>();
        _stringPublisher = new Mock<IPublisher<string>>();
        _publishLogic = new PublishService(_intPublisher.Object, _stringPublisher.Object);
    }

    [Test]
    public void PublishInt_success()
    {
        _intPublisher.Setup(p => p.PublishData(It.IsAny<int>())).Raises(i => i.EventPublisher += null, new EventArguments<int>(5));
        _publishLogic.Publish(5);
        _intPublisher.Verify(e => e.PublishData(It.IsAny<int>()), Times.Exactly(1));

    }
    
    [Test]
    public void PublishString_success()
    {
        _stringPublisher.Setup(p => p.PublishData(It.IsAny<string>())).Raises(i => i.EventPublisher += null, new EventArguments<string>("Test"));
        _publishLogic.Publish("Test");
        _stringPublisher.Verify(e => e.PublishData(It.IsAny<string>()), Times.Exactly(1));

    }
}