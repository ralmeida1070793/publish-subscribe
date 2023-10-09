using Moq;
using Publisher;
using Publisher.MessageStrategy;

namespace Tests;

public class PublisherTests
{
    private Mock<IMessageStrategy<string>> _stringTransformStrategy;
    private Mock<IMessageStrategy<int>> _intTransformStrategy;
    
    [SetUp]
    public void Setup()
    {
        _stringTransformStrategy = new Mock<IMessageStrategy<string>>();
        _intTransformStrategy = new Mock<IMessageStrategy<int>>();
    }

    [Test]
    public void TestTransformString_Success()
    {
        Publisher<string> publisher = new Publisher<string>(new MessageTransform<string>(_stringTransformStrategy.Object));
        publisher.PublishData("Test");
        _stringTransformStrategy.Verify(e => e.Transform(It.IsAny<string>()), Times.Exactly(1));
    }
    
    [Test]
    public void TestTransformInt_Success()
    {
        Publisher<int> publisher = new Publisher<int>(new MessageTransform<int>(_intTransformStrategy.Object));
        publisher.PublishData(1);
        _intTransformStrategy.Verify(e => e.Transform(It.IsAny<int>()), Times.Exactly(1));
    }
}