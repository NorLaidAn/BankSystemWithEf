using BankSystem.Services.Generators;

namespace BankSystem.Services.Models.Accounts;

public class StandardAccount : BankAccount
{
    #region Fields

    // не уверен пока с типом данных тут, но пусть будет decimal с перспективой на будущее
    private const decimal StandardBalanceCostPerPoint = 100;

    #endregion

    #region Properties

    public override decimal Overdraft { get => 0; }

    #endregion

    #region Constructors

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

    public StandardAccount(
        AccountOwner owner,
        string currencyCode,
        IUniqueNumberGenerator uniqueNumberGenerator,
        decimal initialBalance) : base(owner, currencyCode, uniqueNumberGenerator, initialBalance)
    {

    }

    public StandardAccount(
        AccountOwner owner,
        string currencyCode,
        Func<string> numberGenerator,
        decimal initialBalance) : base(owner, currencyCode, numberGenerator, initialBalance)
    {

    }

    #endregion

    #region Methods

    protected override decimal CalculateDepositBonusPoints(decimal deposit)
    {
        return Math.Max(
            Math.Floor(this.Balance / StandardBalanceCostPerPoint), 0);
    }

    protected override decimal CalculateWithdrawBonusPoints(decimal withdraw)
    {
        return Math.Max(
            Math.Floor(this.Balance / StandardBalanceCostPerPoint), 0);
    }

    #endregion
}
