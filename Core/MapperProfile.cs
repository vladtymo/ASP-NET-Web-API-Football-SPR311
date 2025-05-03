using AutoMapper;
using Core.Dtos;
using Data.Models;

namespace Core;

public class MapperProfile : Profile
{
    public MapperProfile()
    {
        CreateMap<UpdateTeamModel, Team>();
        CreateMap<CreateTeamModel, Team>();
        CreateMap<Team, TeamModel>().ReverseMap();
    }
}