using API.Data.Context;
using API.Domain.Interfaces.Common;
using API.Domain.Model.Entities;

namespace API.Data.Repositories
{
    public class ServidorProxyRepository : IServidorProxyRepository
    {
        private readonly ApplicationDbContext _appContext;

        public ServidorProxyRepository(ApplicationDbContext appContext)
        {
            _appContext = appContext;
        }

        public async Task<int> AddServidorProxy(List<ServidorProxy> servidorProxyResponse)
        {
           await _appContext.AddRangeAsync(servidorProxyResponse);
           var r = await _appContext.SaveChangesAsync();

           return r;
        }
    }
}
