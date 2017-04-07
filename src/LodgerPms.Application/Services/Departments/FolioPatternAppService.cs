using AutoMapper;
using LodgerPms.Application.EventSourcedNormalizers.Departments;
using LodgerPms.Application.Interfaces.Departments;
using LodgerPms.Application.ViewModels.Deparments;
using LodgerPms.Domain.Core.Bus;
using LodgerPms.Domain.Departments.Commands;
using LodgerPms.Domain.Departments.Interfaces;
using LodgerPms.Domain.Departments.Models;
using LodgerPms.EventStoreSqlDataLayer.Repository.EventSourcing;
using System;
using System.Collections.Generic; 

namespace LodgerPms.Application.Services.Departments
{
    public class FolioPatternAppService: IFolioPatternAppService
    {
        private readonly IMapper _mapper;
        private readonly IFolioPatternRepository _departmentGrRepository;
        private readonly IEventStoreRepository _eventStoreRepository;
        private readonly IBus Bus;

        public FolioPatternAppService(IMapper mapper, 
            IFolioPatternRepository departmentRepository, 
            IEventStoreRepository eventStoreRepository, IBus bus)
        {

            this._mapper = mapper;
            this._departmentGrRepository = departmentRepository;
            this._eventStoreRepository = eventStoreRepository;
            this.Bus = bus;

        }
        public IEnumerable<FolioPatternViewModel> GetAll()
        {
            return _mapper.Map<IEnumerable<FolioPatternViewModel>>(_departmentGrRepository.GetAll());

        }
        public FolioPatternViewModel GetById(string id)
        {
            return _mapper.Map<FolioPatternViewModel>(_departmentGrRepository.GetById(id));

        }
        public FolioPattern FindById(string id)
        {
            return _departmentGrRepository.GetById(id);

        }
        public void Register(FolioPatternViewModel FolioPatternViewModel)
        {
            var registerCommand = _mapper.Map<RegisterNewFolioPatternCommand>(FolioPatternViewModel);
            Bus.SendCommand(registerCommand);

        }


        public void Update(FolioPatternViewModel FolioPatternViewModel)
        {
            var updateCommand = _mapper.Map<UpdateFolioPatternCommand>(FolioPatternViewModel);
            Bus.SendCommand(updateCommand);

        }
        public void Remove(string id)
        {
            var removeCommand = new RemoveFolioPatternCommand(id);
            Bus.SendCommand(removeCommand);

        }
        //public IList<FolioPatternHistoryData> GetAllHistory(string id)
        //{
        //    return FolioPatternHistory.ToJavaScriptDepartmentHistory(_eventStoreRepository.All(id));
        //}
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
         
    }
}
