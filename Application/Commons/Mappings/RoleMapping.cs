using Application.UseCases.Roles.Queries;
using AutoMapper;
using Domain.Identitiy;

namespace Application.Commons.Mappings;

public class RoleMapping : Profile
{
    public RoleMapping()
    {
        CreateMap<RoleResponse, Role>().ReverseMap();
    }
}
