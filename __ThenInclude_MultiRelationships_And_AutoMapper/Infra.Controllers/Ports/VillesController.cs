using System.Collections.Generic;

using Application.UseCases.Interfaces.Ports;
using Infra.Controllers.Interfaces.Ports;

using Application.DTOs.Ports.GetVilles;

namespace Infra.Controllers.Ports
{
    public class VillesController : AController, IVillesController
    {
        private readonly IGetVillesWithNameContainingUseCase getVillesWithNameContainingUseCase;

        public VillesController(
            IGetVillesWithNameContainingUseCase getVillesWithNameContainingUseCase
        ) : base()
        {
            this.getVillesWithNameContainingUseCase = getVillesWithNameContainingUseCase;
        }

        public string GetVillesWithNameContaining(IList<string> args)
        {
            var getVillesWithNameContainingUseCaseRequestDTO = new GetVillesWithNameContainingUseCaseRequestDTO()
            {
                SubString = (args.Count > 0) ? args[0] : string.Empty
            };

            var responseDTO = getVillesWithNameContainingUseCase.Execute(getVillesWithNameContainingUseCaseRequestDTO);

            var retour = GetSerializedDTO<GetVillesWithNameContainingUseCaseResponseDTO>(responseDTO);
            return retour;
        }
    }
}
