using LodgerPms.Application.EventSourcedNormalizers.Departments;
using LodgerPms.Application.ViewModels.Deparments;
using LodgerPms.Domain.Departments.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LodgerPms.Application.Interfaces.Departments
{ 
    public interface IDepartmentGroupAppService : IDisposable
    {
        void Register(DepartmentGroupViewModel model);
        IEnumerable<DepartmentGroupViewModel> GetAll();
        DepartmentGroupViewModel GetById(string id);
        DepartmentGroup FindById(string id);
        void Update(DepartmentGroupViewModel model);
        void Remove(string id);
        IList<DepartmentGroupHistoryData> GetAllHistory(string id);
    }
}
