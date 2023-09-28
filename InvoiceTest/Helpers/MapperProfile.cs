
using AutoMapper;
using InvoiceTest.Models;

namespace InvoiceTest.Helpers;

public class MapperProfile : Profile
{
    public MapperProfile()
    {
        CreateMap<Invoice, AddInvoiceDto>();
        CreateMap<AddInvoiceDto, Invoice>();
    }
}
