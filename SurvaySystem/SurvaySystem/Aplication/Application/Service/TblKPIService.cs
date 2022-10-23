
using Application.Resources;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SurvaySystem.ApplicationProject.Common;
using SurvaySystem.ApplicationProject.Interfaces;
using SurvaySystem.ApplicationProject.Interfaces.Repository;
using SurvaySystem.ApplicationProject.Interfaces.Service;
using SurvaySystem.ApplicationProject.Mapping;
using SurvaySystem.DomainProject.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
namespace SurvaySystem.ApplicationProject.Service
{ 
    public class TblKPIService : ITblKPIService
    {
        private readonly ITBlKPIRepository _tBlKPIRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger _logger;

        public TblKPIService(ITBlKPIRepository tBlKPIRepository, IUnitOfWork unitOfWork, ILogger<TblKPIService> logger)
        {
            _tBlKPIRepository = tBlKPIRepository;
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public async Task<ServiceResponse<List<AddTblKPIDTO>>> AddTBlKPI(List<AddTblKPIDTO> addTblKPIs)
        {
            try
            {
                var tbkpis = TBlKPIMapping.Convert(addTblKPIs);
                _tBlKPIRepository.CreateRange(tbkpis);
                int res = await _unitOfWork.CommitAsync();
                var tbDb=tbkpis.ToHashSet();
                //update Id 
                addTblKPIs.ForEach(a =>
                {
                  var foundTblKP =  tbkpis.FirstOrDefault(r => r.KPIDescription == a.Description 
                         && r.DepartmentId == a.DepartmentId
                         && r.MeasureUnit == a.MeasureUnit && r.TargetValue == r.TargetValue);
                    if (foundTblKP != null)
                        a.Id = foundTblKP.Id;
                });
                return new ServiceResponse<List<AddTblKPIDTO>>()
                {
                    Success = res > 0,
                    Data = res > 0 ? addTblKPIs:null,
                    Message = CultureHelper.GetResourceMessage(SystemResource.ResourceManager,
                    res > 0 ? nameof(SystemResource.Added) : nameof(SystemResource.NotAdded))
                };


            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, addTblKPIs, ex.StackTrace);
                return new ServiceResponse<List<AddTblKPIDTO>>()
                {
                    Success = false,
                    Data = null,
                    Message = CultureHelper.GetResourceMessage(SystemResource.ResourceManager,
                      nameof(SystemResource.Error))
                };
            }
        }

        public async Task<ServiceResponse<bool>> UpdateTBlKPI(List<UpdateTblKPIDTO> dtos)
        {
            try
            {
                #region Guard
                var tBIKPs = _tBlKPIRepository.GetAll(a=>dtos.Select(i=>i.Id).Contains(a.Id));
                if(tBIKPs==null)
                    return new ServiceResponse<bool>()
                    {
                        Success = false,
                        Data = false,
                        Message = CultureHelper.GetResourceMessage(SystemResource.ResourceManager,nameof(SystemResource.NotFound))
                    };
                #endregion
                var tBIKPIDB = TBlKPIMapping.Convert(dtos,tBIKPs);
                int res = await _unitOfWork.CommitAsync();
                return new ServiceResponse<bool>()
                {
                    Success = res > 0,
                    Data = res > 0,
                    Message = CultureHelper.GetResourceMessage(SystemResource.ResourceManager,
                    res > 0 ? nameof(SystemResource.Updated) : nameof(SystemResource.NotUpdated))
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, dtos, ex.StackTrace);
                return new ServiceResponse<bool>()
                {
                    Success = false,
                    Data = false,
                    Message = CultureHelper.GetResourceMessage(SystemResource.ResourceManager,
                      nameof(SystemResource.Error))
                };
            }
        }

        public async Task<ServiceResponse<bool>> DeleteTBlKPI(IEnumerable<int> ids)
        {
            try
            {
                #region Guard
                var tBIKP = _tBlKPIRepository.GetAll(a=>ids.Contains(a.Id));
                if (!tBIKP.Any())
                    return new ServiceResponse<bool>()
                    {
                        Success = false,
                        Data = false,
                        Message = CultureHelper.GetResourceMessage(SystemResource.ResourceManager, nameof(SystemResource.NotFound))
                    };
                #endregion
                 _tBlKPIRepository.Delete(tBIKP.Select(a=>a.Id).ToArray());
                int res = await _unitOfWork.CommitAsync();
                return new ServiceResponse<bool>()
                {
                    Success = res > 0,
                    Data = res > 0,
                    Message = CultureHelper.GetResourceMessage(SystemResource.ResourceManager,
                    res > 0 ? nameof(SystemResource.Deleted) : nameof(SystemResource.NotDeleted))
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ids, ex.StackTrace);
                return new ServiceResponse<bool>()
                {
                    Success = false,
                    Data = false,
                    Message = CultureHelper.GetResourceMessage(SystemResource.ResourceManager,
                      nameof(SystemResource.Error))
                };
            }
        }
        public async Task<ServiceResponse<IEnumerable<GetTblKPIDTO>>> GetAll()
        {
            try
            {
                #region Guard
                var tBIKPs = _tBlKPIRepository.GetAllDescendingAsync<int>(a => a.Id);
                if (!tBIKPs.Any())
                    return new ServiceResponse<IEnumerable<GetTblKPIDTO>>()
                    {
                        Success = false,
                        Data = new List<GetTblKPIDTO>(),
                        Message = CultureHelper.GetResourceMessage(SystemResource.ResourceManager, nameof(SystemResource.NotFound))
                    };
                #endregion
                
                var data = TBlKPIMapping.Convert(await tBIKPs.ToListAsync());
                return new ServiceResponse<IEnumerable<GetTblKPIDTO>>()
                {
                    Success = true,
                    Data =  data,
                    Message = CultureHelper.GetResourceMessage(SystemResource.ResourceManager, nameof(SystemResource.GetAllSuccess))
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, null, ex.StackTrace);
                return new ServiceResponse<IEnumerable<GetTblKPIDTO>>()
                {
                    Success = false,
                    Data = null,
                    Message = CultureHelper.GetResourceMessage(SystemResource.ResourceManager,
                      nameof(SystemResource.Error))
                };
            }
        }
      
        public ServiceResponse<T> NotValid<T>(T value)
        {
            return new ServiceResponse<T>()
            {
                Success = false,
                Data = value,
                Message = CultureHelper.GetResourceMessage(SystemResource.ResourceManager, nameof(SystemResource.InvalidEdit))
            };
        }
    }
}
