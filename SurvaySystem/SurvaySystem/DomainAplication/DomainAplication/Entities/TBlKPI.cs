using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurvaySystem.DomainProject.Entities
{
    public class TBlKPI:BaseEntity<int>
    {
        public string KPIDescription { get; set; }
        public int DepartmentId { get; set; }
        public Boolean MeasureUnit { get; set; }
        public int TargetValue { get; set; }
    }
}
