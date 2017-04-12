
using LodgerPms.Domain.Common;
using LodgerPms.Domain.SeedWork;
using LodgerPms.Domain.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LodgerPms.Departments.Api.Model
{

public class Package : Entity, IAggregateRoot
    {
    public static Package Create(
        string  code, 
        string shortDescription,
        string foresCastGroup,
        string description,
        bool taxAverageCode,
        string averageCode,
        string alternate,
        bool allowance,
        string profitCode,
        string lossCode,
       RateAttribute attributes,
       bool sellSeparate,
       string itemInventory,
       PostinFrecuency postingFrecuency,
     string formula,    
     string validFrom,
     string validTo,
     string calculateRule)
        {

            AssertionConcern.AssertArgumentNotNull(code, "The Package code must be provided.");
            AssertionConcern.AssertArgumentLength(code, 10, "The Package code maximum is 10 characters.");

            AssertionConcern.AssertArgumentNotNull(shortDescription, "The Package shortDescription must be provided.");
            AssertionConcern.AssertArgumentLength(shortDescription, 100, "The Package shortDescription maximum is 100 characters.");

            AssertionConcern.AssertArgumentNotNull(description, "The Package description must be provided.");
            AssertionConcern.AssertArgumentLength(description, 500, "The Package description maximum is 500 characters.");
           

            var obj = new Package {Code=  code,
            ShortDescription= shortDescription,
            ForesCastGroup= foresCastGroup,
            Description= description,
            TaxAverageCode= taxAverageCode,
            AverageCode= averageCode,
            Alternate= alternate,
            Allowance= allowance,
            ProfitCode= profitCode,
            LossCode = lossCode,
            Attributes= attributes,
            SellSeparate= sellSeparate,
            ItemInventory =itemInventory,
            PostingFrecuency = postingFrecuency,
            Formula =formula,
            ValidFrom= validFrom,
            ValidTo= validTo,
            CalculateRule= calculateRule
        };
        return obj;
    }

    #region Added to please the O/RM
    /// <summary>
    /// Used by the O/RM to materialize objects
    /// </summary>
    protected Package()
    {
    }

        #endregion

        public string Code { get; private set; }
        // to enter the short code for the package element or group
        public string ShortDescription { get; private set; }
        public string Description { get; private set; }
        public string ForesCastGroup { get; private set; }
        //allows making the element part of a package group.
        public bool TaxAverageCode { get; private set; }
        /*deducts the tax amount from the amount of the package
element. */
        public string AverageCode { get; private set; } 
        //is the transaction code for the allowance on the package ledger.
        public decimal Average { get; private set; }
        /*is the transaction code that any overage to the allowance posts.
If the amount consumed exceeds the allowed package allowance, the
excess amount posts on the guest folio using this transaction code. */
        public bool TaxAverage { get; private set; }
        /*deducts the tax amount from the amount of the package
element. */

        public string Alternate { get; private set; }
        /* includes any transaction codes allowed on this package. For
example, although we expect a guest to have breakfast in the café, they
may order room service instead and still have that amount allowed on their
package. You may also need to include taxes, gratuities, and beverages for
the package to post correctly. */


        public bool Allowance { get; private set; }
        /*is for Advanced Packages.It allows the package charge to
post through an interface or manually in OPERA.After selecting
Allowance select the appropriate “Profit” and “Loss” transaction codes for
this package.These codes appear on the package ledger for accounting
reports.*/
        public string ProfitCode { get; private set; }
        public string LossCode { get; private set; }
        public Money Currency { get; private set; }

        public RateAttribute Attributes { get; private set; }
        public bool SellSeparate { get; private set; }
        public bool PostNextDay { get; private set; }
        public string ItemInventory { get; private set; }


        public PostinFrecuency PostingFrecuency { get; private set; }
        public string Formula { get; private set; }
        public string CalculationRule { get; private set; }
        public string ValidFrom { get; private set; }
        public string ValidTo { get; private set; }

        public string CalculateRule { get; private set; }
        public IEnumerable<PackageDetail> Details { get; private set; }



    }
    public enum RateAttribute
    {
        PerAdultChild=1,
        PerPerson=2,
        FlatAmount=3
    }
    public enum PostinFrecuency
    {
        PostEveryNight = 1,
        PostOnArrivalNight = 2,
        PostOnEveryXNightsStartingNightY = 3,
        PostOnCertainNightsOfTheWeek = 4 ,
        PostOnLastNight=5,
        PostEveryNightExceptArrivalNight=6,
        PostEveryNightExceptLast=7,
        DoNotPostOnFirstAndLastNight=8,
        FloatingAllowancePerStay=9,
        CustomPostingSchedule=10

    }

}