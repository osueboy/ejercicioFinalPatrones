using Final.Domain.Envio;
using Final.Services.Interfaces;
using Final.Services.Messages;
using System;

namespace Final.Services.Implementaciones
{
    public class DeliveryMessagePrinter : IDeliveryMessagePrinter
    {
        public IPrintStrategy PrintStrategy { get; set; }
        public void PrintMessage(Package package, PackageStatusResponse statusResponse)
        {
            if(PrintStrategy == null)
            {
                throw new Exception("No se definió la estrategia de impresion");
            }
            PrintStrategy.Print(package, statusResponse);
        }
    }
}
