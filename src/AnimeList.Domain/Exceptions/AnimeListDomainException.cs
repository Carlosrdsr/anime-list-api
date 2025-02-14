using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Net;

namespace AnimeList.Domain.Exceptions;

public class AnimeListDomainException : Exception
{
    private readonly List<string> _errors;

    public HttpStatusCode? HttpStatusCode { get; private set; }
    public string Code { get; private set; }
    public IReadOnlyCollection<string> Errors => _errors;

    public AnimeListDomainException(HttpStatusCode httpStatusCode, string code, string message) : base(message)
    {
        HttpStatusCode = httpStatusCode;

        Code = code;

        _errors = new List<string>
            {
                message
            };
    }

    public AnimeListDomainException(string code, string message) : base(message)
    {
        Code = code;

        _errors = new List<string>
            {
                message
            };
    }

    public AnimeListDomainException(Error error) : base(error.Message)
    {
        Code = error.Code;

        _errors = new List<string>
            {
                error.Message
            };
    }

    public AnimeListDomainException(List<string> erros)
    {
        _errors = erros;
    }

    public AnimeListDomainException(string message) : base(message)
    {
        _errors = new List<string>
            {
                message
            };
    }

    public bool IsThisError(string code)
    {
        if (string.IsNullOrEmpty(Code)) return false;

        return Code == code;
    }
}
