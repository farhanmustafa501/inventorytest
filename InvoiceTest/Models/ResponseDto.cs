namespace InvoiceTest.Models;

public class ResponseDto
{
    public object? Data { get; set; }
    public bool? Status { get; set; }
    public string? StatusCode { get; set; }
    public string? Message { get; set; }
}
