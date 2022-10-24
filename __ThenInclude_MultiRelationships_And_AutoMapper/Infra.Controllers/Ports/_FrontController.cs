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
                { "get/ports/fulldata", (IList<string> args) => portsController.GetPortsFullData(args) },
                { "get/ports", (IList<string> args) => portsController.GetPortsMinimalData(args) },
                { "get/port", (IList<string> args) => portsController.GetPortMinimalData(args) },

                { "get/villes", (IList<string> args) => villesController.GetVilles(args) },
                { "get/ville", (IList<string> args) => villesController.GetVille(args) },
            };
        }

        public string TreatRequest(string[] requestArgs)
        {
            Func<IList<string>, string> controllerCall;
            
            var controllerMethodId = requestArgs[0].ToLower();

            if (controllersCalls.TryGetValue(controllerMethodId, out controllerCall))
            {
                return controllerCall(requestArgs.Skip(1).ToList());
            }
            else throw new Exception($"Requête non gérable : {controllerMethodId}");
        }
    }
}
