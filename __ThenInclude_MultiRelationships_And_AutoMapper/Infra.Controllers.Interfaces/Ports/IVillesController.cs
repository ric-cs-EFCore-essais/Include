using System.Collections.Generic;

namespace Infra.Controllers.Interfaces.Ports
{
    public interface IVillesController
    {
        string GetVille(IList<string> args);
        string GetVilles(IList<string> args);
    }
}