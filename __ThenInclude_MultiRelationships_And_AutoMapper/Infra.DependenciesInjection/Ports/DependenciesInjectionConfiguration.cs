using System;

using Microsoft.Extensions.DependencyInjection;

using Domain.UnitsOfWork.Interfaces.Ports;
using Application.UseCases.Interfaces.Ports;
using Infra.DataContext.EF.Interfaces;
using Infra.Controllers.Interfaces.Ports;

using Application.UseCases.Ports.GetPort;
using Application.UseCases.Ports.GetPorts;
using Application.UseCases.Ports.GetVilles;
using Application.UseCases.Ports.AddVille;

using Infra.UnitsOfWork.Factories.Ports;

using Infra.DataContext.EF.Ports;
using Infra.Controllers.Ports;

using Infra.DependenciesInjection.Ports.Factories;
using Infra.Mappers.DTOs.AutoMapper.Ports;

namespace Infra.DependenciesInjection.Ports
{
    public class DependenciesInjectionConfiguration
    {
        private readonly bool EF_Mode = false;
        //private readonly bool EF_Mode = true;

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
            ConfigureMappers();
            ConfigureUseCases();
            ConfigureControllers();

            servicesProvider = servicesCollection.BuildServiceProvider();
        }

        private void ConfigureMappers()
        {
            servicesCollection
                .AddSingleton(
                    (IServiceProvider pServiceProvider) =>
                        (new PortsDTOsAutoMapperFactory()).GetSingleton() //IPortsDTOsMapper
                )
            ;
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
                .AddSingleton<IGetPortsMinimalDataUseCase, GetPortsMinimalDataUseCase>()
                .AddSingleton<IGetPortsFullDataUseCase, GetPortsFullDataUseCase>()
                .AddSingleton<IGetPortMinimalDataUseCase, GetPortMinimalDataUseCase>()
                .AddSingleton<IGetPortFullDataUseCase, GetPortFullDataUseCase>()
                .AddSingleton<IGetVillesWithNameContainingUseCase, GetVillesWithNameContainingUseCase>()
                .AddSingleton<IAddVilleUseCase, AddVilleUseCase>()
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
