using AutoMapper;
using BCOAPI.Core.Domain.Dtos;

namespace BCOAPI.Core
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //Domain to CoreDomain
            CreateMap<BCOAPI.Domain.Dtos.ClienteDto, Core.Domain.Dtos.ClienteDto>().ReverseMap();
            CreateMap<BCOAPI.Domain.Entities.ClienteEntity, Core.Domain.Entities.ClienteEntity>().ReverseMap();
            CreateMap<BCOAPI.Domain.Entities.ClienteEntity,BCOAPI.Domain.Dtos.ClienteDto>()
                .ForMember(dest => dest.idCliente, opt => opt.MapFrom(s => s.idCliente.ToString())).ReverseMap();
            CreateMap<BCOAPI.Domain.Dtos.tarjetasClienteDto, Core.Domain.Dtos.tarjetasClienteDto>().ReverseMap();
            CreateMap<BCOAPI.Domain.Dtos.cargoDto,Core.Domain.Dtos.cargoDto>().ReverseMap();
            CreateMap<BCOAPI.Domain.Dtos.abonoDto, Core.Domain.Dtos.abonoDto>().ReverseMap();
            CreateMap<BCOAPI.Domain.Dtos.infoTarjetaDto, Core.Domain.Dtos.infoTarjetaDto>().ReverseMap();
            CreateMap<BCOAPI.Domain.Dtos.tranTarjetaDto, Core.Domain.Dtos.tranTarjetaDto>().ReverseMap();
            CreateMap<BCOAPI.Domain.Dtos.totalTranDto, Core.Domain.Dtos.totalTranDto>().ReverseMap();
            CreateMap<BCOAPI.Domain.Dtos.paramReport1, Core.Domain.Dtos.paramReport1>().ReverseMap();

            ////CoreDomain to Domain
            CreateMap<Core.Domain.Dtos.ClienteDto, BCOAPI.Domain.Dtos.ClienteDto>().ReverseMap();
            CreateMap<Core.Domain.Entities.ClienteEntity,BCOAPI.Domain.Entities.ClienteEntity>().ReverseMap();
            CreateMap<Core.Domain.Dtos.cargoDto, BCOAPI.Domain.Dtos.cargoDto>().ReverseMap();
            CreateMap<Core.Domain.Dtos.abonoDto, BCOAPI.Domain.Dtos.abonoDto>().ReverseMap();
            CreateMap<Core.Domain.Dtos.infoTarjetaDto, BCOAPI.Domain.Dtos.infoTarjetaDto>().ReverseMap();
            CreateMap<Core.Domain.Dtos.tranTarjetaDto, BCOAPI.Domain.Dtos.tranTarjetaDto>().ReverseMap();
            CreateMap<Core.Domain.Dtos.totalTranDto, BCOAPI.Domain.Dtos.totalTranDto>().ReverseMap();
            CreateMap<Core.Domain.Dtos.paramReport1, BCOAPI.Domain.Dtos.paramReport1>().ReverseMap();
        }

    }
}
