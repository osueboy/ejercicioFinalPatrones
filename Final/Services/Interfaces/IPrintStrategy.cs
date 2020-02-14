using Final.Domain.Envio;
using Final.Services.Messages;

namespace Final.Services.Interfaces
{
    public interface IPrintStrategy
    {
        void Print(Package package, PackageStatusResponse packageStatusResponse);
    }
}
