using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LodgerPms.Application.ViewModels.Deparments
{
    public class FolioPatternViewModel
    {
        [Key]
        public string Id { get; set; }
        [Required(ErrorMessage = "The Code is Required")]
        [MinLength(2)]
        [MaxLength(10)]
        public string Code { get; set; }
        [Required(ErrorMessage = "The Description is Required")]
        [MinLength(2)]
        [MaxLength(200)]
        public string Description { get; set; }
    }
}
