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

        private IDictionary<string, Func<IList<string>, string>> controllersCalls;


        public FrontController(
            IPortsController portsController,
            IVillesController villesController
        )
        {
            this.portsController = portsController;
            this.villesController = villesController;

            controllersCalls = new Dictionary<string, Func<IList<string>, string>>
            {
                { "get/ports", (IList<string> args) => portsController.GetPortsMinimalData(args) },
                { "get/ports/fulldata", (IList<string> args) => portsController.GetPortsFullData(args) },
                { "get/port", (IList<string> args) => portsController.GetPortMinimalData(args) },
                { "get/port/fulldata", (IList<string> args) => portsController.GetPortFullData(args) },

                { "get/villes/withnamecontaining", (IList<string> args) => villesController.GetVillesWithNameContaining(args) }, //Filtrable (via args[1])
            };
        }

        public string TreatRequest(string[] requestArgs)
        {
            Func<IList<string>, string> controllerCall;

            if (requestArgs.Length >0) {
                var controllerMethodId = requestArgs[0].ToLower(); //1er argument

                if (controllersCalls.TryGetValue(controllerMethodId, out controllerCall))
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
