using DomainProject.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurvaySystem.DomainProject.DTO
{
    public class PaginationDto
    {
        public int PageSize { get; set; } = 15;
        public int PageNumber { get; set; } = 1;
    }
}
