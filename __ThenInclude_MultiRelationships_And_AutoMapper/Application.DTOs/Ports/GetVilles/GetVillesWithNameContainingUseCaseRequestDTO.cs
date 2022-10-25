
using System;

namespace Application.DTOs.Ports.GetVilles
{
    public record GetVillesWithNameContainingUseCaseRequestDTO
    {
        public string SubString { get; set; }  //sera Case insensitive
    }
}
