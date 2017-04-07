using lodgerpms.Domain.Common;
using LodgerPms.Domain.Departments.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LodgerPms.Application.ViewModels.Deparments
{
   public class PackageViewModel
    {
        [Key]
        public string Id { get; set; }
        [Required(ErrorMessage = "The Code is Required")]
        [MinLength(2)]
        [MaxLength(10)]
        public string Code { get; private set; }
        // to enter the short code for the package element or group
        [Required(ErrorMessage = "The Short Description is Required")]
        [MinLength(2)]
        [MaxLength(100)]
        public string ShortDescription { get; private set; }
        [Required(ErrorMessage = "The   Description is Required")]
        [MinLength(2)]
        [MaxLength(500)]
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
}
