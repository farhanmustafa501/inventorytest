using InvoiceTest.Helpers;
using InvoiceTest.Models;
using Microsoft.EntityFrameworkCore;

namespace InvoiceTest.Repository;

public interface IInvoiceRepo
{
    Task<List<Invoice>?> GetInvoice(InvoiceStatus status);
    Task<InvoiceSummaryDto?> GetInvoiceStatistics(InvoiceStatus status);
    Task<bool> AddInvoice(Invoice invoice);
}

public class InvoiceRepo : IInvoiceRepo
{
    private readonly AppDbContext context;

    public InvoiceRepo(AppDbContext _appDbContext)
    {
        context = _appDbContext;
    }

    public async Task<List<Invoice>?> GetInvoice(InvoiceStatus status)
    {
        return await context.Invoice
        .Where(x => (status == InvoiceStatus.Closed) ? !string.IsNullOrEmpty(x.ClosedDate) : string.IsNullOrEmpty(x.ClosedDate))
        .ToListAsync();
    }

    public async Task<InvoiceSummaryDto?> GetInvoiceStatistics(InvoiceStatus status)
    {
        var summary = await context.Invoice
        .Where(x => (status == InvoiceStatus.Closed) ? !string.IsNullOrEmpty(x.ClosedDate) : string.IsNullOrEmpty(x.ClosedDate))
        .Select(i => new
        {
            i.OpeningValue,
            i.PaidValue
        })
        .GroupBy(i => 1) 
        .Select(g => new InvoiceSummaryDto
        {
            TotalOpeningValue = g.Sum(i => i.OpeningValue),
            TotalPaidValue = g.Sum(i => i.PaidValue),
            TotalRecords = g.Count()
        })
        .FirstOrDefaultAsync();

        return summary ?? new InvoiceSummaryDto();
    }

    public async Task<bool> AddInvoice(Invoice invoice)
    {
        try
        {
            invoice.IsActive = (int)Activeness.Active;
            invoice.CreatedAt = DateTime.UtcNow;

            context.Invoice.Add(invoice);
            await context.SaveChangesAsync();
            return true;
        }
        catch
        {
            return false;
        }
    }
}
