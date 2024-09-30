namespace PdfReportApi.Contacts
{
    public interface IPdfReportService
    {
        byte[] GeneratePdfReport(string htmlContent);
    }
}