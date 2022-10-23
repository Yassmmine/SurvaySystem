using DomainProject.Resources;
using System;
using System.ComponentModel.DataAnnotations;


namespace SurvaySystem.DomainProject.DTO
{
    public class GetTblKPIDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessageResourceType = typeof(FieldResources), ErrorMessageResourceName = nameof(FieldResources.MissingKey))]
        [MaxLength(200, ErrorMessageResourceType = typeof(FieldResources), ErrorMessageResourceName = nameof(FieldResources.MaxLength))]
        [MinLength(2, ErrorMessageResourceType = typeof(FieldResources), ErrorMessageResourceName = nameof(FieldResources.MinLength))]

        public string Description { get; set; }
        public int DepartmentId { get; set; }
        public Boolean MeasureUnit { get; set; }
        [Required]
        [Range(1,int.MaxValue)]
        public int TargetValue { get; set; }
    }
}
