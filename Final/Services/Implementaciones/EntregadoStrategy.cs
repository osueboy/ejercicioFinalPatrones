using Final.Domain.Envio;
using Final.Services.Interfaces;
using Final.Services.Messages;
using System;

namespace Final.Services.Implementaciones
{
    public class EntregadoStrategy : IPrintStrategy
    {
        private IRangoDeTiempoProvider _rangoDeTiempoProvider;
        private ICalculadorCostoEnvio _calculadorCostoEnvio;
        private const string Expression1 = "salió";
        private const string Expression2 = "llegó";
        private const string Expression3 = "hace";
        private const string Expression4 = "tuvo";

        private const string Template = "Tu Paquete {0} de {1} y {2} a {3} {4} {5} y {6} un costo de {7} (Cualquier reclamación con {8})";
        //[Expresión1] de[Origen] y[Expresión2] a[Destino][Expresión3] [Rango de Tiempo] y[Expresión4] un costo de[Costode envío] (Cualquier reclamación con[Paquetería])


        public EntregadoStrategy(IRangoDeTiempoProvider rangoDeTiempoProvider, ICalculadorCostoEnvio calculadorCostoEnvio)
        {
            _rangoDeTiempoProvider = rangoDeTiempoProvider;
            _calculadorCostoEnvio = calculadorCostoEnvio;
        }

        public void Print(Package package, PackageStatusResponse packageStatusResponse)
        {
            RangoResponse rangoResponse = _rangoDeTiempoProvider.GetValorPorRango(packageStatusResponse.TimeCheckerResponse.TimePast);
            decimal costoEnvio = _calculadorCostoEnvio.ObtenerCostoEnvio(package);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(string.Format(Template,
                Expression1,
                package.Origen,
                Expression2,
                package.Destino,
                Expression3,
                rangoResponse.Valor + " " + rangoResponse.Rango,
                Expression4,
                costoEnvio,
                package.Empresa.Name
                ));
            Console.ResetColor();
        }
    }
}
