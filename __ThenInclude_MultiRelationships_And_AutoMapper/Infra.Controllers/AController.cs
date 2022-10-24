using Transverse.Common.DebugTools;

namespace Infra.Controllers
{
    public abstract class AController
    {
        protected string GetSerializedDTO<T>(T dto)
            where T : class
        {
            return Debug.GetSerializedData(dto);
        }
    }
}
