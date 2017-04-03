using lodgerpms.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LodgerPms.Domain.Departments.Models
{
    public class Department : Identity, IAggregateRoot
    {
        public static Department Create(string id, DepartmentGroup departmentGroup, DepartmentType departmentType, string description, bool applyTax, decimal amount, decimal percentage)
        {
            AssertionConcern.AssertArgumentNotNull(description, "The Department description must be provided.");
            AssertionConcern.AssertArgumentLength(description, 100, "The Department description maximum is 100 characters.");
            var obj = new Department {Id=id, DepartmentType = departmentType,
                                            DepartmentGroup = departmentGroup,
                                            Description = description ,
                                            ApplyTax = applyTax,
                                            Amount= amount,
                                            Percentage = percentage
            };
            return obj;
        }
        #region Added to please the O/RM
        /// <summary>
        /// Used by the O/RM to materialize objects
        /// </summary>
        protected Department()
        {
        }

        #endregion

            public Package Package { get; private set; }
            public DepartmentGroup DepartmentGroup { get; private set; }
            public DepartmentType DepartmentType { get; private set; }
            public bool ApplyTax { get; private set; }
            public decimal Amount { get; private set; }
            public decimal Percentage { get; private set; }
            public string Description { get; private set; }


    }
    public enum DepartmentType
    {
        Debit = 1,
        Credit = 2
    }
}
