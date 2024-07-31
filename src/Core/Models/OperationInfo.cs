namespace Core.Models;

public class OperationInfo
{
    public OperationInfo(float change, long accountId)
    {
        Change = change;
        AccountId = accountId;
    }

    public long AccountId { get; }
    public float Change { get; }
}