using Final.Domain.Empresas;
using Final.Domain.Envio;
using Final.Services.Interfaces;
using Final.Services.Messages;
using System.Collections.Generic;

namespace Final.Services.Implementaciones
{
    public abstract class BaseReporteadorDePedidos : IReporteadorDePedidos
    {
        protected Dictionary<PackageStatus, IPrintStrategy> _strategies = new Dictionary<PackageStatus, IPrintStrategy>();
        protected Dictionary<string, IDeliveryCompany> _deliveryCompanies = new Dictionary<string, IDeliveryCompany>();
        protected List<Package> _packages = new List<Package>();
        public void AddEmpresa(IDeliveryCompany deliveryCompany)
        {
            _deliveryCompanies.Add(deliveryCompany.Name, deliveryCompany);
        }
        public void AddStrategy(PackageStatus status, IPrintStrategy printStrategy)
        {
            _strategies.Add(status, printStrategy);
        }
        public abstract void ReportAll();
        public abstract void ReportPackage(Package package);



        public void SetPackages(List<Package> packages)
        {
            _packages = packages;
        }
    }
}
