using System.Collections.Generic;

using Application.UseCases.Interfaces.Ports;
using Infra.Controllers.Interfaces.Ports;

using Application.DTOs.Ports.AddDiplome;

namespace Infra.Controllers.Ports
{
    public class DiplomesController : AController, IDiplomesController
    {
        private readonly IAddDiplomeUseCase addDiplomeUseCase;

        public DiplomesController(
            IAddDiplomeUseCase addDiplomeUseCase
        ) : base()
        {
            this.addDiplomeUseCase = addDiplomeUseCase;
        }

        public string AddDiplome(IList<string> args)
        {
            var addDiplomeUseCaseRequestDTO = new AddDiplomeUseCaseRequestDTO()
            {
                Intitule = (args.Count > 0) ? args[0] : null
            };

            var responseDTO = addDiplomeUseCase.Execute(addDiplomeUseCaseRequestDTO);

            var retour = GetSerializedDTO<AddDiplomeUseCaseResponseDTO>(responseDTO);
            return retour;
        }
    }
}