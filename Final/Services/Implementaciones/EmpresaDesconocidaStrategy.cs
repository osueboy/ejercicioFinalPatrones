using Final.Domain.Envio;
using Final.Services.Interfaces;
using Final.Services.Messages;
using System;

namespace Final.Services.Implementaciones
{
    public class EmpresaDesconocidaStrategy : IPrintStrategy
    {
        private const string _template = "La paqueteria {0} no se encuentra registrada en nuestra red de distribución";
        public void Print(Package package, PackageStatusResponse packageStatusResponse)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(string.Format(_template, package.UnSupportedCompany));
            Console.ResetColor();
        }
    }
}
