using Application.UseCases.Tasks.Commands.Create;
using Application.UseCases.Tasks.Commands.Edit;
using Application.UseCases.Tasks.Queries.GetAll;
using Application.UseCases.Tasks.Queries.GetById;
using AutoMapper;

namespace Application.Commons.Mappings
{
    public class TaskMapping : Profile
    {
        public TaskMapping()
        {
            CreateMap<CreateTaskCommand, Domain.Entities.Task>();
            CreateMap<EditTaskCommand, Domain.Entities.Task>();
            CreateMap<GetTaskByIdQueryRespоnse, Domain.Entities.Task>().ReverseMap();
            CreateMap<GetAllTasksQueryResponse, Domain.Entities.Task>().ReverseMap();
        }
    }
}
