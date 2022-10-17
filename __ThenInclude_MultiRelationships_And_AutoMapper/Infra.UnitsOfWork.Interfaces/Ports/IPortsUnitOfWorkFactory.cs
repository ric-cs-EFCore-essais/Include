namespace Infra.UnitsOfWork.Interfaces.Ports
{
    public interface IPortsUnitOfWorkFactory
    {
        IPortsUnitOfWork GetInstance();
    }
}
