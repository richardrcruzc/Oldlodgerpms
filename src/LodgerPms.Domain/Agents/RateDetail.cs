using LodgerPms.Domain.Rooms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LodgerPms.Domain.Agents
{

    public class RateDetail
    {
        public RateDetail()
        {
        }
        public Rate Rate { get; private set; }
        public RoomType RoomType { get; private set; }
        public bool Sunday { get; private set; }
        public bool Monday { get; private set; }
        public bool Tuesday { get; private set; }
        public bool Wednesday { get; private set; }
        public bool Thursday { get; private set; }
        public bool Friday { get; private set; }
        public bool Saturday { get; private set; }
        public int AdultQty { get; private set; }
        public int ChildQty { get; private set; }
        public decimal Adult { get; private set; }
        public decimal Child { get; private set; }
        public decimal ExtraAdult  { get; private set; }
        public decimal ExtraChild { get; private set; }

    }
}
