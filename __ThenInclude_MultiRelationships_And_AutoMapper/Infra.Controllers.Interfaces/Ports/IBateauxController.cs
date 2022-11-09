using System.Collections.Generic;

namespace Infra.Controllers.Interfaces.Ports
{
    public interface IBateauxController
    {
        string AddBateau(IList<string> args);
    }
}