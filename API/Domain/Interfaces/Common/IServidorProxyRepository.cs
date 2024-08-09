using API.Domain.Model.API;
using API.Domain.Model.Entities;

namespace API.Domain.Interfaces.Common
{
    public interface IServidorProxyRepository
    {
        Task<int> AddServidorProxy(List<ServidorProxy> servidorProxyResponse);
    }
}
