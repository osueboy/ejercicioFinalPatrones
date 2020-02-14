using Final.Domain.Empresas;
using Final.Domain.Envio;
using Final.Services.Messages;

namespace Final.Services.Interfaces
{
    public interface IReporteadorDePedidos
    {
        

        void ReportAll();
        void ReportPackage(Package package);
        void AddStrategy(PackageStatus status, IPrintStrategy printStrategy);
        void AddEmpresa(IDeliveryCompany deliveryCompany);
    }
}
