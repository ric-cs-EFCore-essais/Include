using System.Collections.Generic;

namespace Infra.Controllers.Interfaces.Ports
{
    public interface IAncresController
    {
        string GetAncres(IList<string> args);
    }
}