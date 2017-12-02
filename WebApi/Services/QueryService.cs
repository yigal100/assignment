using System.Collections.Generic;
using System.Linq;
using WebApi.Data;
using WebApi.DTOs;

namespace WebApi.Services
{
    public class QueryService : IQueryService
    {
        private readonly DatasetContext datasetContext;

        public QueryService(DatasetContext datasetContext)
        {
            this.datasetContext = datasetContext;
        }

        public IEnumerable<YearlyValueDto> GetYearlyValues(string economicVariableId, string industryId, string declaringCountryId, string partnerCountryId)
        {
            var data = from r in datasetContext.Records
                       where r.EconomicVariableId == economicVariableId && r.IndustryId == industryId &&
                             r.DeclaringCountryId == declaringCountryId && r.PartnerCountryId == partnerCountryId &&
                             r.Value != null
                       select new YearlyValueDto {
                           Year = r.Year,
                           Value = new ValueDto {
                               Value = (int)r.Value,
                               Unit = r.Unit,
                               Magnitude = r.PowerCode
                           }
                       };
            return data;
        }
    }
}
