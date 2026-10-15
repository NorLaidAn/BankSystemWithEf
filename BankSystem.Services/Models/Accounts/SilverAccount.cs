using BankSystem.Services.Generators;

namespace BankSystem.Services.Models.Accounts;

public class SilverAccount : BankAccount
{
    private const decimal SilverDepositCostPerPoint = 5;
    private const decimal SilverWithdrawCostPerPoint = 2;
    private const decimal SilverBalanceCostPerPoint = 100;

    public override decimal Overdraft { get => 2 * this.BonusPoints; }

    public SilverAccount(
        AccountOwner owner,
        string currencyCode,
        IUniqueNumberGenerator uniqueNumberGenerator) : base(owner, currencyCode, uniqueNumberGenerator)
    {

    }

    public SilverAccount(
        AccountOwner owner,
        string currencyCode,
        Func<string> numberGenerator) : base(owner, currencyCode, numberGenerator)
    {

    }

    public SilverAccount(
        AccountOwner owner,
        string currencyCode,
        IUniqueNumberGenerator uniqueNumberGenerator,
        decimal initialBalance) : base(owner, currencyCode, uniqueNumberGenerator, initialBalance)
    {

    }

    public SilverAccount(
        AccountOwner owner,
        string currencyCode,
        Func<string> numberGenerator,
        decimal initialBalance) : base(owner, currencyCode, numberGenerator, initialBalance)
    {

    }

    public override decimal CalculateDepositBonusPoints(decimal deposit)
    {
        return Math.Max(
            Math.Floor(
                (this.Balance / SilverBalanceCostPerPoint) + (deposit / SilverDepositCostPerPoint)), 0);
    }

    public override decimal CalculateWithdrawBonusPoints(decimal withdraw)
    {
        return Math.Max(
            Math.Floor(
                (this.Balance / SilverBalanceCostPerPoint) + (withdraw / SilverWithdrawCostPerPoint)), 0);
    }
}
