namespace CrossCutting.Dtos;

public struct DomainExceptionDto
{
    public string Domain { get; }
    public string Method { get; }
    public string Error { get; }

    public DomainExceptionDto(string domain, string method, string error)
    {
        Domain = domain;
        Method = method;
        Error = error;
    }
}