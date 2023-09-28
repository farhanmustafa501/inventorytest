namespace InvoiceTest.Models
{
    public class InvoiceSummaryDto
    {
        public decimal TotalOpeningValue { get; set; }
        public decimal TotalPaidValue { get; set; }
        public int TotalRecords { get; set; }
    }
}
