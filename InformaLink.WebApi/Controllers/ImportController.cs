using CsvHelper;
using InformaLink.WebApi.Models.Csv;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;

namespace InformaLink.WebApi.Controllers
{
    public class ImportController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(IFormFile csvFile)
        {
            using var rdr = csvFile.OpenReadStream();
            using var streamReader = new StreamReader(rdr);
            using (var csv = new CsvReader(streamReader, CultureInfo.InvariantCulture))
            {
                var records = csv.GetRecords<PrimaryRecord>();
                var arrayOfRecords = records.ToArray();

                return View("UploadCsv", arrayOfRecords);
            }
        }
    }
}
