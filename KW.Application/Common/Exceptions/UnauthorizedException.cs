using System.Net;

namespace KW.Application.Common.Exceptions;

public class UnauthorizedException : CustomException
{
    public UnauthorizedException(string msg)
        : base(msg, null, HttpStatusCode.Unauthorized)
    {

    }
}
