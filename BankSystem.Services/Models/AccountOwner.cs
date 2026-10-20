using BankSystem.Services.Models.Accounts;
using BankSystem.Services.Helpers;

namespace BankSystem.Services.Models;

public class AccountOwner
{
    #region Fields

    private readonly List<BankAccount> _accounts = [];
    private readonly IReadOnlyList<BankAccount> _readOnlyAccounts;

    #endregion

    #region Properties

    public string Firstname
    {
        get;
        private set => field = value.ValidateStringNotNullOrEmptyOrWhiteSpace(nameof(this.Firstname));
    }
    public string Lastname
    {
        get;
        private set => field = value.ValidateStringNotNullOrEmptyOrWhiteSpace(nameof(this.Lastname));
    }
    public string Email
    {
        get;
        private set
        {
            if (!value.IsEmailValid())
            {
                throw new ArgumentException("Invalid email address.", nameof(value));
            }

            field = value;
        }
    }

    #endregion

    #region Constructors

    public AccountOwner(string firstname, string lastname, string email)
    {
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
