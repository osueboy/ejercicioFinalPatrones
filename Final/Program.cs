using Final.Domain.Empresas;
using Final.Services.Implementaciones;
using Final.Services.Interfaces;
using Final.Services.Messages;
using Microsoft.Extensions.DependencyInjection;

namespace Final
{
    class Program
    {
        static void Main(string[] args)
        {
            //setup our DI
            var serviceProvider = new ServiceCollection()
                .AddScoped(typeof(IClockReader), typeof(Clock))
                .AddScoped(typeof(IEnviosRepository), typeof(EnviosRepository))
                .AddScoped<IPackageRepository, EnvioPackageRepositoryAdapter>(x => {
                    EnvioPackageRepositoryAdapter envioPackageRepositoryAdapter =
                    new EnvioPackageRepositoryAdapter(x.GetRequiredService<IEnviosRepository>());
                    envioPackageRepositoryAdapter.AddFactory(new EstafetaEnviosFactory(new Estafeta()));
                    envioPackageRepositoryAdapter.AddFactory(new FedexEnviosFactory(new Fedex()));
                    envioPackageRepositoryAdapter.AddFactory(new DhlEnviosFactory(new Dhl()));
                    return envioPackageRepositoryAdapter;
                })
                .AddScoped(typeof(IRangoDeTiempoProvider), typeof(RangoDeTiempoProvider))
                .AddScoped(typeof(ITimeChecker), typeof(TimeChecker))
                .AddScoped(typeof(ICalculadorTiempoTraslado), typeof(CalculadorTiempoTraslado))
                .AddScoped(typeof(ICalculadorDeFechaDeEntrega), typeof(DefaultCalculadorFechaEntrega))
                .AddScoped(typeof(ICalculadorCostoEnvio), typeof(CalculadorCostoEnvio))
                .AddScoped(typeof(IDeliveryManager), typeof(DeliveryManager))
                .AddScoped(typeof(IDeliveryMessagePrinter), typeof(DeliveryMessagePrinter))
                .AddScoped(typeof(IReporteadorDePedidos), typeof(ReporteadorDePedidos))
                .BuildServiceProvider();
            IReporteadorDePedidos reporteadorDePedidos = serviceProvider.GetRequiredService<IReporteadorDePedidos>();
            IRangoDeTiempoProvider rangoDeTiempoProvider = serviceProvider.GetRequiredService<IRangoDeTiempoProvider>();
            ICalculadorCostoEnvio calculadorCostoEnvio = serviceProvider.GetRequiredService<ICalculadorCostoEnvio>();
            
            //Empresas
            Estafeta estafeta = new Estafeta();
            Fedex fedex = new Fedex();
            Dhl dhl = new Dhl();



            reporteadorDePedidos.AddEmpresa(estafeta);
            reporteadorDePedidos.AddEmpresa(fedex);
            reporteadorDePedidos.AddEmpresa(dhl);
            reporteadorDePedidos.AddStrategy(
                PackageStatus.entregado,
                new EntregadoStrategy(rangoDeTiempoProvider, calculadorCostoEnvio));
            reporteadorDePedidos.AddStrategy(
                PackageStatus.enCamino,
                new PorEntregarStrategy(rangoDeTiempoProvider, calculadorCostoEnvio));
            reporteadorDePedidos.AddStrategy(PackageStatus.unknown, new UnsupportedMetodoEnvioStrategy());
            reporteadorDePedidos.AddStrategy(PackageStatus.unsupported, new EmpresaDesconocidaStrategy());

            RecomendacionReporteadorPedidosDecorator recomendacionReporteadorPedidosDecorator =
                new RecomendacionReporteadorPedidosDecorator(reporteadorDePedidos, serviceProvider.GetRequiredService<IPackageRepository>(), serviceProvider.GetRequiredService<ICalculadorCostoEnvio>());

            recomendacionReporteadorPedidosDecorator.AddEmpresa(estafeta);
            recomendacionReporteadorPedidosDecorator.AddEmpresa(fedex);
            recomendacionReporteadorPedidosDecorator.AddEmpresa(dhl);
            recomendacionReporteadorPedidosDecorator.AddStrategy(
                PackageStatus.entregado,
                new EntregadoStrategy(rangoDeTiempoProvider, calculadorCostoEnvio));
            recomendacionReporteadorPedidosDecorator.AddStrategy(
                PackageStatus.enCamino,
                new PorEntregarStrategy(rangoDeTiempoProvider, calculadorCostoEnvio));
            recomendacionReporteadorPedidosDecorator.AddStrategy(PackageStatus.unknown, new UnsupportedMetodoEnvioStrategy());
            recomendacionReporteadorPedidosDecorator.AddStrategy(PackageStatus.unsupported, new EmpresaDesconocidaStrategy());

            recomendacionReporteadorPedidosDecorator.ReportAll();
        }
    }
}
