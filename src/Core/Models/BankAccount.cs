namespace Core.Models;

public class BankAccount
{
    public BankAccount(long id, int pin, float balance)
    {
        Pin = pin;
        Id = id;
        Balance = balance;
    }

    public long Id { get; }
    public float Balance { get; set; }
    public int Pin { get; }
}