using LodgerPms.Domain.Departments.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace LodgerPms.Application.ViewModels.Deparments
{
    public class DepartmentViewModel
    {
        [Key]
        public string Id { get; set; }
        public Package Package { get;  set; }
        public string DepartmentGroupId { get; set; }
        public DepartmentGroup DepartmentGroup { get;  set; }
        public List<SelectListItem> DepartmentGroups { get; set; }
        public DepartmentType DepartmentType { get;  set; }
        public DepartmentType DepartmentTypes { get; set; }
        public bool ApplyTax { get;  set; }
        public decimal Amount { get;  set; }
        public decimal Percentage { get;  set; }
        [Required(ErrorMessage = "The Description is Required")]
        [MinLength(2)]
        [MaxLength(200)]
        public string Description { get;  set; }
    }
    
    }
