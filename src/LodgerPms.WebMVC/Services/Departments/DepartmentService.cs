using LodgerPms.WebMVC.ViewModels.Departments;
using Microsoft.AspNetCore.Http;
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
    public class DepartmentService: IDepartmentService
    {
        private readonly IOptionsSnapshot<AppSettings> _settings;
        private IHttpClient _apiClient;
        private readonly string _remoteServiceBaseUrl;
        private readonly IHttpContextAccessor _httpContextAccesor;

        public DepartmentService(IOptionsSnapshot<AppSettings> settings, ILoggerFactory loggerFactory, IHttpClient httpClient)
        {
            _settings = settings;
            _remoteServiceBaseUrl = $"{_settings.Value.DepartmentUrl}/api/v1/department/";
            _apiClient = httpClient;
            var log = loggerFactory.CreateLogger("department service");
            log.LogDebug(settings.Value.DepartmentUrl);
        }

        public async Task<DepartmentViewModel> GetDepartments(int page, int take, string groupQs = null, string typeQs = null)
        {
            var itemsQs = $"items?pageIndex={page}&pageSize={take}";
            var filterQs = "";

            if (groupQs != null || typeQs != null)
            {
                filterQs = $"/type/{typeQs}/group/{groupQs}";
            }

            var departmentUrl = $"{_remoteServiceBaseUrl}items{filterQs}?pageIndex={page}&pageSize={take}";
            var dataString = "";
            //
            // Using a HttpClient wrapper with Retry and Exponential Backoff
            //
            dataString = await _apiClient.GetStringAsync(departmentUrl);

            var response = JsonConvert.DeserializeObject<DepartmentViewModel>(dataString);

            return response;

        }
        public async Task<IEnumerable<SelectListItem>> GetDepartmentGroup() {

            var url = $"{_remoteServiceBaseUrl}departmentGroups";
            var dataString = await _apiClient.GetStringAsync(url);

            var items = new List<SelectListItem>();
            items.Add(new SelectListItem() { Value = null, Text = "All", Selected = true });

            JArray groups = JArray.Parse(dataString);
            foreach (JObject group in groups.Children<JObject>())
            {
                items.Add(new SelectListItem()
                {
                    Value = group.Value<string>("id"),
                    Text = group.Value<string>("group")
                });
            }

            return items;
        }
        async public Task Create(Department depto) {          

            var deptoUrl = $"{_remoteServiceBaseUrl}/create";             
           
            var response = await _apiClient.PostAsync(deptoUrl, depto);

            if (response.StatusCode == System.Net.HttpStatusCode.InternalServerError)
                throw new Exception("Error creating department, try later");

            response.EnsureSuccessStatusCode();

        }
        public async Task Update(Department depto) {

            var deptoUrl = $"{_remoteServiceBaseUrl}/update";

            var response = await _apiClient.PostAsync(deptoUrl, depto);

            if (response.StatusCode == System.Net.HttpStatusCode.InternalServerError)
                throw new Exception("Error updating department, try later");

            response.EnsureSuccessStatusCode();
        }
        public async Task Delete(string id) {
            var deptoUrl = $"{_remoteServiceBaseUrl}/id";

            var response = await _apiClient.PostAsync(deptoUrl, id);

            if (response.StatusCode == System.Net.HttpStatusCode.InternalServerError)
                throw new Exception("Error deleting department, try later");

            response.EnsureSuccessStatusCode();
        }
    }
}
