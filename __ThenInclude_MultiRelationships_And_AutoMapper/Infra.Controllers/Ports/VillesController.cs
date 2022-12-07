using System.Collections.Generic;

using Application.UseCases.Interfaces.Ports;
using Infra.Controllers.Interfaces.Ports;

using Application.DTOs.Ports.GetVilles;
using Application.DTOs.Ports.AddVille;

namespace Infra.Controllers.Ports
{
    public class VillesController : AController, IVillesController
    {
        private readonly IGetVillesWithNameContainingUseCase getVillesWithNameContainingUseCase;
        private readonly IAddVilleUseCase addVilleUseCase;

        public VillesController(
            IGetVillesWithNameContainingUseCase getVillesWithNameContainingUseCase,
            IAddVilleUseCase addVilleUseCase
        ) : base()
        {
            this.getVillesWithNameContainingUseCase = getVillesWithNameContainingUseCase;
            this.addVilleUseCase = addVilleUseCase;
        }

        public string AddVille(IList<string> args)
        {
            var addVilleUseCaseRequestDTO = new AddVilleUseCaseRequestDTO()
            {
                Nom = (args.Count > 0) ? args[0] : null
            };

            var responseDTO = addVilleUseCase.Execute(addVilleUseCaseRequestDTO);

            var retour = GetSerializedDTO<AddVilleUseCaseResponseDTO>(responseDTO);
            return retour;
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
