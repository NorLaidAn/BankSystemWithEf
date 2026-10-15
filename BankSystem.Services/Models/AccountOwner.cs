namespace BankSystem.Services.Models;

internal class AccountOwner
{
    private string Firstname { get; set; }
    private string Lastname { get; set; }
    private string Email { get; set; }

    public AccountOwner(string firstname, string lastname, string email)
    {
        this.Firstname = firstname;
        this.Lastname = lastname;
        this.Email = email;
    }

    public override string ToString()
    {
        return $"{this.Firstname} {this.Lastname}, {this.Email}.";
    }

    public void Add()
    {
        throw new NotImplementedException();
    }

    public void Accounts()
    {
        throw new NotImplementedException();
    }
}
