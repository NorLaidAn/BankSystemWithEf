using BankSystem.EF.Entities;

namespace BankSystem.Services.Services;

public class BaseService : IDisposable
{
    private bool _dispose;

    protected BankContext Context { get; set; }

    public BaseService(BankContext bankContext)
    {
        this.Context = bankContext;
    }

    public void Dispose()
    {
        this.Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (this._dispose)
        {
            return;
        }

        if (disposing)
        {
            this.Context.Dispose();
        }

        this._dispose = true;
    }
}
