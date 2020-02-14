using Final.Domain.Empresas;
using System;

namespace Final.Domain.Envio
{
    public class Package
    {
        public double PesoEnKilos {get; set;} 
        public string Origen { get; set; }
        public string Destino { get; set; }
        public double Distancia { get; set; }
        public IMedioTransporte MedioTransporte { get; set; }
        public bool IsSupported { get; set; } = true;
        public IDeliveryCompany Empresa { get; set; }
        public DateTime FechaRecepcion { get; set; }
        public string UnSupportedCompany { get; set; }
    }
}
