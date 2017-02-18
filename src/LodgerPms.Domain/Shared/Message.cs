using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static LodgerPms.Domain.Shared.Enums;

namespace LodgerPms.Domain.Shared
{
    public class Message :AgregateRoot.MessageState // ValueObject<Message>
    {
        public   Message(MessageStatus messageStatus,string room, string language, string forLastName, string forFirstName,
            string fromLastName, string fromFirtName, DateTime Date, string description)
        {
            this.Room = room;
            this.Language = language;
            this.ForFirstName = forFirstName;
            this.ForLastName = forLastName;
            this.FromFirstName = fromFirtName;
            this.FromLastName = fromLastName;
            this.Description = description;
            this.MessageStatus = messageStatus;
        }
        
        public MessageStatus MessageStatus { get; private set; }
        public string Room { get; private set; }
        public string Language { get; private set; }

        public string ForLastName { get; private set; }
        public string ForFirstName { get; private set; }

        public string FromLastName { get; private set; }
        public string FromFirstName { get; private set; }

        public DateTime Date { get; private set; }

        public string Description { get; private set; }
    }

   
}
