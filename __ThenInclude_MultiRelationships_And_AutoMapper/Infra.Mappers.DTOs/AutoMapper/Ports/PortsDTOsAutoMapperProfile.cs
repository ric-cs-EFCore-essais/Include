using System;
using System.Collections.Generic;
using System.Linq;

using AutoMapper;

using Domain.Entities.Ports;

using Application.DTOs.Ports;
using Application.DTOs.Ports.GetPort;
using Application.DTOs.Ports.GetPorts;

namespace Infra.Mappers.DTOs.AutoMapper.Ports
{
    internal class PortsDTOsAutoMapperProfile : Profile
    {
        public PortsDTOsAutoMapperProfile()
        {
            this._createPortUseCasesBindings();
        }

        private void _createPortUseCasesBindings()
        {
            //============================== GetPortMinimalDataUseCaseResponseDTO ====================================

            CreateMap<Port, GetPortMinimalDataUseCaseResponseDTO>()
                .ForMember(dto => dto.NomVille, opt => opt.MapFrom(port => port.Ville.Nom))
                .ForMember(dto => dto.NombreBateaux, opt => opt.MapFrom(port => port.Bateaux.Count))
            ;



            //============================== GetPortsMinimalDataUseCaseResponseDTO ====================================

            CreateMap<List<Port>, GetPortsMinimalDataUseCaseResponseDTO>()
                 .ForMember(dto => dto.Ports, opt => opt.MapFrom(ports => ports))
                 .ForMember(dto => dto.NombrePorts, opt => opt.MapFrom(ports => ports.Count))
                 .ForMember(dto => dto.NombreMoyenBateauxParPort, opt => opt.MapFrom
                  (
                    ports => Math.Round((ports.Count > 0) ? (ports.Sum(port => port.Bateaux.Count) / (double)ports.Count) : 0, 2)
                  )
                 )
            ;

            CreateMap<Port, PortMinimalDataForGetPortsMinimalDataUseCaseResponseDTO>()
                 .ForMember(dto => dto.TotalPoidsAncres, opt => opt.MapFrom(port => port.Bateaux.Sum(bateau => bateau.Ancre.Poids)))
                 //.ForMember(dto => dto.Bateaux, opt => opt.Ignore()) //<<< Cette ligne permettrait de dire que l'on ne veut pas alimenter le champ Bateaux de notre DTO
                                                                     //    PortMinimalDataForGetPortsMinimalDataUseCaseResponseDTO (le champ Bateaux y vaudrait alors null),
                                                                     //    (Le Ignore en question serait effectif même si comme on le voit ci-dessous, on indique comment convertir un Bateau en BateauDTO). 
            ;

            CreateMap<Ville, VilleDTO>()
                .ForMember(villeDto => villeDto.NombrePorts, opt => opt.MapFrom(ville => ville.Ports.Count))
            ;

            CreateMap<Bateau, BateauDTO>()
                .ForMember(bateauDto => bateauDto.PoidsAncre, opt => opt.MapFrom(bateau => bateau.Ancre.Poids))

                //---- 1 AUTRE FACON DE FAIRE (plus lourde) POUR RECUP. EGALEMENT du  Captaine et ses Diplomes -----
                // ==> VOIR plus bas pour la solution finalement choisie ----
                //.ForPath(bateauDto => bateauDto.Capitaine.Diplomes, opt => opt.MapFrom( //Le ForPath est nécessaire dés lors que dans la desti. on pointe sur un chemin de profondeur > 1  (ici bateauDto.Capitaine.Diplomes).
                //    capitaine => capitaine.Capitaine.CapitainesDiplomes.Select(
                //        capitaineDiplome => new DiplomeDTO
                //        {
                //            Id = capitaineDiplome.Diplome.Id,
                //            Intitule = capitaineDiplome.Diplome.Intitule,
                //            AnneeObtention = capitaineDiplome.AnneeObtention
                //        }
                //    )
                //))
                //.ForMember(bateauDto => bateauDto.Capitaine, opt => opt.MapFrom(
                //    bateau => new CapitaineDTO
                //    {
                //        Id = bateau.Capitaine.Id,
                //        Nom = bateau.Capitaine.Nom
                //    }
                //))
            ;

            // ==> Solution finalement choisie POUR RECUP. EGALEMENT du  Captaine et ses Diplomes ----
            CreateMap<Capitaine, CapitaineDTO>()
                .ForMember(capitaineDto => capitaineDto.Diplomes, opt => opt.MapFrom(
                    capitaine => capitaine.CapitainesDiplomes.Select(
                        capitaineDiplome => new DiplomeDTO
                        {
                            Id = capitaineDiplome.Diplome.Id,
                            Intitule = capitaineDiplome.Diplome.Intitule,
                            AnneeObtention = capitaineDiplome.AnneeObtention
                        }
                    )
                ))
            ;

            //CreateMap<Diplome, DiplomeDTO>(); //Inutile car on crée ici nous-même le DiplomeDTO à la mano   (new DiplomeDTO {...})

        }

    }

}
