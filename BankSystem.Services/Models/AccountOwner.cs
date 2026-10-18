using BankSystem.Services.Models.Accounts;

namespace BankSystem.Services.Models;

public class AccountOwner
{
    #region Fields

    private readonly List<BankAccount> _accounts = [];
    private readonly IReadOnlyList<BankAccount> _readOnlyAccounts;

    #endregion

    #region Properties

    public string Firstname { get; set; }
    public string Lastname { get; set; }
    public string Email { get; set; }

    #endregion

    #region Constructors

    public AccountOwner(string firstname, string lastname, string email)
    {
        // вообще так предполагаю для проверок создается отдельынй хелппер статик класс с определенного рода проверками значений, но предположу что нам здесь это излишне
        ArgumentNullException.ThrowIfNull(firstname);
        ArgumentNullException.ThrowIfNull(lastname);
        ArgumentNullException.ThrowIfNull(email);

        this.Firstname = firstname;
        this.Lastname = lastname;
        this.Email = email;

        this._readOnlyAccounts = this._accounts.AsReadOnly();
    }

    #endregion

    #region Methods

    public override string ToString()
    {
        return $"{this.Firstname} {this.Lastname}, {this.Email}.";
    }

    public void Add(BankAccount accountToAdd)
    {
        this._accounts.Add(accountToAdd);
    }

    public IReadOnlyList<BankAccount> Accounts()
    {
        return this._readOnlyAccounts;
    }

    #endregion
}
