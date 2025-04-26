using AutoMapper;
using Web_Api_Football_SPR311.Dtos;
using Web_Api_Football_SPR311.Models;

namespace Web_Api_Football_SPR311;

public class MapperProfile : Profile
{
    public MapperProfile()
    {
        CreateMap<UpdateTeamModel, Team>();
        CreateMap<CreateTeamModel, Team>();
        CreateMap<Team, TeamModel>().ReverseMap();
    }
}