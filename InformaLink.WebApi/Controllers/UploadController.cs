using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InformaLink.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UploadController : ControllerBase
    {
        [HttpPost("primary")]
        public async Task UploadPrimary()
        {

        }
    }
}
