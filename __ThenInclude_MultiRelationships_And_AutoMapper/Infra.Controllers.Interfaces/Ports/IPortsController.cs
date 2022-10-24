using System.Collections.Generic;

namespace Infra.Controllers.Interfaces.Ports
{
    public interface IPortsController
    {
        string GetPortMinimalData(IList<string> args);
        string GetPortsFullData(IList<string> args);
        string GetPortsMinimalData(IList<string> args);
    }
}