using System.Globalization;

namespace BankSystem.Services.Models;

public class AccountCashOperation
{
    private decimal Amount { get; set; }
    private DateTime Date { get; set; }
    private string Note { get; set; }

    public AccountCashOperation(decimal amount, DateTime date, string note)
    {
        this.Amount = amount;
        this.Date = date;
        this.Note = note;
    }

    public override string ToString()
    {
        string operation = this.Amount >= 0 ? "Credited to account" : "Debited from account";

        return string.Format(CultureInfo.InvariantCulture, "{0:MM/dd/yyyy HH:mm:ss} {1} : {2} {3}", this.Date, this.Note, operation, this.Amount);
    }
}
