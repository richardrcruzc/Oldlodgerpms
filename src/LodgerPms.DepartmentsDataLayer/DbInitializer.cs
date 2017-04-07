using LodgerPms.DepartmentsDataLayer.Context;
using LodgerPms.Domain.Departments.Models;
using System;
using System.Linq;

namespace LodgerPms.DepartmentsDataLayer
{
    public static class DbInitializer
    {
        public static void Initialize(DepartmentsContext cntxt)
        {
            if (!cntxt.DepartmentGroups.Any())
            {
                var dg = DepartmentGroup.Create("MIS", "Miscellaneous");
                cntxt.DepartmentGroups.Add(dg);
                dg = DepartmentGroup.Create("LAU", "Laundry");
                cntxt.DepartmentGroups.Add(dg); 
                dg = DepartmentGroup.Create("ROR"  ,"Room Revenue");
                cntxt.DepartmentGroups.Add(dg);
                dg = DepartmentGroup.Create("F&B", "Food & Beverage");
                cntxt.DepartmentGroups.Add(dg);
                dg = DepartmentGroup.Create("SAF", "SAF Group");
                cntxt.DepartmentGroups.Add(dg);
                dg = DepartmentGroup.Create("ADJ", "Adjustment (+)");
                cntxt.DepartmentGroups.Add(dg);
                dg = DepartmentGroup.Create("TAX",  "Taxes	");
                cntxt.DepartmentGroups.Add(dg);
                cntxt.SaveChanges();
            }
                if (!cntxt.Departments.Any())
            {
                var mis = cntxt.DepartmentGroups.SingleOrDefault(l=>l.Code== "MIS");
                var lau = cntxt.DepartmentGroups.SingleOrDefault(l => l.Code == "LAU");
                var ror = cntxt.DepartmentGroups.SingleOrDefault(l => l.Code == "ROR");
                var fb = cntxt.DepartmentGroups.SingleOrDefault(l => l.Code == "F&B");
                var saf = cntxt.DepartmentGroups.SingleOrDefault(l => l.Code == "ADJ");
                var tax = cntxt.DepartmentGroups.SingleOrDefault(l => l.Code == "TAX");


                var d = Department.Create(Guid.NewGuid().ToString(), lau, DepartmentType.Debit, "Laundry", false,10, 0);
               cntxt.Departments.Add(d);
                  d = Department.Create(Guid.NewGuid().ToString(), mis, DepartmentType.Debit, "Minibar", false, 10, 0);
                cntxt.Departments.Add(d);
                d = Department.Create(Guid.NewGuid().ToString(), ror, DepartmentType.Debit, "Room Upgrade Charge", false, 10, 0);
                cntxt.Departments.Add(d);
                d = Department.Create(Guid.NewGuid().ToString(), mis, DepartmentType.Debit, "Collect Call", false, 10, 0);
                cntxt.Departments.Add(d);
                d = Department.Create(Guid.NewGuid().ToString(), fb, DepartmentType.Debit, "Lunch	", false, 10, 0);
                cntxt.Departments.Add(d);
                d = Department.Create(Guid.NewGuid().ToString(), ror, DepartmentType.Debit, "Room Extra Bed", false, 10, 0);
                cntxt.Departments.Add(d);
                d = Department.Create(Guid.NewGuid().ToString(), tax, DepartmentType.Debit, "Room VAT", false, 10, 0);
                cntxt.Departments.Add(d);
                d = Department.Create(Guid.NewGuid().ToString(), fb, DepartmentType.Debit, "La Tasca F&B", false, 10, 0);
                cntxt.Departments.Add(d);
                d = Department.Create(Guid.NewGuid().ToString(), fb, DepartmentType.Debit, "Pool Bar F&B", false, 10, 0);
                cntxt.Departments.Add(d);
                d = Department.Create(Guid.NewGuid().ToString(), fb, DepartmentType.Debit, "Room Service F&B", false, 10, 0);
                cntxt.Departments.Add(d);
                d = Department.Create(Guid.NewGuid().ToString(), fb, DepartmentType.Debit, "Dinner	", false, 10, 0);
                cntxt.Departments.Add(d);
                d = Department.Create(Guid.NewGuid().ToString(), saf, DepartmentType.Debit, "Transfer Debit (DO NOT USE !)", false, 10, 0);
                cntxt.Departments.Add(d);
                d = Department.Create(Guid.NewGuid().ToString(), ror, DepartmentType.Credit, "Room Discount", false, 10, 0);
                cntxt.Departments.Add(d);
                d = Department.Create(Guid.NewGuid().ToString(), ror, DepartmentType.Debit, "Room Charge", false, 10, 0);
                cntxt.Departments.Add(d);
                d = Department.Create(Guid.NewGuid().ToString(), ror, DepartmentType.Debit, "Room Child in Bed with Parents", false, 10, 0);
                cntxt.Departments.Add(d);
                d = Department.Create(Guid.NewGuid().ToString(), ror, DepartmentType.Credit, "Rebate Room No Show", false, 10, 0);
                cntxt.Departments.Add(d);
                d = Department.Create(Guid.NewGuid().ToString(), ror, DepartmentType.Credit, "Rebate Room Day Use", false, 10, 0);
                cntxt.Departments.Add(d);
                d = Department.Create(Guid.NewGuid().ToString(), ror, DepartmentType.Credit, "Rebate Room Early Check-out", false, 10, 0);
                cntxt.Departments.Add(d);
                d = Department.Create(Guid.NewGuid().ToString(), ror, DepartmentType.Credit, "Rebate Room Cancellation Charge", false, 10, 0);
                cntxt.Departments.Add(d);
                d = Department.Create(Guid.NewGuid().ToString(), ror, DepartmentType.Credit, "Rebate Room Upgrade Charge", false, 10, 0);
                cntxt.Departments.Add(d);
                d = Department.Create(Guid.NewGuid().ToString(), ror, DepartmentType.Credit, "Rebate Room Charge", false, 10, 0);
                cntxt.Departments.Add(d);
                d = Department.Create(Guid.NewGuid().ToString(), tax, DepartmentType.Debit, "Provincial Room Tax", false, 10, 0);
                cntxt.Departments.Add(d);
                d = Department.Create(Guid.NewGuid().ToString(), ror, DepartmentType.Debit, "Room No Show", false, 10, 0);
                cntxt.Departments.Add(d);
                d = Department.Create(Guid.NewGuid().ToString(), ror, DepartmentType.Debit, "Room Day Use", false, 10, 0);
                cntxt.Departments.Add(d);
                d = Department.Create(Guid.NewGuid().ToString(), ror, DepartmentType.Debit, "Room Cancellation Charge", false, 10, 0);
                cntxt.Departments.Add(d);
                d = Department.Create(Guid.NewGuid().ToString(), fb, DepartmentType.Debit, "Fino F&B", false, 10, 0);
                cntxt.Departments.Add(d);
                d = Department.Create(Guid.NewGuid().ToString(), fb, DepartmentType.Credit, "La Tasca Rebate", false, 10, 0);
                cntxt.Departments.Add(d);
                d = Department.Create(Guid.NewGuid().ToString(), ror, DepartmentType.Credit, "Room Service Rebate", false, 10, 0);
                cntxt.Departments.Add(d);
                d = Department.Create(Guid.NewGuid().ToString(), fb, DepartmentType.Credit, "Pool Bar Rebate", false, 10, 0);
                cntxt.Departments.Add(d);
                d = Department.Create(Guid.NewGuid().ToString(), ror, DepartmentType.Debit, "Room Early Check-out", false, 10, 0);
                cntxt.Departments.Add(d);


                cntxt.Departments.Add(d);
                d = Department.Create(Guid.NewGuid().ToString(), ror, DepartmentType.Debit, "Room Late Check-in", false, 10, 0);
                cntxt.Departments.Add(d);
                d = Department.Create(Guid.NewGuid().ToString(), fb, DepartmentType.Debit, "Lime Bar F&B", false, 10, 0);
                cntxt.Departments.Add(d);
                d = Department.Create(Guid.NewGuid().ToString(), fb, DepartmentType.Credit, "Lime Bar Rebate", false, 10, 0);
                cntxt.Departments.Add(d);
                d = Department.Create(Guid.NewGuid().ToString(), ror, DepartmentType.Debit, "Room Correction	", false, 10, 0);
                cntxt.Departments.Add(d);
                d = Department.Create(Guid.NewGuid().ToString(), mis, DepartmentType.Debit, "Tips", false, 10, 0);
                cntxt.Departments.Add(d);
                d = Department.Create(Guid.NewGuid().ToString(), fb, DepartmentType.Debit, "Breakfast", false, 10, 0);
                cntxt.Departments.Add(d);
                d = Department.Create(Guid.NewGuid().ToString(), fb, DepartmentType.Debit, "Halfboard Package Charge", false, 10, 0);
                cntxt.Departments.Add(d);
                d = Department.Create(Guid.NewGuid().ToString(), fb, DepartmentType.Debit, "Fullboard Package Charge", false, 10, 0);
                cntxt.Departments.Add(d);
                d = Department.Create(Guid.NewGuid().ToString(), fb, DepartmentType.Debit, "All Inclusive Package Charge", false, 10, 0);
                cntxt.Departments.Add(d);
                d = Department.Create(Guid.NewGuid().ToString(), mis, DepartmentType.Debit, "Local Call", false, 10, 0);
                cntxt.Departments.Add(d);
                d = Department.Create(Guid.NewGuid().ToString(), mis, DepartmentType.Debit, "Long Distance Call", false, 10, 0);
                cntxt.Departments.Add(d);
                d = Department.Create(Guid.NewGuid().ToString(), mis, DepartmentType.Debit, "Oversea Call", false, 10, 0);
                cntxt.Departments.Add(d);

                d = Department.Create(Guid.NewGuid().ToString(), mis, DepartmentType.Debit, "Fax", false, 10, 0);
                cntxt.Departments.Add(d);

                d = Department.Create(Guid.NewGuid().ToString(), mis, DepartmentType.Debit, "Internet	", false, 10, 0);
                cntxt.Departments.Add(d);
                d = Department.Create(Guid.NewGuid().ToString(), saf, DepartmentType.Debit, "Gala Dinner Christmas Eve", false, 10, 0);
                cntxt.Departments.Add(d);
                d = Department.Create(Guid.NewGuid().ToString(), saf, DepartmentType.Debit, "Gala Dinner New Year Eve", false, 10, 0);
                cntxt.Departments.Add(d);
                d = Department.Create(Guid.NewGuid().ToString(), saf, DepartmentType.Debit, "Special F&B Charge", false, 10, 0);
                cntxt.Departments.Add(d);
                d = Department.Create(Guid.NewGuid().ToString(), saf, DepartmentType.Debit, "Activities & Sport Charge", false, 10, 0);
                cntxt.Departments.Add(d);
                d = Department.Create(Guid.NewGuid().ToString(), saf, DepartmentType.Debit, "Wedding Package Charge", false, 10, 0);
                cntxt.Departments.Add(d);
                d = Department.Create(Guid.NewGuid().ToString(), saf, DepartmentType.Debit, "Meeting Package Charge", false, 10, 0);
                cntxt.Departments.Add(d);
                d = Department.Create(Guid.NewGuid().ToString(), saf, DepartmentType.Debit, "Spa Package Charge", false, 10, 0);
                cntxt.Departments.Add(d);
                d = Department.Create(Guid.NewGuid().ToString(), saf, DepartmentType.Debit, "Transportation Package Charge", false, 10, 0);
                cntxt.Departments.Add(d);



                d = Department.Create(Guid.NewGuid().ToString(), mis, DepartmentType.Debit, "Airport Transfer", false, 10, 0);
                cntxt.Departments.Add(d);
                d = Department.Create(Guid.NewGuid().ToString(), mis, DepartmentType.Debit, "Shuttle Bus", false, 10, 0);
                cntxt.Departments.Add(d);
                d = Department.Create(Guid.NewGuid().ToString(), mis, DepartmentType.Debit, "Taxi Service & Transfer", false, 10, 0);
                cntxt.Departments.Add(d);
                d = Department.Create(Guid.NewGuid().ToString(), mis, DepartmentType.Debit, "Excursion Tours", false, 10, 0);
                cntxt.Departments.Add(d);
                d = Department.Create(Guid.NewGuid().ToString(), mis, DepartmentType.Debit, "Photocopy", false, 10, 0);
                cntxt.Departments.Add(d);
                d = Department.Create(Guid.NewGuid().ToString(), mis, DepartmentType.Debit, "Meeting Equipment Rental", false, 10, 0);
                cntxt.Departments.Add(d);
                d = Department.Create(Guid.NewGuid().ToString(), mis, DepartmentType.Debit, "In Room Entertain Rental", false, 10, 0);
                cntxt.Departments.Add(d);
                d = Department.Create(Guid.NewGuid().ToString(), mis, DepartmentType.Debit, "Gifts & Souvenir", false, 10, 0);
                cntxt.Departments.Add(d);
                d = Department.Create(Guid.NewGuid().ToString(), mis, DepartmentType.Debit, "Spa Treatment/Service", false, 10, 0);
                cntxt.Departments.Add(d);
                d = Department.Create(Guid.NewGuid().ToString(), mis, DepartmentType.Debit, "Outdoor Massage & Beauty", false, 10, 0);
                cntxt.Departments.Add(d);
                d = Department.Create(Guid.NewGuid().ToString(), mis, DepartmentType.Debit, "Visitor/Joiner Register", false, 10, 0);
                cntxt.Departments.Add(d);
                d = Department.Create(Guid.NewGuid().ToString(), mis, DepartmentType.Debit, "Doctor Visit Service", false, 10, 0);
                cntxt.Departments.Add(d);
                d = Department.Create(Guid.NewGuid().ToString(), mis, DepartmentType.Debit, "Car/Bike Rental", false, 10, 0);
                cntxt.Departments.Add(d);
                d = Department.Create(Guid.NewGuid().ToString(), mis, DepartmentType.Debit, "Golf Green Fee", false, 10, 0);
                cntxt.Departments.Add(d);
                d = Department.Create(Guid.NewGuid().ToString(), mis, DepartmentType.Debit, "Missing or Broken Hotel Asset", false, 10, 0);
                cntxt.Departments.Add(d);
                d = Department.Create(Guid.NewGuid().ToString(), mis, DepartmentType.Debit, "Pay Movie Charge", false, 10, 0);
                cntxt.Departments.Add(d);
                d = Department.Create(Guid.NewGuid().ToString(), mis, DepartmentType.Debit, "Other Miscellaneous Charge", false, 10, 0);
                cntxt.Departments.Add(d);
                d = Department.Create(Guid.NewGuid().ToString(), mis, DepartmentType.Credit, "MIS Rebate", false, 10, 0);
                cntxt.Departments.Add(d);
                d = Department.Create(Guid.NewGuid().ToString(), saf, DepartmentType.Credit, "SAF Rebate", false, 10, 0);
                cntxt.Departments.Add(d);
                d = Department.Create(Guid.NewGuid().ToString(), mis, DepartmentType.Debit, "Play & Chat", false, 10, 0);
                cntxt.Departments.Add(d);
                d = Department.Create(Guid.NewGuid().ToString(), mis, DepartmentType.Debit, "Room Extra Teen (12-17 yrs)", false, 10, 0);
                cntxt.Departments.Add(d);
                d = Department.Create(Guid.NewGuid().ToString(), mis, DepartmentType.Debit, "Minimarket", false, 10, 0);
                cntxt.Departments.Add(d);
                d = Department.Create(Guid.NewGuid().ToString(), mis, DepartmentType.Debit, "Welcome Package", false, 10, 0);
                cntxt.Departments.Add(d);
                d = Department.Create(Guid.NewGuid().ToString(), mis, DepartmentType.Credit, "Minimarket Rebate", false, 10, 0);
                cntxt.Departments.Add(d);


                d = Department.Create(Guid.NewGuid().ToString(), mis, DepartmentType.Debit, "Bambino Package", false, 10, 0);
                cntxt.Departments.Add(d);
                d = Department.Create(Guid.NewGuid().ToString(), mis, DepartmentType.Debit, "Baby Cot", false, 10, 0);
                cntxt.Departments.Add(d);
                d = Department.Create(Guid.NewGuid().ToString(), mis, DepartmentType.Debit, "Trolley TCNE (Weekly)", false, 10, 0);
                cntxt.Departments.Add(d);
                d = Department.Create(Guid.NewGuid().ToString(), ror, DepartmentType.Debit, "Room Extra Adult (18 over)", false, 10, 0);
                cntxt.Departments.Add(d);
                d = Department.Create(Guid.NewGuid().ToString(), mis, DepartmentType.Debit, "Trolley (Daily)", false, 10, 0);
                cntxt.Departments.Add(d);
                d = Department.Create(Guid.NewGuid().ToString(), ror, DepartmentType.Credit, "Rebate Room Extra Bed", false, 10, 0);
                cntxt.Departments.Add(d);
                d = Department.Create(Guid.NewGuid().ToString(), ror, DepartmentType.Credit, "Rebate Room Child in Bed", false, 10, 0);
                cntxt.Departments.Add(d);
                d = Department.Create(Guid.NewGuid().ToString(), ror, DepartmentType.Credit, "Rebate Room Discount", false, 10, 0);
                cntxt.Departments.Add(d);
                d = Department.Create(Guid.NewGuid().ToString(), mis, DepartmentType.Debit, "Welcome Package", false, 10, 0);
                cntxt.Departments.Add(d);
                d = Department.Create(Guid.NewGuid().ToString(), ror, DepartmentType.Debit, "Room Extra Child (Under 12)", false, 10, 0);
                cntxt.Departments.Add(d);

                cntxt.SaveChanges();

            }


            if (!cntxt.FolioPatterns.Any())
            {
                var f = FolioPattern.Create("BAR", "Barter");
                cntxt.FolioPatterns.Add(f);
                 f = FolioPattern.Create("VOU", "Gift Voucher");
                cntxt.FolioPatterns.Add(f);
                 f = FolioPattern.Create("COR", "Corporate");
                cntxt.FolioPatterns.Add(f);
                f = FolioPattern.Create("OWN", "Pay direct hotel");
                cntxt.FolioPatterns.Add(f);
                f = FolioPattern.Create("AGT", "Agent Account");
                cntxt.FolioPatterns.Add(f);
                cntxt.SaveChanges();
            }
        }
    }

}
