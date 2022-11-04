using System.Collections.Generic;

namespace Infra.Controllers.Interfaces.Ports
{
    public interface IVillesController
    {
        string GetVillesWithNameContaining(IList<string> args);

        string AddVille(IList<string> args);
    }
}