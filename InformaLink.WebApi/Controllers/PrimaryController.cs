using InformaLink.WebApi.Models;
using InformaLink.WebApi.Models.Dbs;
using InformaLink.WebApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InformaLink.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrimaryController : ControllerBase
    {
        private readonly PrimaryRepository primaryRepository;

        public PrimaryController(PrimaryRepository primaryRepository)
        {
            this.primaryRepository = primaryRepository;
        }

        [HttpGet]
        public Task<List<PrimeRecord>> GetMyRecords()
        {
            return primaryRepository.GetRecords();
        }

        [HttpPost("bystation")]
        public Task<List<PrimeRecord>> GetRecordsByStations([FromBody] StationsQuery query)
        {
            return primaryRepository.GetRecordsByStations(query.StationIds);
        }
    }
}
