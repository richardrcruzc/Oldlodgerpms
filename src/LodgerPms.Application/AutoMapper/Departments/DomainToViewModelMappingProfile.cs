using AutoMapper;
using LodgerPms.Application.ViewModels.Deparments;
using LodgerPms.Domain.Departments.Models;


namespace LodgerPms.Application.AutoMapper.Departments
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Department, DepartmentViewModel>();
            CreateMap<DepartmentGroup, DepartmentGroupViewModel>();
            CreateMap<FolioPattern, FolioPatternViewModel>();
        }
    }
}
