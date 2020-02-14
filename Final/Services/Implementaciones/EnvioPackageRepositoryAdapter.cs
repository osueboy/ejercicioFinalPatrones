using Final.Domain;
using Final.Domain.Envio;
using Final.Domain.Medios;
using Final.Services.Interfaces;
using System;
using System.Collections.Generic;

namespace Final.Services.Implementaciones
{
    public class EnvioPackageRepositoryAdapter : IPackageRepository
    {
        private IEnviosRepository _envioRepository;
        private Dictionary<string, IEnvioFactory> _factories = new Dictionary<string, IEnvioFactory>();
        public EnvioPackageRepositoryAdapter(IEnviosRepository enviosRepository)
        {
            _envioRepository = enviosRepository;
        }
        public List<Package> GetPackages()
        {
            List<string> lines = _envioRepository.GetEnvios();
            List<Package> packages = new List<Package>();
            foreach(string line in lines)
            {
                string[] split = line.Split(',');
                string origen = split[0];
                string destino = split[1];
                int distancia = int.Parse(split[2]);
                string empresa = split[3].ToLower();
                string medioTransporte = split[4].ToLower();
                DateTime fechaPedido = DateParser.ParseDate(split[5]);

                if(_factories.TryGetValue(empresa, out IEnvioFactory envioFactory))
                {
                    switch (medioTransporte)
                    {
                        case TiposTransporte.Avion:
                            ManageAvion(packages, origen, destino, distancia, fechaPedido, envioFactory);
                            break;
                        case TiposTransporte.Tren:
                            ManageTren(packages, origen, destino, distancia, fechaPedido, envioFactory);
                            break;
                        case TiposTransporte.Barco:
                            ManageBarco(packages, origen, destino, distancia, fechaPedido, envioFactory);
                            break;
                    }
                }
                else
                {
                    //Null company
                    packages.Add(new Package()
                    {
                        Origen = origen, Destino = destino, Distancia = distancia, Empresa = null, 
                        MedioTransporte = null, FechaRecepcion = fechaPedido, UnSupportedCompany = empresa
                    });
                }
            }
            return packages;
        }

        private static void ManageBarco(List<Package> packages, string origen, string destino, int distancia, DateTime fechaPedido, IEnvioFactory envioFactory)
        {
            if (envioFactory is ICreateBarcoFactory createBarcoFactory)
            {
                packages.Add(createBarcoFactory.CreateBarcoPackage(origen, destino, distancia, fechaPedido));
            }
            else
            {
                AddUnsupportedMedio(packages, origen, destino, distancia, fechaPedido, new Barco(), envioFactory);
            }
        }

        private static void ManageTren(List<Package> packages, string origen, string destino, int distancia, DateTime fechaPedido, IEnvioFactory envioFactory)
        {
            if (envioFactory is ICreateTrenFactory createTrenFactory)
            {
                packages.Add(createTrenFactory.CreateTrenPackage(origen, destino, distancia, fechaPedido));
            }
            else
            {
                AddUnsupportedMedio(packages, origen, destino, distancia, fechaPedido,new Tren(), envioFactory);
            }
        }

        private static void ManageAvion(List<Package> packages, string origen, string destino, int distancia, DateTime fechaPedido, IEnvioFactory envioFactory)
        {
            if (envioFactory is ICreateAvionFactory createAvionFactory)
            {
                packages.Add(createAvionFactory.CreateAvionPackage(origen, destino, distancia, fechaPedido));
            }
            else
            {
                AddUnsupportedMedio(packages, origen, destino, distancia, fechaPedido, new Avion(), envioFactory);
            }
        }

        private static void AddUnsupportedMedio(List<Package> packages, string origen, string destino, double distancia, DateTime fechaPedido, IMedioTransporte unsupportedMedio, IEnvioFactory envioFactory)
        {
            packages.Add(new Package()
            {
                Origen = origen, Destino = destino, Distancia = distancia, Empresa = envioFactory.DeliveryCompany,
                MedioTransporte = unsupportedMedio, IsSupported = false, FechaRecepcion = fechaPedido
            });
        }

        public void AddFactory(IEnvioFactory envioFactory)
        {
            _factories.Add(envioFactory.DeliveryCompany.Name, envioFactory);
        }
    }
}
