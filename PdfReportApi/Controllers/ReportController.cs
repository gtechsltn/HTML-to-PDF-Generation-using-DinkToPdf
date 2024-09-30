using Microsoft.AspNetCore.Mvc;
using PdfReportApi.Contacts;
using PdfReportApi.Services;

namespace PdfReportApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReportController : ControllerBase
    {
        private readonly IPdfReportService _pdfReportService;

        public ReportController(IPdfReportService pdfReportService)
        {
            _pdfReportService = pdfReportService;
        }

        [HttpGet("generate")]
        public IActionResult GenerateReport()
        {
            var htmlTemplate = System.IO.File.ReadAllText("Templates/ReportTemplate.html");

            var pdfContent = _pdfReportService.GeneratePdfReport(htmlTemplate);

            return File(pdfContent, "application/pdf", "report.pdf");
        }
    }
}
