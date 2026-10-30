using BankSystem.EF.Entities;
using BankSystem.Services.Models;

namespace BankSystem.Services.Services;

public class OwnerService : BaseService
{
    public OwnerService(BankContext context) : base(context)
    {

    }

    public IReadOnlyList<AccountOwnerTotalBalanceModel> GetAccountOwnersTotalBalance()
    {
        var accounts = this.Context.BankAccounts
        .GroupBy(account => new
        {
            account.AccountOwner.Id,
            account.AccountOwner.FirstName,
            account.AccountOwner.LastName,
            account.CurrencyCode.CurrenciesCode
        })
        .Select(group => new AccountOwnerTotalBalanceModel
        {
            AccountOwnerId = group.Key.Id,
            FirstName = group.Key.FirstName,
            LastName = group.Key.LastName,
            CurrencyCode = group.Key.CurrenciesCode,
            Total = group.Sum(account => account.Balance)
        })
        // без понятия как оно тут чинит ошибку формата изза которй не проходил тест, но нейронка говорит что просто отделяет сортировку от скюл и делает на дот нете, а то в скюл там не стоит инвариант культура
        .ToList()
        .OrderByDescending(owner => owner.Total)
        .ToList();

        return accounts;
    }
}
