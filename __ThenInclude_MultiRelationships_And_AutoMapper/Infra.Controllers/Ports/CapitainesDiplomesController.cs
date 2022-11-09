using System;
using System.Collections.Generic;
using System.Linq;

using Application.UseCases.Interfaces.Ports;
using Infra.Controllers.Interfaces.Ports;

using Application.DTOs.Ports.AddCapitaineDiplome;

namespace Infra.Controllers.Ports
{
    public class CapitainesDiplomesController : AController, ICapitainesDiplomesController
    {
        private readonly IAddCapitaineDiplomeUseCase addCapitaineDiplomeUseCase;
        private readonly IAddCapitaineDiplomesUseCase addCapitaineDiplomesUseCase;

        public CapitainesDiplomesController(
            IAddCapitaineDiplomeUseCase addCapitaineDiplomeUseCase,
            IAddCapitaineDiplomesUseCase addCapitaineDiplomesUseCase
        ) : base()
        {
            this.addCapitaineDiplomeUseCase = addCapitaineDiplomeUseCase;
            this.addCapitaineDiplomesUseCase = addCapitaineDiplomesUseCase;
        }

        public string AddCapitaineDiplome(IList<string> args)
        {
            var addCapitaineDiplomeUseCaseRequestDTO = new AddCapitaineDiplomeUseCaseRequestDTO()
            {
                CapitaineId = (args.Count > 0) ? Convert.ToInt32(args[0]) : 0,
                DiplomeId = (args.Count > 1) ? Convert.ToInt32(args[1]) : 0,
                AnneeObtention = (args.Count > 2) ? Convert.ToUInt32(args[2]) : 0,
            };

            var responseDTO = addCapitaineDiplomeUseCase.Execute(addCapitaineDiplomeUseCaseRequestDTO);

            var retour = GetSerializedDTO<AddCapitaineDiplomeUseCaseResponseDTO>(responseDTO);
            return retour;
        }

        public string AddCapitaineDiplomes(IList<string> args)
        {
            var capitaineDiplomes = (args.Count > 1) ? args[1].Split(";") : new string[] { };

            var addCapitaineDiplomesUseCaseRequestDTO = new AddCapitaineDiplomesUseCaseRequestDTO()
            {
                CapitaineId = (args.Count > 0) ? Convert.ToInt32(args[0]) : 0,
                Diplomes = capitaineDiplomes.Select(diplomeIdEtAnneeObtention => diplomeIdEtAnneeObtention.Split("-"))
                           .Select(diplomeIdEtAnneeObtentionArray => new CapitaineDiplomeForAddCapitaineDiplomesUseCaseRequestDTO
                           {
                               DiplomeId = Convert.ToInt32(diplomeIdEtAnneeObtentionArray[0]),
                               AnneeObtention = Convert.ToUInt32(diplomeIdEtAnneeObtentionArray[1])
                           }).ToList()
            };

            var responseDTO = addCapitaineDiplomesUseCase.Execute(addCapitaineDiplomesUseCaseRequestDTO);

            var retour = GetSerializedDTO<AddCapitaineDiplomesUseCaseResponseDTO>(responseDTO);
            return retour;
        }
    }
}