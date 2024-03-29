﻿using AutoMapper;
using LodgerPms.Application.Interfaces.Departments;
using LodgerPms.Application.Services.Departments;
using LodgerPms.DepartmentsDataLayer.Context;
using LodgerPms.DepartmentsDataLayer.Repository;
using LodgerPms.DepartmentsDataLayer.UoW;
using LodgerPms.Domain.Core.Bus;
using LodgerPms.Domain.Core.Events;
using LodgerPms.Domain.Core.Notifications;
using LodgerPms.Domain.Departments.CommandHandlers;
using LodgerPms.Domain.Departments.Commands;
using LodgerPms.Domain.Departments.EventHandlers;
using LodgerPms.Domain.Departments.Events;
using LodgerPms.Domain.Departments.Interfaces;
using LodgerPms.Domain.folioPatterns.CommandHandlers;
using LodgerPms.Domain.Interface.Interfaces;
using LodgerPms.EventStoreSqlDataLayer.Context;
using LodgerPms.EventStoreSqlDataLayer.EventSourcing;
using LodgerPms.EventStoreSqlDataLayer.Repository.EventSourcing;
using LodgerPms.Infra.CrossCutting.Bus;
using LodgerPms.Infra.CrossCutting.Identity.Authorization;
using LodgerPms.Infra.CrossCutting.Identity.Inteface;
using LodgerPms.Infra.CrossCutting.Identity.Models;
using LodgerPms.Infra.CrossCutting.Identity.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace LodgerPms.Infra.CrossCutting.IoC
{
    public class SimpleInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // ASP.NET HttpContext dependency
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            // ASP.NET Authorization Polices
            services.AddSingleton<IAuthorizationHandler, ClaimsRequirementHandler>();
            services.AddSingleton(Mapper.Configuration);
            services.AddScoped<IMapper>(sp => new Mapper(sp.GetRequiredService<IConfigurationProvider>(), sp.GetService));
            services.AddScoped<IDeparmentAppService, DepartmentAppService>();
            services.AddScoped<IDepartmentGroupAppService, DepartmentGroupAppService>();
            services.AddScoped<IFolioPatternAppService, FolioPatternAppService>();

            // Domain - Events
            services.AddScoped<IDomainNotificationHandler<DomainNotification>, DomainNotificationHandler>();
            services.AddScoped<IHandler<DepartmentRegisteredEvent>, DepartmentEventHandler>();
            services.AddScoped<IHandler<DepartmentUpdatedEvent>, DepartmentEventHandler>();
            services.AddScoped<IHandler<DepartmentRemovedEvent>, DepartmentEventHandler>();

            services.AddScoped<IHandler<DepartmentGroupRegisteredEvent>, DepartmentGroupEventHandler>();
            services.AddScoped<IHandler<DepartmentGroupUpdatedEvent>, DepartmentGroupEventHandler>();
            services.AddScoped<IHandler<FolioPatternRemovedEvent>, DepartmentGroupEventHandler>();
              

            // Domain - Commands
            //department
            services.AddScoped<IHandler<RegisterNewDepartmentCommand>, DepartmentCommandHandler>();
            services.AddScoped<IHandler<UpdateDepartmentCommand>, DepartmentCommandHandler>();
            services.AddScoped<IHandler<RemoveDepartmentCommand>, DepartmentCommandHandler>();

            //department group
            services.AddScoped<IHandler<RegisterNewDepartmentGroupCommand>, DepartmentGroupCommandHandler>();
            services.AddScoped<IHandler<UpdateDepartmentGroupCommand>, DepartmentGroupCommandHandler>();
            services.AddScoped<IHandler<RemoveDepartmentGroupCommand>, DepartmentGroupCommandHandler>();

            //Folio Pattern
            services.AddScoped<IHandler<RegisterNewFolioPatternCommand>, FolioPatternCommandHandler>();
            services.AddScoped<IHandler<UpdateFolioPatternCommand>, FolioPatternCommandHandler>();
            services.AddScoped<IHandler<RemoveFolioPatternCommand>, FolioPatternCommandHandler>();


            //repository
            services.AddScoped<IDepartmentRepository, DepartmentRepository>();
            services.AddScoped<IDepartmentGroupRepository, DepartmentGroupRepository>();
            services.AddScoped<IFolioPatternRepository, FolioPatternRepository>();            
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<DepartmentsContext>();

            // Infra - Data EventSourcing
            services.AddScoped<IEventStoreRepository, EventStoreSQLRepository>();
            services.AddScoped<IEventStore, SqlEventStore>();
            services.AddScoped<EventStoreSQLContext>();


            // Infra - Identity Services
            services.AddTransient<IEmailSender, AuthEmailMessageSender>();
            services.AddTransient<ISmsSender, AuthSMSMessageSender>();

            // Infra - Identity
            services.AddScoped<IUser, AspNetUser>();

            // Infra - Bus
            services.AddScoped<IBus, InMemoryBus>();
        }
        }
}
