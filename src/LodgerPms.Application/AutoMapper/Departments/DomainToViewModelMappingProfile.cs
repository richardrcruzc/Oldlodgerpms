using AutoMapper;
using LodgerPms.Application.ViewModels.Deparments.Deparments;
using LodgerPms.Domain.Departments.Models;


namespace LodgerPms.Application.AutoMapper.Departments
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Department, DepartmentViewModel>();
        }
    }
}
