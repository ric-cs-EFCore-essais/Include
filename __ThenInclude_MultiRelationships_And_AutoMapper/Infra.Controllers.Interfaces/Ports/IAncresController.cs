﻿using System.Collections.Generic;

namespace Infra.Controllers.Interfaces.Ports
{
    public interface IAncresController
    {
        string AddAncre(IList<string> args);
    }
}