using Final.Domain.Envio;
using Final.Services.Interfaces;
using Final.Services.Messages;

namespace Final.Services.Implementaciones
{
    public class ReporteadorDePedidos : BaseReporteadorDePedidos
    {
        private readonly IPackageRepository _packageRepository;
        private readonly IDeliveryMessagePrinter _deliveryMessagePrinter;
        private readonly IDeliveryManager _deliveryManager;
        public ReporteadorDePedidos(
            IPackageRepository packageRepository,
            IDeliveryMessagePrinter deliveryMessagePrinter,
            IDeliveryManager deliveryManager
            )
        {
            _packageRepository = packageRepository;
            _deliveryMessagePrinter = deliveryMessagePrinter;
            _deliveryManager = deliveryManager;
        } 
        public override void ReportAll()
        {
            SetPackages(_packageRepository.GetPackages());
            foreach (Package package in _packages)
            {
                ReportPackage(package);
            }
        }

        public override void ReportPackage(Package package)
        {
            if (package.IsSupported)
            {
                if (package.Empresa == null)
                {
                    _strategies.TryGetValue(PackageStatus.unsupported, out IPrintStrategy printStrategy);
                    DoPrint(package, printStrategy, null);
                }
                else
                {
                    PackageStatusResponse packageStatusResponse = _deliveryManager.CheckPackageStatus(package);
                    _strategies.TryGetValue(packageStatusResponse.Status, out IPrintStrategy printStrategy);
                    DoPrint(package, printStrategy, packageStatusResponse);
                }
            }
            else
            {
                _strategies.TryGetValue(PackageStatus.unknown, out IPrintStrategy printStrategy);
                DoPrint(package, printStrategy, null);
            }
        }

        private void DoPrint(Package package, IPrintStrategy printStrategy, PackageStatusResponse statusResponse)
        {
            _deliveryMessagePrinter.PrintStrategy = printStrategy;
            _deliveryMessagePrinter.PrintMessage(package, statusResponse);
        }
    }
}
