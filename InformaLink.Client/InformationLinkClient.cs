using Flurl.Http;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InformaLink.Client
{
    public class InformationLinkClient
    {
        private const string ApiHost = "https://localhost:7058";

        public Task<List<PrimaryRecord>> GetInfo()
        {
            return $"{ApiHost}/api/primary".GetJsonAsync<List<PrimaryRecord>>();
        }
    }
}
