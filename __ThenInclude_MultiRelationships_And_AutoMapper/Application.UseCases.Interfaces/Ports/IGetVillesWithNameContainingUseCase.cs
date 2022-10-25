using Application.DTOs.Ports.GetVilles;

namespace Application.UseCases.Interfaces.Ports
{
    public interface IGetVillesWithNameContainingUseCase :  IUseCase<GetVillesWithNameContainingUseCaseRequestDTO, GetVillesWithNameContainingUseCaseResponseDTO>
    {
    }
}
