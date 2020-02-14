using Final.Domain.Envio;
using Final.Services.Interfaces;
using System.Collections.Generic;

namespace Final.Services.Implementaciones
{
    public interface IPackageRepository
    {
        List<Package> GetPackages();

        void AddFactory(IEnvioFactory envioFactory);
    }
}
