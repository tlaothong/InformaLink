using CsvHelper;
using InformaLink.WebApi.Models.Csv;
using InformaLink.WebApi.Services;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;

namespace InformaLink.WebApi.Controllers
{
    public class ImportController : Controller
    {
        private readonly PrimaryRepository primaryRepository;

        public ImportController(PrimaryRepository primaryRepository)
        {
            this.primaryRepository = primaryRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [RequestSizeLimit(2_000_000)]
        public async Task<IActionResult> Index(IFormFile csvFile)
        {
            if (csvFile == null)
                return View("Error");

            using var rdr = csvFile.OpenReadStream();
            using var streamReader = new StreamReader(rdr);
            using (var csv = new CsvReader(streamReader, CultureInfo.InvariantCulture))
            {
                var records = csv.GetRecords<PrimaryRecord>();
                var arrayOfRecords = records.ToArray();

                await primaryRepository.SaveRecords(arrayOfRecords);

                return View("UploadCsv", arrayOfRecords);
            }
        }
    }
}
