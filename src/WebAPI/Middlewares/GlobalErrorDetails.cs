using System.Text;

namespace Maluhia.Core.Filters;

public struct GlobalErrorDetails
{
    public int StatusCode { get; set; }
    public string Message { get; set; }
}