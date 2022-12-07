using System.Collections.Generic;

using Application.UseCases.Interfaces.Ports;
using Infra.Controllers.Interfaces.Ports;

using Application.DTOs.Ports.AddCapitaine;

namespace Infra.Controllers.Ports
{
    public class CapitainesController : AController, ICapitainesController
    {
        private readonly IAddCapitaineUseCase addCapitaineUseCase;

        public CapitainesController(
            IAddCapitaineUseCase addCapitaineUseCase
        ) : base()
        {
            this.addCapitaineUseCase = addCapitaineUseCase;
        }

        public string AddCapitaine(IList<string> args)
        {
            var addCapitaineUseCaseRequestDTO = new AddCapitaineUseCaseRequestDTO()
            {
                Nom = (args.Count > 0) ? args[0] : null
            };

            var responseDTO = addCapitaineUseCase.Execute(addCapitaineUseCaseRequestDTO);

            var retour = GetSerializedDTO<AddCapitaineUseCaseResponseDTO>(responseDTO);
            return retour;
        }
    }
}