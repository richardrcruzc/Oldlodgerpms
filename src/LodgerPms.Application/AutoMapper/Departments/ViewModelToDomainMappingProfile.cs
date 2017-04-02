

using AutoMapper;
using LodgerPms.Application.ViewModels.Deparments.Deparments;
using LodgerPms.Domain.Departments.Commands;

namespace LodgerPms.Application.AutoMapper.Departments
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<DepartmentViewModel, RegisterNewDepartmentCommand>()
                .ConstructUsing(d => new RegisterNewDepartmentCommand(d.DepartmentGroup,d.DepartmentType, d.Description, d.ApplyTax, d.Amount, d.Percentage));
            CreateMap<DepartmentViewModel, UpdateDepartmentCommand>()
                .ConstructUsing(d => new UpdateDepartmentCommand(d.Id, d.DepartmentGroup, d.DepartmentType, d.Description, d.ApplyTax, d.Amount, d.Percentage));
        }
    }
}
