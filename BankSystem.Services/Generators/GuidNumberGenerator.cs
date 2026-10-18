using BankSystem.Services.Helpers;

namespace BankSystem.Services.Generators;

public class GuidNumberGenerator : IUniqueNumberGenerator
{
    #region Methods

    public string Generate()
    {
        return CryptoHelper.GenerateHash(
            Guid.NewGuid().ToString());
    }

    #endregion
}
