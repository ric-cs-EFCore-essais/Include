using Microsoft.Extensions.DependencyInjection;

using Application.UseCases.Interfaces.Ports;

using Application.UseCases.Ports.GetPort;
using Domain.UnitsOfWork.Interfaces.Ports;
using Infra.UnitsOfWork.Factories.Ports;
using Application.UseCases.Ports.GetPorts;
using System;
using Infra.Controllers.Ports;
using Infra.Controllers.Interfaces.Ports;
using Infra.DataContext.EF.Interfaces;
using Infra.DataContext.EF.Ports;
using Infra.DependenciesInjection.Ports.Factories;

namespace Infra.DependenciesInjection.Ports
{
    public class DependenciesInjectionConfiguration
    {
        private readonly bool EF_Mode = true;

        private static DependenciesInjectionConfiguration dependenciesInjectionConfiguration;

        private readonly IServiceCollection servicesCollection;
        private IServiceProvider servicesProvider;

        public static DependenciesInjectionConfiguration GetSingleton()
        {
            return (dependenciesInjectionConfiguration ?? (dependenciesInjectionConfiguration = new DependenciesInjectionConfiguration()));
        }

        private DependenciesInjectionConfiguration()
        {
            servicesCollection = new ServiceCollection();
            Configure();
        }

        public FrontController GetFrontController()
        {
            return servicesProvider.GetService<FrontController>();
        }

        private void Configure()
        {
            ConfigureUnitsOfWork();
            ConfigureUseCases();
            ConfigureControllers();

            servicesProvider = servicesCollection.BuildServiceProvider();
        }

        private void ConfigureControllers()
        {
            servicesCollection
                .AddSingleton<IPortsController, PortsController>()
                .AddSingleton<IVillesController, VillesController>()
                .AddSingleton<FrontController, FrontController>()  //le point d'entrée
            ;
        }

        private void ConfigureUseCases()
        {
            servicesCollection
                .AddSingleton<IGetPortMinimalDataUseCase, GetPortMinimalDataUseCase>()
                .AddSingleton<IGetPortsMinimalDataUseCase, GetPortsMinimalDataUseCase>()
                .AddSingleton<IGetPortsFullDataUseCase, GetPortsFullDataUseCase>()
            ;
        }

        private void ConfigureUnitsOfWork()
        {
            if (EF_Mode)
            {
                servicesCollection
                    .AddSingleton(
                        (IServiceProvider pServiceProvider) =>
                            (new PortsDBServerAccessConfigurationFactory()).GetSingleton() //IDBServerAccessConfiguration
                    )
                    .AddSingleton<IDbDataContextFactory<PortsDbDataContext>, PortsDbDataContextFactory>()
                    .AddSingleton<IPortsUnitOfWorkFactory, Infra.UnitsOfWork.EF.Factories.Ports.PortsUnitOfWorkFactory>()
                ;
            } 
            else //NON EF
            {
                servicesCollection
                    .AddSingleton<IPortsUnitOfWorkFactory, PortsUnitOfWorkFactory>()
                ;
            }
        }
    }
}
