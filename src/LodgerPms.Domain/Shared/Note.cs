using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static LodgerPms.Domain.Shared.Enums;

namespace LodgerPms.Domain.Shared
{

        public class Note : AgregateRoot.NoteState
    {
        public Note(EntityType entity, string entityValue, bool showInternal, NoteType noteType ,
            string title, string description, DateTime dateCreated, string createBy)
        {
            this.Entity = entity;
            this.EntityValue = entityValue;
            this.Internal = showInternal;
            this.NoteType = noteType;
            this.Title = title;
            this.Description = description;
            this.DateCreated = dateCreated;
            this.CreateBy = createBy;

        }

        public Note() { }
        public bool Internal { get; private set; }
        public NoteType NoteType { get; private set; }
        public EntityType Entity { get; private set; }
        public string EntityValue { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public DateTime DateCreated { get; private set; }
        public string CreateBy { get; private set; }

    }
   

}

