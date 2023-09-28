using System.ComponentModel.DataAnnotations;

namespace InvoiceTest.Models;

public class Invoice
{
    [Key]
    public int Id { get; set; }
    public string Reference { get; set; } = string.Empty;
    public string CurrencyCode { get; set; } = string.Empty;
    public string IssueDate { get; set; } = string.Empty;
    public decimal OpeningValue { get; set; }
    public decimal PaidValue { get; set; }
    public string DueDate { get; set; } = string.Empty;
    public string? ClosedDate { get; set; } 
    public bool? Cancelled { get; set; } 
    public string DebtorName { get; set; } = string.Empty;
    public string DebtorReference { get; set; } = string.Empty;
    public string? DebtorAddress1 { get; set; } 
    public string? DebtorAddress2 { get; set; } 
    public string? DebtorTown { get; set; } 
    public string? DebtorState { get; set; } 
    public string? DebtorZip { get; set; }
    public string DebtorCountryCode { get; set; } = string.Empty;
    public string? DebtorRegistrationNumber { get; set; }
    public int? IsActive { get; set; }
    public DateTime? CreatedAt { get; set; }
}
