

using AutoMapper;
using LodgerPms.Application.ViewModels.Deparments;
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


            CreateMap<DepartmentGroupViewModel, RegisterNewDepartmentGroupCommand>()
               .ConstructUsing(d => new RegisterNewDepartmentGroupCommand(d.Code,  d.Description));
            CreateMap<DepartmentGroupViewModel, UpdateDepartmentGroupCommand>()
                .ConstructUsing(d => new UpdateDepartmentGroupCommand(d.Id, d.Code,  d.Description));


            CreateMap<FolioPatternViewModel, RegisterNewFolioPatternCommand>()
           .ConstructUsing(d => new RegisterNewFolioPatternCommand(d.Code, d.Description));
            CreateMap<FolioPatternViewModel, UpdateFolioPatternCommand>()
                .ConstructUsing(d => new UpdateFolioPatternCommand(d.Id, d.Code, d.Description));

        }
    }
}
