using AutoMapper;
using JobCode.Application.Models;
using JobCode.Core.Entities;

namespace JobCode.Application.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<AddressModel, Address>();
    }
}

