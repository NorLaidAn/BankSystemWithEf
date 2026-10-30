using BankSystem.EF.Entities;
using BankSystem.Services.Models;

namespace BankSystem.Services.Services;

public class AccountService : BaseService
{
    public AccountService(BankContext context) : base(context)
    {

    }

    public IReadOnlyList<BankAccountFullInfoModel> GetBankAccountsFullInfo()
    {
        var accounts = this.Context.BankAccounts
            .Select(account => new BankAccountFullInfoModel
            {
                BankAccountId = account.Id,
                FirstName = account.AccountOwner.FirstName,
                LastName = account.AccountOwner.LastName,
                AccountNumber = account.Number,
                Balance = account.Balance,
                CurrencyCode = account.CurrencyCode.CurrenciesCode,
                BonusPoints = account.BonusPoints

            })
            .ToList();

        return accounts;
    }
}
