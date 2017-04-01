using LodgerPms.Domain.Departments.Models;
using System;

using System.ComponentModel.DataAnnotations;


namespace LodgerPms.Application.ViewModels.Deparments
{
    public class DepartmentViewModel
    {
        [Key]
        public string Id { get; set; }
        public Package Package { get;  set; }
        public DepartmentGroup DepartmentGroup { get;  set; }
        public DepartmentType DepartmentType { get;  set; }
        public bool ApplyTax { get;  set; }
        public decimal Amount { get;  set; }
        public decimal Percentage { get;  set; }
        [Required(ErrorMessage = "The Description is Required")]
        [MinLength(2)]
        [MaxLength(200)]
        public string Description { get;  set; }
    }
}
