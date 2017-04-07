using LodgerPms.Application.EventSourcedNormalizers.Departments;
using LodgerPms.Application.ViewModels.Deparments;
using LodgerPms.Domain.Departments.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LodgerPms.Application.Interfaces.Departments
{ 
    public interface IFolioPatternAppService : IDisposable
    {
        void Register(FolioPatternViewModel model);
        IEnumerable<FolioPatternViewModel> GetAll();
        FolioPatternViewModel GetById(string id);
        FolioPattern FindById(string id);
        void Update(FolioPatternViewModel model);
        void Remove(string id);
       // IList<FolioPatternHistoryData> GetAllHistory(string id);
    }
}
