using System;
using static lodgerpms.Domain.Common.Enums;

namespace lodgerpms.Domain.Common
{
    public  class Person : Identity
    {
        
        public static Person Create(Title title, PersonType personType, FullName fullName,  DateTime dob, 
            Gender gender,string nationality, IdentifcationType identifcationType, string identifcationValue)
        { 
            var obj = new  Person {
                    PersonType =personType,
                    Title = title,
                    FullName = new FullName(fullName),
                    DOB=dob,
                    Gender =gender,
                    Nationality = nationality,
                    IdentifcationType= identifcationType,
                    IdentifcationValue= identifcationValue
            };
            return obj;

        }
        public void Update(Title title, PersonType personType, FullName fullName, DateTime dob, Gender gender,
            string nationality, IdentifcationType identifcationType, string identifcationValue)
        {
            PersonType = personType;
            Title = title;
            FullName = fullName;
            DOB = dob;
            Gender = gender;
            Nationality = nationality;
            IdentifcationType = identifcationType;
            IdentifcationValue = identifcationValue;
             
        }
        public PersonType PersonType { get;   set; }
        public Title Title { get;   set; }
        
        public FullName FullName { get;  set; }

        public bool Vip { get; private set; }
        public string Nationality { get; private set; }
        public DateTime DOB { get;  set; }
        public Gender Gender { get;  set; }

        public IdentifcationType IdentifcationType { get;  set; }
        public string IdentifcationValue { get;  set; }
        public DateTime Issue { get;  set; }
        public DateTime Expire { get;  set; }

        //public ContactInformation ContactInformation
        //{
        //    get
        //    {
        //        return this.contactInformation;
        //    }

        //    private set
        //    {
        //        AssertionConcern.AssertArgumentNotNull(value, "The person contact information is required.");
        //        this.contactInformation = value;
        //    }
        //}

        //public void ChangeContactInformation(ContactInformation newContactInformation)
        //{
        //    // Defer validation to the property setter.
        //    this.ContactInformation = newContactInformation;
        //}
        public void ChangeName(FullName newName)
        {
            // Defer validation to the property setter.
            this.FullName = newName;
        }

        //public EmailAddress EmailAddress
        //{
        //    get { return this.ContactInformation.EmailAddress; }
        //}
        //public Telephone PrimaryTelephone
        //{
        //    get { return this.ContactInformation.PrimaryTelephone; }
        //}
        /// <summary>
        /// Title for the Department (Mr, Mrs, etc)
        /// </summary>
        /// <returns>string</returns>
        public Title GetTitle()
        {
            switch (Gender)
            {
                case Gender.Female:
                    return Title.Mrs;
                case Gender.Male:
                    return Title.Mr;
                default:
                    return Title.NA;
            }
        }


        public override string ToString()
        {
            var title = GetTitle();
            const string Format = "Person title={0} name={1}, contactInformation={2}]";
            return string.Format(Format, title, this.FullName);
        }
    }


}

