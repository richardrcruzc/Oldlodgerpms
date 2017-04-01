using LodgerPms.Domain.Core.Events;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LodgerPms.Application.EventSourcedNormalizers.Departments
{
    public class DepartmentHistory
    {
        public static IList<DepartmentHistoryData> HistoryData { get; set; }
        public static IList<DepartmentHistoryData> ToJavaScriptDepartmentHistory(IList<StoredEvent> storedEvents)
        {
            HistoryData = new List<DepartmentHistoryData>();
            DepartmentHistoryDeserializer(storedEvents);

            var sorted = HistoryData.OrderBy(c => c.When);
            var list = new List<DepartmentHistoryData>();
            var last = new DepartmentHistoryData();

            foreach (var change in sorted)
            {
                var jsSlot = new DepartmentHistoryData
                {
                    Id = change.Id == Guid.Empty.ToString() || change.Id == last.Id
                        ? ""
                        : change.Id,
                    Description = string.IsNullOrWhiteSpace(change.Description) || change.Description == last.Description
                        ? ""
                        : change.Description,
                    Amount = string.IsNullOrWhiteSpace(change.Amount.ToString()) || change.Amount == last.Amount
                        ? 0M
                        : change.Amount,
                   ApplyTax    = change.ApplyTax || change.ApplyTax == last.ApplyTax
                        ? false
                        : change.ApplyTax,
                    Percentage   = string.IsNullOrWhiteSpace(change.Percentage.ToString()) || change.Percentage == last.Percentage
                        ? 0M
                        : change.Percentage,
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
                var slot = new DepartmentHistoryData();
                dynamic values;

                switch (e.MessageType)
                {
                    case "DepartmentRegisteredEvent":
                        values = JsonConvert.DeserializeObject<dynamic>(e.Data);
                        slot.Description = values["Description"];
                        slot.Amount = values["Amount"];
                        slot.ApplyTax = values["ApplyTax"];
                        slot.Percentage = values["Percentage"];
                        slot.Action = "Registered";
                        slot.When = values["Timestamp"];
                        slot.Id = values["Id"];
                        slot.Who = e.User;
                        break;
                    case "DepartmentUpdatedEvent":
                        values = JsonConvert.DeserializeObject<dynamic>(e.Data);
                        slot.Description = values["Description"];
                        slot.Amount = values["Amount"];
                        slot.ApplyTax = values["ApplyTax"];
                        slot.Percentage = values["Percentage"];
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
