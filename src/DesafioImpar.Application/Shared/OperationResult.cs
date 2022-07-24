using System.Net;

namespace DesafioImpar.Application.Shared
{
    public class OperationResult
    {
        public object Content { get; private set; }

        public HttpStatusCode StatusCode { get; private set; }

        public OperationResult(object content, HttpStatusCode statusCode)
            => (Content, StatusCode) = (content, statusCode);

        public OperationResult(HttpStatusCode statusCode)
            => StatusCode = statusCode;
    }
}
