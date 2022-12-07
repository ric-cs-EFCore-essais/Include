using System;

using Microsoft.Extensions.DependencyInjection;

using Domain.UnitsOfWork.Interfaces.Ports;
using Application.UseCases.Interfaces.Ports;
using Infra.DataContext.EF.Interfaces;
using Infra.Controllers.Interfaces.Ports;

using Application.UseCases.Ports.GetPort;
using Application.UseCases.Ports.GetPorts;
using Application.UseCases.Ports.AddPort;
using Application.UseCases.Ports.GetVilles;
using Application.UseCases.Ports.AddVille;
using Application.UseCases.Ports.AddAncre;
using Application.UseCases.Ports.AddCapitaine;
using Application.UseCases.Ports.AddDiplome;
using Application.UseCases.Ports.AddBateau;
using Application.UseCases.Ports.AddCapitaineDiplome;

using Infra.UnitsOfWork.Factories.Ports;

using Infra.Config.DataAccess;

using Infra.DataContext.EF.Ports;
using Infra.Controllers.Ports;

using Infra.DependenciesInjection.Ports.Factories;
using Infra.Mappers.DTOs.AutoMapper.Ports;


namespace Infra.DependenciesInjection.Ports
{
    public class DependenciesInjectionConfiguration
    {
        private readonly DataAccessConfig dataAccessConfig;

        private static DependenciesInjectionConfiguration dependenciesInjectionConfiguration;

        private readonly IServiceCollection servicesCollection;
        private IServiceProvider servicesProvider;

        public static DependenciesInjectionConfiguration GetSingleton(DataAccessConfig dataAccessConfig)
        {
            return (dependenciesInjectionConfiguration ?? (dependenciesInjectionConfiguration = new DependenciesInjectionConfiguration(dataAccessConfig)));
        }

        private DependenciesInjectionConfiguration(DataAccessConfig dataAccessConfig)
        {
            this.dataAccessConfig = dataAccessConfig;

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
                .AddSingleton<IAncresController, AncresController>()
                .AddSingleton<ICapitainesController, CapitainesController>()
                .AddSingleton<IDiplomesController, DiplomesController>()
                .AddSingleton<IBateauxController, BateauxController>()
                .AddSingleton<ICapitainesDiplomesController, CapitainesDiplomesController>()
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
                .AddSingleton<IAddPortUseCase, AddPortUseCase>()

                .AddSingleton<IGetVillesWithNameContainingUseCase, GetVillesWithNameContainingUseCase>()
                .AddSingleton<IAddVilleUseCase, AddVilleUseCase>()

                .AddSingleton<IAddAncreUseCase, AddAncreUseCase>()

                .AddSingleton<IAddCapitaineUseCase, AddCapitaineUseCase>()

                .AddSingleton<IAddDiplomeUseCase, AddDiplomeUseCase>()

                .AddSingleton<IAddBateauUseCase, AddBateauUseCase>()

                .AddSingleton<IAddCapitaineDiplomeUseCase, AddCapitaineDiplomeUseCase>()
                .AddSingleton<IAddCapitaineDiplomesUseCase, AddCapitaineDiplomesUseCase>()
            ;
        }

        private void ConfigureUnitsOfWork()
        {
            if (dataAccessConfig.DataStoreMode == DataStoreMode.EF)
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
            else if (dataAccessConfig.DataStoreMode == DataStoreMode.JSON)
            {
                servicesCollection
                    .AddSingleton<IPortsUnitOfWorkFactory, PortsUnitOfWorkFactory>()
                ;
            }
        }
    }
}
