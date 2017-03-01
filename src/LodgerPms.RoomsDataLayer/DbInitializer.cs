//using LodgerPms.Domain.Rooms;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace LodgerPms.RoomsDataLayer
//{
//    public class DbInitializer
//    {    
//        public static void Initialize(RoomsContext cntxt)
//        {
//            if (!cntxt.BedTypes.Any())
//            {
//                var bt = BedType.Create("TWN", "2 Twin Beds");
//                cntxt.BedTypes.AddAsync(bt);
//                bt = BedType.Create("DBL", "1 King Bed");
//                cntxt.BedTypes.AddAsync(bt);
//                bt = BedType.Create("HTW", "Hollywood Twin");
//                cntxt.BedTypes.AddAsync(bt);
//                bt = BedType.Create("FAM", "1 Double & 1 Twin");
//                cntxt.BedTypes.AddAsync(bt);
//                cntxt.SaveChangesAsync();
//            }

//            if (!cntxt.RoomFacilities.Any())
//            {
//                var f = RoomFacility.Create("TV", "TV");
//                cntxt.RoomFacilities.AddAsync(f);
//                f = RoomFacility.Create("COT", "Baby Cot");
//                cntxt.RoomFacilities.AddAsync(f);
//                f = RoomFacility.Create("HCH", "Baby High Chair");
//                cntxt.RoomFacilities.AddAsync(f);
//                f = RoomFacility.Create("TRO", "Trolley");
//                cntxt.RoomFacilities.AddAsync(f);
//                f = RoomFacility.Create("MAT", "Nursing Mat");
//                cntxt.RoomFacilities.AddAsync(f);
//                f = RoomFacility.Create("BRC", "Baby Resting Chair");
//                cntxt.RoomFacilities.AddAsync(f);
//                f = RoomFacility.Create("BBS", "Dumbo Baby Sitter");
//                cntxt.RoomFacilities.AddAsync(f);
//                f = RoomFacility.Create("CCC", "Children's crockery & cutlery");
//                cntxt.RoomFacilities.AddAsync(f);
//                f = RoomFacility.Create("BBT", "Baby Bathtub");
//                cntxt.RoomFacilities.AddAsync(f);
//                f = RoomFacility.Create("NSM", "Non-slippery bath mat");
//                cntxt.RoomFacilities.AddAsync(f);
//                f = RoomFacility.Create("STB", "Stool in the Bathroom");
//                cntxt.RoomFacilities.AddAsync(f);
//                f = RoomFacility.Create("PLP", "Plastic Potty");
//                cntxt.RoomFacilities.AddAsync(f);
//                f = RoomFacility.Create("SDL", "Safety drawer locks");
//                cntxt.RoomFacilities.AddAsync(f);
//                f = RoomFacility.Create("BOI", "Boiler");
//                cntxt.RoomFacilities.AddAsync(f);
//                f = RoomFacility.Create("INT", "Internet Connection");
//                cntxt.RoomFacilities.AddAsync(f);
//                f = RoomFacility.Create("HAR", "Hair Dryer");
//                cntxt.RoomFacilities.AddAsync(f);
//                f = RoomFacility.Create("BAB", "Bathrobes");
//                cntxt.RoomFacilities.AddAsync(f);
//                f = RoomFacility.Create("SLP", "Slippers ");
//                cntxt.RoomFacilities.AddAsync(f);
//                f = RoomFacility.Create("SAP", "Sun-beds and Parasol ");
//                cntxt.RoomFacilities.AddAsync(f);
//                f = RoomFacility.Create("IRO", "Iron & Iron Board");
//                cntxt.RoomFacilities.AddAsync(f);
//                f = RoomFacility.Create("BWS", "Bathtub with Shower & WC");
//                cntxt.RoomFacilities.AddAsync(f);
//                f = RoomFacility.Create("SHW", "Shower Booth");
//                cntxt.RoomFacilities.AddAsync(f);
//                f = RoomFacility.Create("SAF", "Safe Deposit Box");
//                cntxt.RoomFacilities.AddAsync(f);
//                f = RoomFacility.Create("CAB", "Cable TV");
//                f = RoomFacility.Create("TEL", "Telephone");
//                cntxt.RoomFacilities.AddAsync(f);
//                f = RoomFacility.Create("AIR", "Air Condition");
//                cntxt.RoomFacilities.AddAsync(f);
//                f = RoomFacility.Create("WOR", "Working Desk");
//                cntxt.RoomFacilities.AddAsync(f);
//                f = RoomFacility.Create("PAT", "Patch Cable");
//                cntxt.RoomFacilities.AddAsync(f);
//                f = RoomFacility.Create("MIC", "Microwave Oven");
//                cntxt.RoomFacilities.AddAsync(f);
//                f = RoomFacility.Create("FRD", "Refrigerator");
//                cntxt.RoomFacilities.AddAsync(f);
//                f = RoomFacility.Create("MNB", "Mini Bar");
//                cntxt.RoomFacilities.AddAsync(f);
//                f = RoomFacility.Create("SWC", "Shower & WC");
//                cntxt.RoomFacilities.AddAsync(f);
//                f = RoomFacility.Create("HCW", "Hot &Cold Water");
//                cntxt.RoomFacilities.AddAsync(f);
//                f = RoomFacility.Create("SOF", "Sofa Bed");
//                cntxt.RoomFacilities.AddAsync(f);
//                f = RoomFacility.Create("RAI", "Rain-man Shower & WC");
//                cntxt.RoomFacilities.AddAsync(f);
//                f = RoomFacility.Create("TOA", "Toaster");
//                cntxt.RoomFacilities.AddAsync(f);
//                f = RoomFacility.Create("SUN", "5 Position(Sun Chairs)");
//                cntxt.RoomFacilities.AddAsync(f);
//                f = RoomFacility.Create("WEL", "Welcome Package");
//                cntxt.RoomFacilities.AddAsync(f);
//                f = RoomFacility.Create("DUX", "Dux Matress");
//                cntxt.RoomFacilities.AddAsync(f);
//                f = RoomFacility.Create("CBA", "Children's Bathrobes");
//                cntxt.RoomFacilities.AddAsync(f);
//                f = RoomFacility.Create("COS", "Cosmetic Mirror");
//                cntxt.RoomFacilities.AddAsync(f);
//                f = RoomFacility.Create("BTH", "Bathtub and WC");
//                cntxt.RoomFacilities.AddAsync(f);
//                cntxt.SaveChangesAsync();
//            }


//            if (!cntxt.RoomExposures.Any())
//            {
//                var re = RoomExposure.Create("GAV", "Garden View");
//                cntxt.RoomExposures.AddAsync(re);
//                re = RoomExposure.Create("POV", "Pool View");
//                cntxt.RoomExposures.AddAsync(re);
//                re = RoomExposure.Create("SFV", "Sea Facing View");
//                cntxt.RoomExposures.AddAsync(re);
//                re = RoomExposure.Create("SSV", "Side Sea View");
//                cntxt.RoomExposures.AddAsync(re);
//                re = RoomExposure.Create("PGV", "Pool and Garden View");
//                cntxt.RoomExposures.AddAsync(re);
//                re = RoomExposure.Create("BKV", "Back View");
//                cntxt.RoomExposures.AddAsync(re);
//                cntxt.SaveChangesAsync();

//            }

//            if (!cntxt.RoomGroups.Any())
//            {
//                var rg = RoomGroup.Create("STU", "Studio Type");
//                cntxt.RoomGroups.AddAsync(rg);
//                rg = RoomGroup.Create("HBT", "Studio Happy Baby Type");
//                cntxt.RoomGroups.AddAsync(rg);
//                rg = RoomGroup.Create("ROY", "Royal Studio Type");
//                cntxt.RoomGroups.AddAsync(rg);
//                rg = RoomGroup.Create("ROP", "Royal Studio Pool Access Type");
//                cntxt.RoomGroups.AddAsync(rg);
//                rg = RoomGroup.Create("FAM", "Family Suite Type");
//                cntxt.RoomGroups.AddAsync(rg);
//                rg = RoomGroup.Create("ROF", "Royal Family Suite Type");
//                cntxt.RoomGroups.AddAsync(rg);
//                rg = RoomGroup.Create("DLX", "Deluxe Room No Balcony Type");
//                cntxt.RoomGroups.AddAsync(rg);
//                cntxt.SaveChangesAsync();
//            }

//            if (!cntxt.RoomTypes.Any())
//            {
//                var stu = cntxt.RoomGroups.Where(c => c.Code == "STU").FirstOrDefault();
//                var hbt = cntxt.RoomGroups.Where(c => c.Code == "HBT").FirstOrDefault();
//                var roy = cntxt.RoomGroups.Where(c => c.Code == "ROY").FirstOrDefault();
//                var rop = cntxt.RoomGroups.Where(c => c.Code == "ROP").FirstOrDefault();
//                var fam = cntxt.RoomGroups.Where(c => c.Code == "FAM").FirstOrDefault();
//                var rof = cntxt.RoomGroups.Where(c => c.Code == "ROF").FirstOrDefault();
//                var dlx = cntxt.RoomGroups.Where(c => c.Code == "DLX").FirstOrDefault();


//                var rt = RoomType.Create("12GAT", "Studio Garden View Terrace", stu, 4);
//                cntxt.RoomTypes.AddAsync(rt);
//                rt = RoomType.Create("12GAB", "Studio Garden View Balcony", stu, 4);
//                cntxt.RoomTypes.AddAsync(rt);
//                rt = RoomType.Create("12POT", "Studio Pool View Terrace", stu, 4);
//                cntxt.RoomTypes.AddAsync(rt);
//                rt = RoomType.Create("12POB", "Studio Pool View Balcony", stu, 4);
//                cntxt.RoomTypes.AddAsync(rt);
//                rt = RoomType.Create("12HBT", "Studio Happy Baby", hbt, 4);
//                cntxt.RoomTypes.AddAsync(rt);
//                rt = RoomType.Create("12RPA", "Royal Studio Pool Access", rop, 4);
//                cntxt.RoomTypes.AddAsync(rt);
//                rt = RoomType.Create("12ROT", "Royal Studio Terrace", roy, 4);
//                cntxt.RoomTypes.AddAsync(rt);
//                rt = RoomType.Create("12ROB", "Royal Studio Balcony", roy, 4);
//                cntxt.RoomTypes.AddAsync(rt);
//                rt = RoomType.Create("22POT", "Family Suite Pool View Terrace", fam, 6);
//                cntxt.RoomTypes.AddAsync(rt);
//                rt = RoomType.Create("22POB", "Family Suite Pool View Balcony", fam, 6);
//                cntxt.RoomTypes.AddAsync(rt);
//                rt = RoomType.Create("22RPA", "Royal Family Suite Pool Access", fam, 6);
//                cntxt.RoomTypes.AddAsync(rt);
//                rt = RoomType.Create("22GAB", "Family Suite Garden Balcony", fam, 6);
//                cntxt.RoomTypes.AddAsync(rt);
//                rt = RoomType.Create("22ROB", "Royal Family Suite Balcony", rof, 6);
//                cntxt.RoomTypes.AddAsync(rt);
//                rt = RoomType.Create("DLX", "Deluxe Room No Balcony", dlx, 4);
//                cntxt.RoomTypes.AddAsync(rt);
//                rt = RoomType.Create("22GAT", "Family Suite Garden Terrace", fam, 6);
//                cntxt.RoomTypes.AddAsync(rt);
//                cntxt.SaveChangesAsync();
//            }

//            if (!cntxt.RoomLocations.Any())
//            {
//                var rl = RoomLocation.Create("s", "south");
//                cntxt.RoomLocations.AddAsync(rl);
//                rl = RoomLocation.Create("n", "north");
//                cntxt.RoomLocations.AddAsync(rl);
//                rl = RoomLocation.Create("B11", "Building 1 1st floor");
//                cntxt.RoomLocations.AddAsync(rl);
//                rl = RoomLocation.Create("B12", "Building 1 2nd floor");
//                cntxt.RoomLocations.AddAsync(rl);
//                rl = RoomLocation.Create("B13", "Building 1 3rd floor");
//                cntxt.RoomLocations.AddAsync(rl);
//                rl = RoomLocation.Create("B14", "Building 1 4th floor");
//                cntxt.RoomLocations.AddAsync(rl);
//                rl = RoomLocation.Create("B21", "Building 2 1st floor");
//                cntxt.RoomLocations.AddAsync(rl);
//                rl = RoomLocation.Create("B22", "Building 2 2nd floor");
//                cntxt.RoomLocations.AddAsync(rl);
//                rl = RoomLocation.Create("B23", "Building 2 3rd floor");
//                cntxt.RoomLocations.AddAsync(rl);
//                rl = RoomLocation.Create("B24", "Building 2 4th floor");
//                cntxt.RoomLocations.AddAsync(rl);
//                rl = RoomLocation.Create("B31", "Building 3 1st floor");
//                cntxt.RoomLocations.AddAsync(rl);
//                rl = RoomLocation.Create("B32", "Building 3 2nd floor");
//                cntxt.RoomLocations.AddAsync(rl);
//                rl = RoomLocation.Create("B33", "Building 3 3rd floor");
//                cntxt.RoomLocations.AddAsync(rl);
//                rl = RoomLocation.Create("B41", "Building 4 1st floor");
//                cntxt.RoomLocations.AddAsync(rl);
//                rl = RoomLocation.Create("B42", "Building 4 2nd floor");
//                cntxt.RoomLocations.AddAsync(rl);
//                rl = RoomLocation.Create("B43", "Building 4 3rd floor");
//                cntxt.RoomLocations.AddAsync(rl);
//                rl = RoomLocation.Create("B44", "Building 4 4th floor");
//                cntxt.RoomLocations.AddAsync(rl);
//                rl = RoomLocation.Create("B51", "Building 5 1st floor");
//                cntxt.RoomLocations.AddAsync(rl);
//                rl = RoomLocation.Create("B52", "Building 5 2nd floor");
//                cntxt.RoomLocations.AddAsync(rl);
//                rl = RoomLocation.Create("B53", "Building 5 3rd floor");
//                cntxt.RoomLocations.AddAsync(rl);
//                rl = RoomLocation.Create("B54", "Building 5 4th floor");
//                cntxt.RoomLocations.AddAsync(rl);
//                rl = RoomLocation.Create("B61", "Building 6 1st floor");
//                cntxt.RoomLocations.AddAsync(rl);
//                rl = RoomLocation.Create("B62", "Building 6 2nd floor");
//                cntxt.RoomLocations.AddAsync(rl);
//                rl = RoomLocation.Create("B63", "Building 6 3rd floor");
//                cntxt.RoomLocations.AddAsync(rl);
//                rl = RoomLocation.Create("B71", "Building 7 1st floor");
//                cntxt.RoomLocations.AddAsync(rl);
//                rl = RoomLocation.Create("B72", "Building 7 2nd floor");
//                cntxt.RoomLocations.AddAsync(rl);
//                rl = RoomLocation.Create("B73", "Building 7 3rd floor");
//                cntxt.RoomLocations.AddAsync(rl);
//                rl = RoomLocation.Create("B74", "Building 7 4th floor");
//                cntxt.RoomLocations.AddAsync(rl);
//                rl = RoomLocation.Create("B81", "Building 8 1st floor");
//                cntxt.RoomLocations.AddAsync(rl);
//                rl = RoomLocation.Create("B82", "Building 8 2nd floor");
//                cntxt.RoomLocations.AddAsync(rl);
//                rl = RoomLocation.Create("B83", "Building 8 3rd floor");
//                cntxt.RoomLocations.AddAsync(rl);
//                rl = RoomLocation.Create("BL", "Lobby Building");
//                cntxt.RoomLocations.AddAsync(rl);
//                cntxt.SaveChangesAsync();
//            }

//            if (!cntxt.RoomInfos.Any())
//            {
//                var rt = cntxt.RoomTypes.Where(r => r.Code == "DLX").FirstOrDefault();
//                var bt = cntxt.BedTypes.Where(B => B.Code == "DBL").FirstOrDefault();
//                var rl = cntxt.RoomLocations.Where(r => r.Code == "BL").FirstOrDefault();
//                var re = cntxt.RoomExposures.Where(e => e.Code == "POV").FirstOrDefault();

//                var bkv = cntxt.RoomExposures.Where(e => e.Code == "BKV").FirstOrDefault();
//                var gab = cntxt.RoomTypes.Where(r => r.Code == "22GAB").FirstOrDefault();
//                var fam = cntxt.BedTypes.Where(B => B.Code == "FAM").FirstOrDefault();
//                var b13 = cntxt.RoomLocations.Where(r => r.Code == "B13").FirstOrDefault();
//                var gv = cntxt.RoomExposures.Where(e => e.Code == "GV").FirstOrDefault();

//                var rf1 = RoomInfo.Create("1211", rt, bt, rl, re);
//                cntxt.RoomInfos.AddAsync(rf1);

//                var rf2 = RoomInfo.Create("1212", rt, bt, rl, bkv);
//                cntxt.RoomInfos.AddAsync(rf2);

//                var rf3 = RoomInfo.Create("1301", gab, fam, b13, gv);
//                cntxt.RoomInfos.AddAsync(rf3);

//                cntxt.SaveChangesAsync();

//                var facilities1 = cntxt.RoomFacilities.OrderBy(x => Guid.NewGuid()).Take(5).ToList();
//                var facilities2 = cntxt.RoomFacilities.OrderBy(x => Guid.NewGuid()).Take(5).ToList();
//                var facilities3 = cntxt.RoomFacilities.OrderBy(x => Guid.NewGuid()).Take(5).ToList();

//                rf1.AddRoomRoomFacility(facilities1);
//                rf2.AddRoomRoomFacility(facilities2);
//                rf3.AddRoomRoomFacility(facilities3);
//                cntxt.SaveChangesAsync();

//            }




//        }


//    }
//}
