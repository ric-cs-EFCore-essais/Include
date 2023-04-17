using System;
using System.Collections.Generic;
using System.Linq;

using Infra.Controllers.Interfaces.Ports;

namespace Infra.Controllers.Ports
{
    public class FrontController
    {
        private readonly IPortsController portsController;
        private readonly IVillesController villesController;
        private readonly IAncresController ancresController;
        private readonly ICapitainesController capitainesController;
        private readonly IDiplomesController diplomesController;
        private readonly IBateauxController bateauxController;
        private readonly ICapitainesDiplomesController capitainesDiplomesController;

        private IDictionary<string, Func<IList<string>, string>> controllersCalls;


        public FrontController(
            IPortsController portsController,
            IVillesController villesController,
            IAncresController ancresController,
            ICapitainesController capitainesController,
            IDiplomesController diplomesController,
            IBateauxController bateauxController,
            ICapitainesDiplomesController capitainesDiplomesController
        )
        {
            this.portsController = portsController;
            this.villesController = villesController;
            this.ancresController = ancresController;
            this.capitainesController = capitainesController;
            this.diplomesController = diplomesController;
            this.bateauxController = bateauxController;
            this.capitainesDiplomesController = capitainesDiplomesController;

            SetControllersCalls();
        }

        private void SetControllersCalls()
        {
            controllersCalls = new Dictionary<string, Func<IList<string>, string>>
            {
                { "get/ports", (IList<string> args) => portsController.GetPortsMinimalData(args) },
                { "get/ports/fulldata", (IList<string> args) => portsController.GetPortsFullData(args) },
                { "get/port", (IList<string> args) => portsController.GetPortMinimalData(args) },
                { "get/port/fulldata", (IList<string> args) => portsController.GetPortFullData(args) },
                { "post/port/add", (IList<string> args) => portsController.AddPort(args) },

                { "get/villes/withnamecontaining", (IList<string> args) => villesController.GetVillesWithNameContaining(args) }, //Filtrable donc (via args[1])
                { "post/ville/add", (IList<string> args) => villesController.AddVille(args) },

                { "post/ancre/add", (IList<string> args) => ancresController.AddAncre(args) },

                { "post/capitaine/add", (IList<string> args) => capitainesController.AddCapitaine(args) },

                { "post/diplome/add", (IList<string> args) => diplomesController.AddDiplome(args) },

                { "post/bateau/add", (IList<string> args) => bateauxController.AddBateau(args) },

                { "post/capitainediplome/add", (IList<string> args) => capitainesDiplomesController.AddCapitaineDiplome(args) },
                { "post/capitainediplomes/add", (IList<string> args) => capitainesDiplomesController.AddCapitaineDiplomes(args) },
            };
        }

        public string TreatRequest(string[] requestArgs)
        {
            if (requestArgs.Length > 0)
            {
                var controllerMethodId = requestArgs[0].ToLower(); //1er argument

                if (controllersCalls.TryGetValue(controllerMethodId, out Func<IList<string>, string> controllerCall))
                {
                    var argumentsApresLe1erArgument = requestArgs.Skip(1).ToList();
                    return controllerCall(argumentsApresLe1erArgument);
                }
                else throw new Exception($"Requête non gérable : controllerMethodId '{controllerMethodId}' non géré.");
            }
            else throw new Exception($"La Requête nécessite au moins 1 argument (controllerMethodId).");
        }
    }
}
