using LodgerPms.Application.EventSourcedNormalizers.Departments;
using LodgerPms.Application.ViewModels.Deparments;
using System;
using System.Collections.Generic;

namespace LodgerPms.Application.Interfaces.Departments
{
    public interface IDeparmentAppService : IDisposable
    {
        void Register(DepartmentViewModel departmentViewModel);
        IEnumerable<DepartmentViewModel> GetAll();
        DepartmentViewModel GetById(string id);
        void Update(DepartmentViewModel departmentViewModel);
        void Remove(string id);
        IList<DepartmentHistoryData> GetAllHistory(string id);
    }
}
