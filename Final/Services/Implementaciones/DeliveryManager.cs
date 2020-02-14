using Final.Domain.Envio;
using Final.Services.Interfaces;
using Final.Services.Messages;
using System;

namespace Final.Services.Implementaciones
{
    public class DeliveryManager : IDeliveryManager
    {
        private readonly ITimeChecker _timeChecker;
        private readonly ICalculadorDeFechaDeEntrega _calculadorDeFechaDeEntrega;


        public DeliveryManager(
            ITimeChecker timeChecker,
            ICalculadorDeFechaDeEntrega calculadorDeFechaDeEntrega)
        {
            _timeChecker = timeChecker;
            _calculadorDeFechaDeEntrega = calculadorDeFechaDeEntrega;
        }

        public PackageStatusResponse CheckPackageStatus(Package package)
        {
            DateTime fechaEntrega = _calculadorDeFechaDeEntrega.GetFechaEntrega(package);
            PackageStatus status = PackageStatus.enCamino;
            TimeCheckerResponse fechaEntregaCheckResponse = _timeChecker.CheckTime(fechaEntrega);
            //Si la fecha de entrega          
            if (fechaEntregaCheckResponse.Past)
            {
                status = PackageStatus.entregado;
            }
            return new PackageStatusResponse()
            {
                Status = status,
                TimeCheckerResponse = fechaEntregaCheckResponse
            };
        }
    }
}
