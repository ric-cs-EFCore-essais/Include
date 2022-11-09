using System.Collections.Generic;

namespace Infra.Controllers.Interfaces.Ports
{
    public interface ICapitainesDiplomesController
    {
        string AddCapitaineDiplomes(IList<string> args);

        string AddCapitaineDiplome(IList<string> args);
    }
}