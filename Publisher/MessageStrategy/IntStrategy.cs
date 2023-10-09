namespace Publisher.MessageStrategy;

public class IntStrategy : IMessageStrategy<int>
{
    public int Transform(int data)
    {
        return data;
    }
}