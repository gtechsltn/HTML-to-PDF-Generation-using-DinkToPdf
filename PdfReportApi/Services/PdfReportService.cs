using DinkToPdf.Contracts;
using DinkToPdf;
using PdfReportApi.Contacts;

namespace PdfReportApi.Services
{
    public class PdfReportService : IPdfReportService
    {
        private readonly IConverter _converter;

        public PdfReportService(IConverter converter)
        {
            _converter = converter;
        }

        public byte[] GeneratePdfReport(string htmlContent)
        {
            var pdfDocument = new HtmlToPdfDocument
            {
                GlobalSettings = new GlobalSettings
                {
                    PaperSize = PaperKind.A4,
                    Orientation = Orientation.Portrait
                },
                Objects = {
                    new ObjectSettings
                    {
                        HtmlContent = htmlContent,
                        WebSettings = { DefaultEncoding = "utf-8" }
                    }
                }
            };

            return _converter.Convert(pdfDocument);
        }
    }
}
