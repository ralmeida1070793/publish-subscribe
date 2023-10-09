namespace Publisher.MessageStrategy;

public class StringStrategy : IMessageStrategy<string>
{
    public string Transform(string data)
    {
        return data.ToUpper();
    }
}