using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LodgerPms.Domain.Agents
{

    public class AgentGroup : Identity
    {
        public static AgentGroup Create(string description)
        {

            AssertionConcern.AssertArgumentNotNull(description, "The AgentGroup description must be provided.");
            AssertionConcern.AssertArgumentLength(description, 100, "The AgentGroup description maximum is 100 characters.");
            var bedType = new AgentGroup { Description = description };
            return bedType;

        }

        #region Added to please the O/RM

        /// <summary>
        /// Used by the O/RM to materialize objects
        /// </summary>
        protected AgentGroup()
        {
        }

        #endregion


        public string Description { get; private set; }



    }
}
