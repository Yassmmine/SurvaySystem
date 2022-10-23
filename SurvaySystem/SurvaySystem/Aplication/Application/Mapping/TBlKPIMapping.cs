using SurvaySystem.DomainProject.DTO;
using SurvaySystem.DomainProject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurvaySystem.ApplicationProject.Mapping
{
    public static class TBlKPIMapping
    {
        public static TBlKPI Convert (this AddTblKPIDTO addTblKPIDTO)
        {
            if (addTblKPIDTO == null)
                return null;
            return new TBlKPI()
            {
                KPIDescription = addTblKPIDTO.Description,
                MeasureUnit = addTblKPIDTO.MeasureUnit,
                TargetValue = addTblKPIDTO.TargetValue,
                DepartmentId =addTblKPIDTO.DepartmentId,
                IsDeleted = false,
            };
        }
        public static List<TBlKPI> Convert(List<AddTblKPIDTO> inputs)
        {
            List<TBlKPI> result = new List<TBlKPI>();
            result.AddRange(inputs.Select(a => a.Convert()));
            return result;
        }
        
        public static TBlKPI Convert(this UpdateTblKPIDTO updatesTblKPIDTO , TBlKPI tBlKPIDb)
        {
            if (updatesTblKPIDTO == null || tBlKPIDb ==null)
                return null;
            tBlKPIDb.KPIDescription = updatesTblKPIDTO.Description;
            tBlKPIDb.MeasureUnit = updatesTblKPIDTO.MeasureUnit;
            tBlKPIDb.TargetValue = updatesTblKPIDTO.TargetValue;

            return tBlKPIDb;
        }

        public static List<TBlKPI> Convert(List<UpdateTblKPIDTO> updatesTblKPIDTO, List<TBlKPI> KPIs)
        {
            List<TBlKPI> result = new List<TBlKPI>();
            var updates = updatesTblKPIDTO.ToHashSet();
            KPIs.ForEach(a =>
            {
               var foundKPI = updatesTblKPIDTO.FirstOrDefault(i => i.Id == a.Id);
               if(foundKPI!=null)
                    result.Add(foundKPI.Convert(a));
            });
            return result;
        }

        public static GetTblKPIDTO Convert(this TBlKPI tBlKPIDb)
        {
            if (tBlKPIDb == null)
                return null;
            return new GetTblKPIDTO()
            {
                Id = tBlKPIDb.Id,
                DepartmentId = tBlKPIDb.DepartmentId,
                Description = tBlKPIDb.KPIDescription,
                MeasureUnit = tBlKPIDb.MeasureUnit,
                TargetValue = tBlKPIDb.TargetValue
            };
        }
        public static List<GetTblKPIDTO> Convert(List<TBlKPI> inputs)
        {
            List<GetTblKPIDTO> result = new List<GetTblKPIDTO>();
            result.AddRange(inputs.Select(a => a.Convert()));
            return result;
        }
    }
}
