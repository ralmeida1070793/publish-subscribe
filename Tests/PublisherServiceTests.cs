using Moq;
using Publisher;
using PublisherService;
using Subscribers;

namespace Tests;

public class PublisherServiceTests
{
    private Mock<IPublisher<int>> _intPublisher;
    private Mock<IMessagePresenter<int>> _intMessagePresenter;
    private Mock<IMessagePresenter<string>> _stringMessagePresenter;
    private Mock<IPublisher<string>> _stringPublisher;
    private IPublishService _publishLogic; 

    [SetUp]
    public void Initialize()
    {
        _intPublisher = new Mock<IPublisher<int>>();
        _stringPublisher = new Mock<IPublisher<string>>();
        _intMessagePresenter = new Mock<IMessagePresenter<int>>();
        _stringMessagePresenter = new Mock<IMessagePresenter<string>>();
        
        _publishLogic = new PublishService(
            _intPublisher.Object, 
            _stringPublisher.Object,
            _intMessagePresenter.Object,
            _stringMessagePresenter.Object
        );
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