using API.Domain.Interfaces.Common;
using API.Domain.Model.API;
using API.Domain.Model.Common;

namespace API.Service
{
    public class ServidorProxyService : IServidorProxyService
    {
        private readonly ILogger<ServidorProxyService> _logger;
        private readonly IServidorProxyRepository _repository;

        public ServidorProxyService(ILogger<ServidorProxyService> logger, 
                                    IServidorProxyRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        public async Task<ResultModel> Post(List<ServidorProxyResponse> servidorProxyResponse)
        {
            var servidoresMapeados = servidorProxyResponse.Select(x => x.MapToDomain()).ToList();
            var resultado = await _repository.AddServidorProxy(servidoresMapeados);

            return resultado != 0 ? ResultModel.Success() : ResultModel.Error("Erro ao adicionar servidor");
        }
    }
}
