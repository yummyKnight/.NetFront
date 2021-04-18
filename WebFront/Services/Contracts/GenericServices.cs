using System.Collections.Generic;
using System.Threading.Tasks;

namespace Client.Services.Contracts {
    public interface IGenericServices<TDomainClass> where TDomainClass : class {
        public Task<IEnumerable<TDomainClass>> Get();
        public Task<TDomainClass> Get(int id);
        public Task<TDomainClass> Put(TDomainClass tDomainClass);
        public Task<TDomainClass> Patch(TDomainClass tDomainClass);
        public Task Delete(int id);
    }
}