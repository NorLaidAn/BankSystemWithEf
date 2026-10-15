using BankSystem.Services.Generators;

namespace BankSystem.Services.Models.Accounts;

public abstract class BankAccount
{
    public string Number { get; protected set; }
    public decimal Balance { get; protected set; }
    public string CurrencyCode { get; protected set; }
    public AccountOwner AccountOwner { get; protected set; }
    public int BonusPoints { get; protected set; }
    public abstract decimal Overdraft { get; }

    protected BankAccount(
        AccountOwner owner,
        string currencyCode,
        IUniqueNumberGenerator uniqueNumberGenerator) : this(owner, currencyCode)
    {
        ArgumentNullException.ThrowIfNull(uniqueNumberGenerator);


        this.Number = uniqueNumberGenerator.Generate();
    }

    protected BankAccount(
        AccountOwner owner,
        string currencyCode,
        Func<string> numberGenerator) : this(owner, currencyCode)
    {
        ArgumentNullException.ThrowIfNull(numberGenerator);


        this.Number = numberGenerator();
    }

    protected BankAccount(AccountOwner owner,
        string currencyCode,
        IUniqueNumberGenerator uniqueNumberGenerator,
        decimal initialBalance) : this(owner, currencyCode, uniqueNumberGenerator)
    {
        this.Balance = initialBalance;
    }

    protected BankAccount(AccountOwner owner,
        string currencyCode,
        Func<string> numberGenerator,
        decimal initialBalance) : this(owner, currencyCode, numberGenerator)
    {
        this.Balance = initialBalance; // очень хотелось обойти дублирование тут, но не придумал как
    }

    private BankAccount(AccountOwner owner, string currencyCode)
    {
        this.AccountOwner = owner;
        this.CurrencyCode = currencyCode;
    }

    public void GetAllOperations()
    {
        throw new NotImplementedException();
    }

    public void Deposit(decimal amount, string note)
    {
        throw new NotImplementedException();
    }

    public void Withdraw(decimal amount, string note)
    {
        throw new NotImplementedException();
    }

    public override string ToString()
    {
        return $"{this.Overdraft} {this.AccountOwner} No:{this.Number}. Balance: {this.Balance}{this.CurrencyCode}. \n";
    }

    // не понятно насчет того что возвращают, но думаю пока будет decimal, а не вывод в консоль или что-то такое
    public abstract decimal CalculateDepositBonusPoints(decimal deposit);

    public abstract decimal CalculateWithdrawBonusPoints(decimal withdraw);
}
