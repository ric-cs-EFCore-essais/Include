using System;
using System.Collections.Generic;

using Application.UseCases.Interfaces.Ports;
using Infra.Controllers.Interfaces.Ports;

using Application.DTOs.Ports.AddAncre;

namespace Infra.Controllers.Ports
{
    public class AncresController : AController, IAncresController
    {
        private readonly IAddAncreUseCase addAncreUseCase;

        public AncresController(
            IAddAncreUseCase addAncreUseCase
        ) : base()
        {
            this.addAncreUseCase = addAncreUseCase;
        }

        public string AddAncre(IList<string> args)
        {
            var addAncreUseCaseRequestDTO = new AddAncreUseCaseRequestDTO()
            {
                Poids = (args.Count > 0) ? Convert.ToUInt32(args[0]) : 0
            };

            var responseDTO = addAncreUseCase.Execute(addAncreUseCaseRequestDTO);

            var retour = GetSerializedDTO<AddAncreUseCaseResponseDTO>(responseDTO);
            return retour;
        }
    }
}