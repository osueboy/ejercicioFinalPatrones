using Final.Domain.Envio;
using Final.Services.Messages;

namespace Final.Services.Interfaces
{
    public interface IDeliveryMessagePrinter
    {
        IPrintStrategy PrintStrategy { get; set; }
        void PrintMessage(Package package, PackageStatusResponse statusResponse);
    }
}
