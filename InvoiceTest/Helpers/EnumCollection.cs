using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace InvoiceTest.Helpers
{
    public enum Activeness
    {
        Deleted = 0,
        Active = 1,
    }

    public enum InvoiceStatus
    {
        Closed = 0,

        Opened = 1,
    }
}
