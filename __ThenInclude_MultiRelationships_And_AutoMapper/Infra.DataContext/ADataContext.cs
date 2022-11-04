namespace Infra.DataContext
{
    public abstract class ADataContext
    {
        public ADataContext()
        {

        }

        public virtual bool HasMetaData { get; } = false;
    }
}
