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
    public class DepartmentGroupAppService: IDepartmentGroupAppService
    {
        private readonly IMapper _mapper;
        private readonly IDepartmentGroupRepository _departmentGrRepository;
        private readonly IEventStoreRepository _eventStoreRepository;
        private readonly IBus Bus;

        public DepartmentGroupAppService(IMapper mapper, IDepartmentGroupRepository departmentRepository, 
            IEventStoreRepository eventStoreRepository, IBus bus)
        {

            this._mapper = mapper;
            this._departmentGrRepository = departmentRepository;
            this._eventStoreRepository = eventStoreRepository;
            this.Bus = bus;

        }
        public IEnumerable<DepartmentGroupViewModel> GetAll()
        {
            return _mapper.Map<IEnumerable<DepartmentGroupViewModel>>(_departmentGrRepository.GetAll());

        }
        public DepartmentGroupViewModel GetById(string id)
        {
            return _mapper.Map<DepartmentGroupViewModel>(_departmentGrRepository.GetById(id));

        }
        public DepartmentGroup FindById(string id)
        {
            return _departmentGrRepository.GetById(id);

        }
        public void Register(DepartmentGroupViewModel DepartmentGroupViewModel)
        {
            var registerCommand = _mapper.Map<RegisterNewDepartmentGroupCommand>(DepartmentGroupViewModel);
            Bus.SendCommand(registerCommand);

        }


        public void Update(DepartmentGroupViewModel DepartmentGroupViewModel)
        {
            var updateCommand = _mapper.Map<UpdateDepartmentGroupCommand>(DepartmentGroupViewModel);
            Bus.SendCommand(updateCommand);

        }
        public void Remove(string id)
        {
            var removeCommand = new RemoveDepartmentGroupCommand(id);
            Bus.SendCommand(removeCommand);

        }
        public IList<DepartmentGroupHistoryData> GetAllHistory(string id)
        {
            return DepartmentGroupHistory.ToJavaScriptDepartmentHistory(_eventStoreRepository.All(id));
        }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
         
    }
}
