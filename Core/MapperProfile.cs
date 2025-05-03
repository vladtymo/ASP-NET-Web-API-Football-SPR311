using AutoMapper;
using Data.Models;
using Web_Api_Football_SPR311.Dtos;

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