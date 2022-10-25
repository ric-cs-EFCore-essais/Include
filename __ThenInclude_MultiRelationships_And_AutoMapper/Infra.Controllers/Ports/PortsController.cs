using System;
using System.Collections.Generic;

using Infra.Controllers.Interfaces.Ports;
using Application.UseCases.Interfaces.Ports;
using Application.DTOs.Ports.GetPort;
using Application.DTOs.Ports.GetPorts;

namespace Infra.Controllers.Ports
{
    public class PortsController : AController, IPortsController
    {
        private readonly IGetPortsMinimalDataUseCase getPortsMinimalDataUseCase;
        private readonly IGetPortsFullDataUseCase getPortsFullDataUseCase;
        private readonly IGetPortMinimalDataUseCase getPortMinimalDataUseCase;
        private readonly IGetPortFullDataUseCase getPortFullDataUseCase;

        public PortsController(
            IGetPortsMinimalDataUseCase getPortsMinimalDataUseCase,
            IGetPortsFullDataUseCase getPortsFullDataUseCase,
            IGetPortMinimalDataUseCase getPortMinimalDataUseCase,
            IGetPortFullDataUseCase getPortFullDataUseCase
        ) : base()
        {
            this.getPortsMinimalDataUseCase = getPortsMinimalDataUseCase;
            this.getPortsFullDataUseCase = getPortsFullDataUseCase;
            this.getPortMinimalDataUseCase = getPortMinimalDataUseCase;
            this.getPortFullDataUseCase = getPortFullDataUseCase;
        }

        public string GetPortsMinimalData(IList<string> args)
        {
            var getPortsMinimalDataUseCaseRequestDTO = new GetPortsMinimalDataUseCaseRequestDTO()
            {
            };

            var responseDTO = getPortsMinimalDataUseCase.Execute(getPortsMinimalDataUseCaseRequestDTO);

            var retour = GetSerializedDTO<GetPortsMinimalDataUseCaseResponseDTO>(responseDTO);
            return retour;
        }

        public string GetPortsFullData(IList<string> args)
        {
            var getPortsFullDataUseCaseRequestDTO = new GetPortsFullDataUseCaseRequestDTO()
            {
            };

            var responseDTO = getPortsFullDataUseCase.Execute(getPortsFullDataUseCaseRequestDTO);

            var retour = GetSerializedDTO<GetPortsFullDataUseCaseResponseDTO>(responseDTO);
            return retour;
        }


        public string GetPortMinimalData(IList<string> args)
        {
            var getPortMinimalDataUseCaseRequestDTO = new GetPortMinimalDataUseCaseRequestDTO()
            {
                PortId = Convert.ToInt32(args[0])
            };

            var responseDTO = getPortMinimalDataUseCase.Execute(getPortMinimalDataUseCaseRequestDTO);

            var retour = GetSerializedDTO<GetPortMinimalDataUseCaseResponseDTO>(responseDTO);
            return retour;
        }

        public string GetPortFullData(IList<string> args)
        {
            var getPortFullDataUseCaseRequestDTO = new GetPortFullDataUseCaseRequestDTO()
            {
                PortId = Convert.ToInt32(args[0])
            };

            var responseDTO = getPortFullDataUseCase.Execute(getPortFullDataUseCaseRequestDTO);

            var retour = GetSerializedDTO<GetPortFullDataUseCaseResponseDTO>(responseDTO);
            return retour;
        }

    }
}
