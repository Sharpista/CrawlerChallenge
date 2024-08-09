using API.Domain.Model.API;
using API.Domain.Model.Common;

namespace API.Domain.Interfaces.Common
{
    public interface IServidorProxyService
    {
        public Task<ResultModel> Post(List<ServidorProxyResponse> servidorProxyResponse);
       
    }
}
