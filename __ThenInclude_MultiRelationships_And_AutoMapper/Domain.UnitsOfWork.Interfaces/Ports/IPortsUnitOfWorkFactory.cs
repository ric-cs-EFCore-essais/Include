namespace Domain.UnitsOfWork.Interfaces.Ports
{
    public interface IPortsUnitOfWorkFactory
    {
        IPortsUnitOfWork GetInstance();
    }
}
