using System.Collections.Generic;

namespace Infra.Controllers.Interfaces.Ports
{
    public interface ICapitainesController
    {
        string AddCapitaine(IList<string> args);
    }
}