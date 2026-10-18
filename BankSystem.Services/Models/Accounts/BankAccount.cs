using BankSystem.Services.Generators;

namespace BankSystem.Services.Models.Accounts;

public abstract class BankAccount
{
    private readonly List<AccountCashOperation> _operations = [];
    private readonly IReadOnlyList<AccountCashOperation> _readOnlyOperations;

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
        this.Deposit(initialBalance, DateTime.UtcNow, "Initial balance");
    }

    protected BankAccount(AccountOwner owner,
        string currencyCode,
        Func<string> numberGenerator,
        decimal initialBalance) : this(owner, currencyCode, numberGenerator)
    {
        this.Deposit(initialBalance, DateTime.UtcNow, "Initial balance");
    }

    private BankAccount(AccountOwner owner, string currencyCode)
    {
        ArgumentNullException.ThrowIfNull(owner);

        this.AccountOwner = owner;
        this.CurrencyCode = currencyCode;

        owner.Add(this);

        this._readOnlyOperations = this._operations.AsReadOnly();
    }

    public IReadOnlyList<AccountCashOperation> GetAllOperations()
    {
        return this._readOnlyOperations;
    }

    public void Deposit(decimal amount, DateTime date, string note)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(amount);

        this.Balance += amount;

        AccountCashOperation operation = new AccountCashOperation(amount, date, note);
        this._operations.Add(operation);

        // здесь явное приведение к инт, так как это общее место вызова функции которая рассчитывает бонус и там есть округление
        // но я не уверен оставить приведение тут, или поставить в каждом из методов расчета бонуса, ибо будет много дублирования
        this.BonusPoints += (int)this.CalculateDepositBonusPoints(amount);
    }

    public void Withdraw(decimal amount, DateTime date, string note)
    {
        ArgumentOutOfRangeException.ThrowIfGreaterThan(amount, this.Balance + this.Overdraft);

        this.Balance -= amount;

        AccountCashOperation operation = new AccountCashOperation(-amount, date, note);
        this._operations.Add(operation);

        this.BonusPoints += (int)this.CalculateWithdrawBonusPoints(amount);
    }

    public override string ToString()
    {
        return $"{this.Overdraft} {this.AccountOwner} No:{this.Number}. Balance: {this.Balance}{this.CurrencyCode}. \n";
    }

    // не понятно насчет того что возвращают, но думаю пока будет decimal, дабы не делать в каждом из наследников приведение к int
    protected abstract decimal CalculateDepositBonusPoints(decimal deposit);

    protected abstract decimal CalculateWithdrawBonusPoints(decimal withdraw);
}
