using AutoMapper;
using DesafioImpar.Application.Shared;
using System.Net;

namespace DesafioImpar.Application.RequestHandlers
{
    public class BaseRequestHandler
    {
        protected readonly IMapper Mapper;

        public BaseRequestHandler(IMapper mapper)
            => Mapper = mapper;

        protected OperationResult Success(object content)
            => new(content, HttpStatusCode.OK);

        protected OperationResult Success()
            => new(HttpStatusCode.OK);

        protected OperationResult NotFound()
            => new(HttpStatusCode.NotFound);
    }
}
