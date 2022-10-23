using DomainProject.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurvaySystem.DomainProject.DTO
{
    public class AddTblKPIDTO
    {
        [Required(ErrorMessageResourceType = typeof(FieldResources), ErrorMessageResourceName = nameof(FieldResources.MissingKey))]
        [MaxLength(200, ErrorMessageResourceType = typeof(FieldResources), ErrorMessageResourceName = nameof(FieldResources.MaxLength))]
        [MinLength(2, ErrorMessageResourceType = typeof(FieldResources), ErrorMessageResourceName = nameof(FieldResources.MinLength))]
        public string Description { get; set; }
        public int? Id { get; set; }
        public Boolean MeasureUnit { get; set; }
        public int TargetValue { get; set; }
        public int DepartmentId { get; set; }
    }

    
}
