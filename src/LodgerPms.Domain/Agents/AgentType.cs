using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LodgerPms.Domain.Agents
{

    public class AgentType : Identity
    {
        public static AgentType Create(string description)
        {

            AssertionConcern.AssertArgumentNotNull(description, "The Agent Type description must be provided.");
            AssertionConcern.AssertArgumentLength(description, 100, "The Agent Type description maximum is 100 characters.");
            var bedType = new AgentType { Description = description };
            return bedType;

        }

        #region Added to please the O/RM

        /// <summary>
        /// Used by the O/RM to materialize objects
        /// </summary>
        protected AgentType()
        {
        }

        #endregion


        public string Description { get; private set; }



    }
}
