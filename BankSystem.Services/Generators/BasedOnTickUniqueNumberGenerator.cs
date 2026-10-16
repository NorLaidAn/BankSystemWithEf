using System.Globalization;
using BankSystem.Services.Helpers;

namespace BankSystem.Services.Generators;

public class BasedOnTickUniqueNumberGenerator : IUniqueNumberGenerator
{
    private DateTime startingPoint { get; }

    public BasedOnTickUniqueNumberGenerator(DateTime startingPoint)
    {
        this.startingPoint = startingPoint;
    }

    public string Generate()
    {
        return CryptoHelper.GenerateHash(
            (DateTime.UtcNow.Ticks - this.startingPoint.Ticks)
            .ToString(CultureInfo.InvariantCulture));
    }
}
