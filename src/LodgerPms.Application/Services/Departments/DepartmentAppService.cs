using AutoMapper;
using LodgerPms.Application.EventSourcedNormalizers.Departments;
using LodgerPms.Application.Interfaces.Departments;
using LodgerPms.Application.ViewModels.Deparments;
using LodgerPms.Domain.Core.Bus;
using LodgerPms.Domain.Departments.Commands;
using LodgerPms.Domain.Departments.Interfaces;
using LodgerPms.EventStoreSqlDataLayer.Repository.EventSourcing;
using System;
using System.Collections.Generic; 

namespace LodgerPms.Application.Services.Departments
{
    public class DepartmentAppService: IDeparmentAppService
    {
        private readonly IMapper _mapper;
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IEventStoreRepository _eventStoreRepository;
        private readonly IBus Bus;

        public DepartmentAppService(IMapper mapper, IDepartmentRepository departmentRepository, IEventStoreRepository eventStoreRepository, IBus bus)
        {

            this._mapper = mapper;
            this._departmentRepository = departmentRepository;
            this._eventStoreRepository = eventStoreRepository;
            this.Bus = bus;

        }
        public IEnumerable<DepartmentViewModel> GetAll()
        {
            return _mapper.Map<IEnumerable<DepartmentViewModel>>(_departmentRepository.GetAll());

        }
        public DepartmentViewModel GetById(string id)
        {
            return _mapper.Map<DepartmentViewModel>(_departmentRepository.GetById(id));

        }
        public void Register(DepartmentViewModel departmentViewModel)
        {
            var registerCommand = _mapper.Map<RegisterNewDepartmentCommand>(departmentViewModel);
            Bus.SendCommand(registerCommand);

        }


        public void Update(DepartmentViewModel departmentViewModel)
        {
            var updateCommand = _mapper.Map<UpdateDepartmentCommand>(departmentViewModel);
            Bus.SendCommand(updateCommand);

        }
        public void Remove(string id)
        {
            var removeCommand = new RemoveDepartmentCommand(id);
            Bus.SendCommand(removeCommand);

        }
        public IList<DepartmentHistoryData> GetAllHistory(string id)
        {
            return DepartmentHistory.ToJavaScriptDepartmentHistory(_eventStoreRepository.All(id));
        }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
