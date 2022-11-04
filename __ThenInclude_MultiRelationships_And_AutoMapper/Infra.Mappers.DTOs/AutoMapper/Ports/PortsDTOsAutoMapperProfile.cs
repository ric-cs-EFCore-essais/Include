using System;
using System.Collections.Generic;
using System.Linq;

using AutoMapper;

using Domain.Entities.Ports;

using Application.DTOs.Ports;
using Application.DTOs.Ports.GetPort;
using Application.DTOs.Ports.GetPorts;

using Application.DTOs.Ports.GetVilles;
using Application.DTOs.Ports.AddVille;

namespace Infra.Mappers.DTOs.AutoMapper.Ports
{
    internal class PortsDTOsAutoMapperProfile : Profile
    {
        public PortsDTOsAutoMapperProfile()
        {
            _createPortUseCasesBindings();
            _createVilleUseCasesBindings();
        }

        private void _createPortUseCasesBindings()
        {
            //============================== Pour  GetPortMinimalDataUseCaseResponseDTO et GetPortsMinimalDataUseCaseResponseDTO ====================================

            CreateMap<Port, GetPortMinimalDataUseCaseResponseDTO>()
                .ForMember(dto => dto.NomVille, opt => opt.MapFrom(port => port.Ville.Nom))
                .ForMember(dto => dto.NombreBateaux, opt => opt.MapFrom(port => port.Bateaux.Count))
            ;

            //============================== Pour  GetPortsMinimalDataUseCaseResponseDTO ====================================

            CreateMap<List<Port>, GetPortsMinimalDataUseCaseResponseDTO>()
                .ForMember(dto => dto.Ports, opt => opt.MapFrom(ports => ports))
            ;

            //============================== Pour  GetPortsFullDataUseCaseResponseDTO ====================================

            CreateMap<List<Port>, GetPortsFullDataUseCaseResponseDTO>()
                 .ForMember(dto => dto.Ports, opt => opt.MapFrom(ports => ports))
                 .ForMember(dto => dto.NombrePorts, opt => opt.MapFrom(ports => ports.Count))
                 .ForMember(dto => dto.NombreMoyenBateauxParPort, opt => opt.MapFrom
                  (
                    ports => Math.Round((ports.Count > 0) ? (ports.Sum(port => port.Bateaux.Count) / (double)ports.Count) : 0, 2)
                  )
                 )
            ;

            CreateMap<Port, PortFullDataForGetPortsFullDataUseCaseResponseDTO>()
                 .ForMember(dto => dto.TotalPoidsAncres, opt => opt.MapFrom(port => port.Bateaux.Sum(bateau => bateau.Ancre.Poids)))
            //.ForMember(dto => dto.Bateaux, opt => opt.Ignore()) //<<< Cette ligne permettrait de dire que l'on ne veut pas alimenter le champ Bateaux de notre DTO
            //                                                          PortFullDataForGetPortsFullDataUseCaseResponseDTO (le champ Bateaux y vaudrait alors null),
            //                                                          (Le Ignore en question serait effectif même si l'on indique(ci-dessous) comment convertir un Bateau en BateauDTO). 
            ;

            CreateMap<Ville, VilleDTO>()
                .ForMember(villeDto => villeDto.NombrePorts, opt => opt.MapFrom(ville => ville.Ports.Count))
            ;



            //============================== Pour  GetPortsFullDataUseCaseResponseDTO  et  GetPortFullDataUseCaseResponseDTO ====================================
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




            //============================== GetPortFullDataUseCaseResponseDTO (suite) ====================================
            // Pour ce DTO, seront également automatiquement utilisés les mappages : CreateMap<Bateau, BateauDTO>()  ET   CreateMap<Capitaine, CapitaineDTO>()
            // définis juste ci-dessus. (Car GetPortFullDataUseCaseResponseDTO possède une IList<BateauDTO>, et BateauDTO un CapitaineDTO).
            //  On aurait très bien pu dissocier en créant 2 nouveaux types de DTO spécifiques pour GetPortFullDataUseCaseResponseDTO :
            //   Par exemple : BateauDTOForGetPortFullDataUseCaseResponseDTO  et CapitaineDTOForGetPortFullDataUseCaseResponseDTO,
            //                 avec GetPortFullDataUseCaseResponseDTO possédant une IList<BateauDTOForGetPortFullDataUseCaseResponseDTO> et 
            //                 BateauDTOForGetPortFullDataUseCaseResponseDTO possédant un CapitaineDTOForGetPortFullDataUseCaseResponseDTO,
            //                 ET en définissant alors des règles équivalentes à juste ci-dessus(BateauDTO et CapitaineDTO) pour cette fois respectivement :
            //                 BateauDTOForGetPortFullDataUseCaseResponseDTO et CapitaineDTOForGetPortFullDataUseCaseResponseDTO.

            CreateMap<Port, GetPortFullDataUseCaseResponseDTO>()
                .ForMember(dto => dto.NomVille, opt => opt.MapFrom(port => port.Ville.Nom))
                .ForMember(dto => dto.NombreBateaux, opt => opt.MapFrom(port => port.Bateaux.Count))
            ;
            ;
        }



        private void _createVilleUseCasesBindings()
        {
            //================================= GetVillesWithNameContainingUseCase =============================
            //  S'appuie également sur le mappage fait plus haut :   CreateMap<Ville, VilleDTO>().....,
            //  car GetVillesWithNameContainingUseCaseResponseDTO contient une IList<VilleDTO>.

            CreateMap<List<Ville>, GetVillesWithNameContainingUseCaseResponseDTO>()
                .ForMember(dto => dto.Villes, opt => opt.MapFrom(villes => villes))
            ;

            //================================= GetVillesWithNameContainingUseCase =============================
            CreateMap<Ville, AddVilleUseCaseResponseDTO>()
            ;

        }

    }

}
