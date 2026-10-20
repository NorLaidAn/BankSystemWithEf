using BankSystem.Services.Generators;

namespace BankSystem.Services.Models.Accounts;

public class GoldAccount : BankAccount
{
    #region Fields

    private const decimal GoldDepositCostPerPoint = 10;
    private const decimal GoldWithdrawCostPerPoint = 5;
    private const decimal GoldBalanceCostPerPoint = 5;

    #endregion

    #region Properties

    public override decimal Overdraft { get => 3 * this.BonusPoints; }

    #endregion

    #region Constructors

    public GoldAccount(
        AccountOwner owner,
        string currencyCode,
        IUniqueNumberGenerator uniqueNumberGenerator) : base(owner, currencyCode, uniqueNumberGenerator)
    {

    }

    public GoldAccount(
        AccountOwner owner,
        string currencyCode,
        Func<string> numberGenerator) : base(owner, currencyCode, numberGenerator)
    {

    }

    public GoldAccount(
        AccountOwner owner,
        string currencyCode,
        IUniqueNumberGenerator uniqueNumberGenerator,
        decimal initialBalance) : base(owner, currencyCode, uniqueNumberGenerator, initialBalance)
    {

    }

    public GoldAccount(
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
            Math.Ceiling(
                (this.Balance / GoldBalanceCostPerPoint) + (deposit / GoldDepositCostPerPoint)), 0);
    }

    protected override decimal CalculateWithdrawBonusPoints(decimal withdraw)
    {
        return Math.Max(
            Math.Ceiling(
                (this.Balance / GoldBalanceCostPerPoint) + (withdraw / GoldWithdrawCostPerPoint)), 0);
    }

    #endregion
}
