using System;
using System.Collections.Generic;

using Application.UseCases.Interfaces.Ports;
using Infra.Controllers.Interfaces.Ports;

using Application.DTOs.Ports.AddBateau;

namespace Infra.Controllers.Ports
{
    public class BateauxController : AController, IBateauxController
    {
        private readonly IAddBateauUseCase addBateauUseCase;

        public BateauxController(
            IAddBateauUseCase addBateauUseCase
        ) : base()
        {
            this.addBateauUseCase = addBateauUseCase;
        }

        public string AddBateau(IList<string> args)
        {
            var addBateauUseCaseRequestDTO = new AddBateauUseCaseRequestDTO()
            {
                Nom = (args.Count > 0) ? args[0] : null,
                PortId = (args.Count > 1) ? Convert.ToInt32(args[1]) : 0,
                AncreId = (args.Count > 2) ? Convert.ToInt32(args[2]) : 0,
                CapitaineId = (args.Count > 3) ? Convert.ToInt32(args[3]) : 0,
            };

            var responseDTO = addBateauUseCase.Execute(addBateauUseCaseRequestDTO);

            var retour = GetSerializedDTO<AddBateauUseCaseResponseDTO>(responseDTO);
            return retour;
        }
    }
}