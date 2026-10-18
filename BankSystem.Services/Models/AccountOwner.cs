using BankSystem.Services.Models.Accounts;

namespace BankSystem.Services.Models;

public class AccountOwner
{
    private readonly List<BankAccount> _accounts = [];
    private readonly IReadOnlyList<BankAccount> _readOnlyAccounts;
    public string Firstname { get; set; }
    public string Lastname { get; set; }
    public string Email { get; set; }

    public AccountOwner(string firstname, string lastname, string email)
    {
        this.Firstname = firstname;
        this.Lastname = lastname;
        this.Email = email;

        this._readOnlyAccounts = this._accounts.AsReadOnly();
    }

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
}
