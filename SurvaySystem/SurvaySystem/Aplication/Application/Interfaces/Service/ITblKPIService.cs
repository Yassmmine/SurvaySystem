
using SurvaySystem.ApplicationProject.Common;
using SurvaySystem.DomainProject.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurvaySystem.ApplicationProject.Interfaces.Service
{ 
    public interface ITblKPIService
    {

        Task<ServiceResponse<List<AddTblKPIDTO>>> AddTBlKPI(List<AddTblKPIDTO> addTblKPIs);
        Task<ServiceResponse<bool>> UpdateTBlKPI(List<UpdateTblKPIDTO> dtos);
        Task<ServiceResponse<IEnumerable<GetTblKPIDTO>>> GetAll();
        Task<ServiceResponse<bool>> DeleteTBlKPI(IEnumerable<int> ids);
        ServiceResponse<T> NotValid<T>(T value);
    }
}
