using AutoMapper;
using InvoiceTest.Filters;
using InvoiceTest.Helpers;
using InvoiceTest.Models;
using InvoiceTest.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.ComponentModel.DataAnnotations;

namespace InvoiceTest.Controllers
{
    [ExceptionHandler]
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceController : ControllerBase
    {
        private readonly IInvoiceRepo invoiceRepo;
        private readonly IMapper mapper;
        public InvoiceController(IInvoiceRepo _invoiceRepo, IMapper _mapper)
        {
            invoiceRepo = _invoiceRepo;
            mapper = _mapper;
        }

        [HttpPost("AddInvoice")]
        public async Task<IActionResult> AddInvoice([FromBody] AddInvoiceDto invoice)
        {
            if(!await invoiceRepo.AddInvoice(mapper.Map<Invoice>(invoice)))
            {
                return Ok(new ResponseDto { Status = false, StatusCode = "400", Message = "Database insertion failed." });
            }

            return Ok(new ResponseDto { Status = true, StatusCode = "200", Message = "Record inserted." });
        }

        [HttpGet("GetInvoice")]
        public async Task<IActionResult> GetInvoices([Required] InvoiceStatus status)
        {
            var invoices = await invoiceRepo.GetInvoice(status);
                
            return Ok(new ResponseDto { Data = invoices, Status = true, StatusCode = "200", Message = "" });
        }


        [HttpGet("GetInvoiceStats")]
        public async Task<IActionResult> GetInvoiceStatistics([Required] InvoiceStatus status)
        {
            var invoices = await invoiceRepo.GetInvoiceStatistics(status);

            return Ok(new ResponseDto { Data = invoices, Status = true, StatusCode = "200", Message = "" });
        }
    }
}
