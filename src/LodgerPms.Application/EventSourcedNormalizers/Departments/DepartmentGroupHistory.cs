using LodgerPms.Domain.Core.Events;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LodgerPms.Application.EventSourcedNormalizers.Departments
{
 
    public class DepartmentGroupHistory
    {
        public static IList<DepartmentGroupHistoryData> HistoryData { get; set; }
        public static IList<DepartmentGroupHistoryData> ToJavaScriptDepartmentHistory(IList<StoredEvent> storedEvents)
        {
            HistoryData = new List<DepartmentGroupHistoryData>();
            DepartmentHistoryDeserializer(storedEvents);

            var sorted = HistoryData.OrderBy(c => c.When);
            var list = new List<DepartmentGroupHistoryData>();
            var last = new DepartmentGroupHistoryData();

            foreach (var change in sorted)
            {
                var jsSlot = new DepartmentGroupHistoryData
                {
                    Id = change.Id == Guid.Empty.ToString() || change.Id == last.Id
                        ? ""
                        : change.Id,
                    Description = string.IsNullOrWhiteSpace(change.Description) || change.Description == last.Description
                        ? ""
                        : change.Description,
                    Code = string.IsNullOrWhiteSpace(change.Code.ToString()) || change.Code == last.Code
                        ? ""
                        : change.Code,
                   
                    Action = string.IsNullOrWhiteSpace(change.Action) ? "" : change.Action,
                    When = change.When,
                    Who = change.Who
                };

                list.Add(jsSlot);
                last = change;
            }
            return list;
        }
        private static void DepartmentHistoryDeserializer(IEnumerable<StoredEvent> storedEvents)
        {
            foreach (var e in storedEvents)
            {
                var slot = new DepartmentGroupHistoryData();
                dynamic values;

                switch (e.MessageType)
                {
                    case "DepartmentRegisteredEvent":
                        values = JsonConvert.DeserializeObject<dynamic>(e.Data);
                        slot.Description = values["Description"];
                        slot.Code = values["Code"];
                       
                        slot.Action = "Registered";
                        slot.When = values["Timestamp"];
                        slot.Id = values["Id"];
                        slot.Who = e.User;
                        break;
                    case "DepartmentUpdatedEvent":
                        values = JsonConvert.DeserializeObject<dynamic>(e.Data);
                        slot.Description = values["Description"];
                        slot.Code = values["Code"];
                        slot.Action = "Updated";
                        slot.When = values["Timestamp"];
                        slot.Id = values["Id"];
                        slot.Who = e.User;
                        break;
                    case "DepartmentRemovedEvent":
                        values = JsonConvert.DeserializeObject<dynamic>(e.Data);
                        slot.Action = "Removed";
                        slot.When = values["Timestamp"];
                        slot.Id = values["Id"];
                        slot.Who = e.User;
                        break;
                }
                HistoryData.Add(slot);
            }
        }

    }
}
