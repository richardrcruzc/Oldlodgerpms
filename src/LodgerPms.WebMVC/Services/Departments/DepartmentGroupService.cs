using LodgerPms.WebMVC.ViewModels.Departments;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.eShopOnContainers.BuildingBlocks.Resilience.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LodgerPms.WebMVC.Services.Departments
{
    public class DepartmentGroupService: IDepartmentGroupService
    {
        private readonly IOptionsSnapshot<AppSettings> _settings;
        private IHttpClient _apiClient;
        private readonly string _remoteServiceBaseUrl;

        public DepartmentGroupService(IOptionsSnapshot<AppSettings> settings, ILoggerFactory loggerFactory, IHttpClient httpClient)
        {
            _settings = settings;
            _remoteServiceBaseUrl = $"{_settings.Value.DepartmentUrl}/api/v1/departmentgroup/";
            _apiClient = httpClient;
            var log = loggerFactory.CreateLogger("departmentgroup service");
            log.LogDebug(settings.Value.DepartmentUrl);
        }

        public async Task<DepartmentGroupViewModel> GetDepartmentGroups(int page, int take)
        {
            var departmentUrl = $"{_remoteServiceBaseUrl}items?pageIndex={page}&pageSize={take}";
            var dataString = "";
            //
            // Using a HttpClient wrapper with Retry and Exponential Backoff
            //
            dataString = await _apiClient.GetStringAsync(departmentUrl);

            var response = JsonConvert.DeserializeObject<DepartmentGroupViewModel>(dataString);

            return response;

        }

        async public Task Create(DepartmentGroup depto) {
            var deptoUrl = $"{_remoteServiceBaseUrl}/create";

            var response = await _apiClient.PostAsync(deptoUrl, depto);

            if (response.StatusCode == System.Net.HttpStatusCode.InternalServerError)
                throw new Exception("Error creating DepartmentGroup, try later");

            response.EnsureSuccessStatusCode();
        }
        async public Task Update(DepartmentGroup depto) {
            var deptoUrl = $"{_remoteServiceBaseUrl}/update";

            var response = await _apiClient.PostAsync(deptoUrl, depto);

            if (response.StatusCode == System.Net.HttpStatusCode.InternalServerError)
                throw new Exception("Error creating DepartmentGroup, try later");

            response.EnsureSuccessStatusCode();

        }
        async public Task Delete(string id) {
            var deptoUrl = $"{_remoteServiceBaseUrl}/id";

            var response = await _apiClient.PostAsync(deptoUrl, id);

            if (response.StatusCode == System.Net.HttpStatusCode.InternalServerError)
                throw new Exception("Error deleting DepartmentGroup, try later");

            response.EnsureSuccessStatusCode();
        }
    }
}
