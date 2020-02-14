using Final.Domain.Envio;
using Final.Services.Messages;

namespace Final.Services.Interfaces
{
    public interface IDeliveryManager 
    {
        PackageStatusResponse CheckPackageStatus(Package package);
    }
}
