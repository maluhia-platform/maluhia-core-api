using CrossCutting.Dtos;

namespace CrossCutting.Exceptions;

[Serializable]
public class DomainException : Exception
{
    protected DomainException()
    {
    }

    protected DomainException(DomainExceptionDto dto) : base(dto.Error)
    {
        base.Data.Add(nameof(dto.Domain), dto.Domain);
        base.Data.Add(nameof(dto.Method), dto.Method);
    }

    public static DomainException ThrowException(string domain, string method, string message)
    {
        if (string.IsNullOrWhiteSpace(domain) || string.IsNullOrWhiteSpace(method) ||
            string.IsNullOrWhiteSpace(message))
            throw new DomainException();

        DomainExceptionDto dto = new(domain, method, message);
        return new DomainException(dto);
    }

    protected DomainException(System.Runtime.Serialization.SerializationInfo info,
        System.Runtime.Serialization.StreamingContext context) : base(info, context)
    {
    }
}