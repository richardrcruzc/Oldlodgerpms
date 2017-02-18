using LodgerPms.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using static LodgerPms.Domain.Shared.Enums;

namespace LodgerPms.Domain.Agents
{
    public class Agent : AgregateRoot.AgentState
    {
        public static Agent New(string description, string term, decimal creditLimit)
        {
            var obj = new Agent {
                Description = description,
                Term =term,
                CreditLimit = creditLimit,
                State = AgentState.Active,
                Contacts = new Collection<ContactInformation>(),
                ShippingAddress = NullContactInformation.Instance,
                BillingAddress = NullContactInformation.Instance,
                AgentRanking = AgentRanking.Silver,
            };
            return obj;
        }
        public void Update(string description, string term, decimal creditLimit)
        {
            Description = description;
            Term = term;
            CreditLimit = creditLimit;
        }


        #region Added to please the O/RM

        /// <summary>
        /// Used by the O/RM to materialize objects
        /// </summary>
        internal Agent()
        { 
            Description = string.Empty;
            Term = string.Empty;
            CreditLimit = decimal.Zero;
            State = AgentState.Active;
            Contacts = new Collection<ContactInformation>();
            ShippingAddress = NullContactInformation.Instance;
            BillingAddress = NullContactInformation.Instance;
            AgentRanking = AgentRanking.Silver;
            Allotments = new Collection<Allotment>();
        }

        #endregion

        public AccountReceivableType AccountReceivableType { get; private set; }
        public AgentType AgentType { get; private set; }
        public AgentGroup AgentGroup { get; private set; }
        public string Description { get; private set; }
        public string ShortDescription { get; private set; }
        public ICollection<ContactInformation> Contacts { get; private set; }
        public ContactInformation ShippingAddress { get; private set; }
        public ContactInformation BillingAddress { get; private set; }
        public string Term { get; private set; }
        public decimal CreditLimit { get; private set; }
        public AgentState State { get; private set; }
        public AgentRanking AgentRanking { get; private set; }

        public ICollection<Allotment> Allotments { get; private set; }

        public Agent Cancel()
        {
            if (State != AgentState.Pending)
                throw new InvalidOperationException("Can't cancel an Agent that is not pending.");

            State = AgentState.Canceled;
            return this;
        }
        public Agent SetAgentAllotmentsDetails(Agent agent, DateTime startDate, DateTime endDate, int qty, int cutOff)
        {
            var alloment = Allotment.CreateNew(agent, startDate, endDate, qty, cutOff);
            Allotments.Add(alloment);
            return this;
        }



        public Agent SetAgentContactDetails(ContactInformation info)
        {

            Contacts.Add(info);
            return this;
        }

        public void CreateNewShippingAddress(ContactInformation contactInfo)
        {
            //BillingAddressId = contactInfo
            BillingAddress = contactInfo;
        }

        public void CreateBillingInformation(ContactInformation billing)
        {
            BillingAddress = billing;
        }
        public void ChangeAgentStatus(AgentState status)
        {
            if (status == State)
            {
                return;
            }
            {
                State = status;
            }

        }
        public void ChangeAgentRanking(AgentRanking ranking)
        {
            if (ranking == AgentRanking)
            {
                return;
            }
            {
                AgentRanking = ranking;
            }

        }
        public override string ToString()
        {

            return String.Format("{0} {1} {2}", Description, CreditLimit, State);
        }
    }
    
}
