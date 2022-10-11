using System;

namespace Application.UseCases.Interfaces
{
    public interface IUseCase<TRequestDTO, TResponseDTO>
    {
        TResponseDTO Execute(TRequestDTO requestDTO);
    }
}
