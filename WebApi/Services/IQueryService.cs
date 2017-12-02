using System.Collections.Generic;
using WebApi.DTOs;

namespace WebApi.Services
{
    public interface IQueryService
    {
        IEnumerable<YearlyValueDto> GetYearlyValues(string economicVariableId, string industryId, string declaringCountryId, string partnerCountryId);
    }
}
