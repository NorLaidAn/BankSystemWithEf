using BankSystem.Services.Generators;

namespace BankSystem.Services.Models.Accounts;

public class StandardAccount : BankAccount
{
    private const decimal StandardBalanceCostPerPoint = 100; // не уверен пока с типом данных тут, но пусть будет decimal с перспективой на будущее

    public override decimal Overdraft { get => 0; }

    public StandardAccount(
        AccountOwner owner,
        string currencyCode,
        IUniqueNumberGenerator uniqueNumberGenerator) : base(owner, currencyCode, uniqueNumberGenerator)
    {

    }

    public StandardAccount(
        AccountOwner owner,
        string currencyCode,
        Func<string> numberGenerator) : base(owner, currencyCode, numberGenerator)
    {

    }

    public StandardAccount(AccountOwner owner,
        string currencyCode,
        IUniqueNumberGenerator uniqueNumberGenerator,
        decimal initialBalance) : base(owner, currencyCode, uniqueNumberGenerator, initialBalance)
    {

    }

    public StandardAccount(AccountOwner owner,
        string currencyCode,
        Func<string> numberGenerator,
        decimal initialBalance) : base(owner, currencyCode, numberGenerator, initialBalance)
    {

    }

    // в этих 2 функциях пока не понятно, в описании указано что они должны принимать decimal amount, но при этом в указанной формуле не учавствует, пока будет так
    // бонусом не понятно насчет того что возвращают, но думаю пока обычный ретурн сойдет
    public override decimal CalculateDepositBonusPoints()
    {
        return Math.Max(Math.Floor(this.Balance / StandardBalanceCostPerPoint), 0);
    }

    public override decimal CalculateWithdrawBonusPoints()
    {
        return Math.Max(Math.Floor(this.Balance / StandardBalanceCostPerPoint), 0);
    }
}
