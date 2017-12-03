using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using WebApi.DTOs;
using WebApi.Services;

namespace WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/query")]
    public class QueryController : Controller
    {
        private readonly IQueryService queryService;

        public QueryController(IQueryService queryService)
        {
            this.queryService = queryService;
        }

        // GET: api/query/years?economicVariableId={}&
        [HttpGet("years")]
        public IEnumerable<YearlyValueDto> GetYearlyValues(
            [FromQuery] string economicVariableId,
            [FromQuery] string industryId,
            [FromQuery] string declaringCountryId, 
            [FromQuery] string partnerCountryId)
        {
            if ( string.IsNullOrEmpty(economicVariableId) ||
                string.IsNullOrEmpty(industryId) ||
                string.IsNullOrEmpty(declaringCountryId) ||
                string.IsNullOrEmpty(partnerCountryId)
            ) BadRequest();

            return queryService.GetYearlyValues(economicVariableId, industryId, declaringCountryId, partnerCountryId);
        }               
    }
}
