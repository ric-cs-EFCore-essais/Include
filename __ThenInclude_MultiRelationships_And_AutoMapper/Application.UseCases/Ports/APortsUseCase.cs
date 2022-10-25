using Domain.UnitsOfWork.Interfaces.Ports;
using Application.DTOs.Mappers.Interfaces.Ports;

namespace Application.UseCases.Ports
{
    public abstract class APortsUseCase<TUseCaseRequestDTO, TUseCaseResponseDTO>
        where TUseCaseResponseDTO : class
        where TUseCaseRequestDTO : class
    {
        private readonly IPortsUnitOfWorkFactory portsUnitOfWorkFactory;
        protected readonly IPortsDTOsMapper portsDTOsMapper;

        protected abstract TUseCaseResponseDTO TreatRequestDTO(IPortsUnitOfWork portsUnitOfWork, TUseCaseRequestDTO requestDTO);

        protected APortsUseCase(IPortsUnitOfWorkFactory portsUnitOfWorkFactory, IPortsDTOsMapper portsDTOsMapper)
        {
            this.portsUnitOfWorkFactory = portsUnitOfWorkFactory;
            this.portsDTOsMapper = portsDTOsMapper;
        }

        public TUseCaseResponseDTO Execute(TUseCaseRequestDTO requestDTO)
        {
            TUseCaseResponseDTO retour = null;

            using (IPortsUnitOfWork portsUnitOfWork = portsUnitOfWorkFactory.GetInstance())
            {
                retour = TreatRequestDTO(portsUnitOfWork, requestDTO);
            }

            return retour;
        }
    }
}
