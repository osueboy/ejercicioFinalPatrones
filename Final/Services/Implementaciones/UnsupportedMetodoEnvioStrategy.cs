using Final.Domain.Envio;
using Final.Services.Interfaces;
using Final.Services.Messages;
using System;

namespace Final.Services.Implementaciones
{
    public class UnsupportedMetodoEnvioStrategy : IPrintStrategy
    {
        private const string _template = "{0} no ofrece {1}, te recomendamos cotizar en otra empresa";
        public void Print(Package package, PackageStatusResponse packageStatusResponse)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(string.Format(_template, package.Empresa.Name, package.MedioTransporte));
            Console.ResetColor();
        }
    }
}
