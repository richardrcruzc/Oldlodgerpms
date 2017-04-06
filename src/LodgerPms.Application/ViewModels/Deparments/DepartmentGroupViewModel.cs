using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LodgerPms.Application.ViewModels.Deparments
{
    public class DepartmentGroupViewModel
    {
        [Key]
        public string Id { get; set; }
        public string Code { get; set; }
        [Required(ErrorMessage = "The Description is Required")]
        [MinLength(2)]
        [MaxLength(200)]
        public string Description { get; set; }
    }
}
