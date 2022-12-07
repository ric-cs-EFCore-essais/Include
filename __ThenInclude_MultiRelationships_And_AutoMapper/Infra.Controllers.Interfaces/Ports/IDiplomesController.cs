using System.Collections.Generic;

namespace Infra.Controllers.Interfaces.Ports
{
    public interface IDiplomesController
    {
        string AddDiplome(IList<string> args);
    }
}